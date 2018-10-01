using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources.Data
{
    class UserInformationInXMLFiles
    {
        string location;
        int imagesPerPerson;

        public UserInformationInXMLFiles(string xmlFileLocation, int imagesPerPerson)
        {
            this.location = xmlFileLocation;
            this.imagesPerPerson = imagesPerPerson;
        }


        //Metodas kvieciamas, kai reikia apmokyti FaceRecognizer objekta
        public void GetTrainingSet(out List<Image<Gray, byte>> faceTrainingSet, out int[] labels, out List<string> nicknames)
        {
            faceTrainingSet = new List<Image<Gray, byte>>();
            nicknames = new List<string>();
            List<int> labelsList = new List<int>();
            int label = 0;

            FileStream filestream = File.OpenRead(location + "faceImages.xml");
            long filelength = filestream.Length;
            byte[] xmlBytes = new byte[filelength];
            filestream.Read(xmlBytes, 0, (int)filelength);
            filestream.Close();

            MemoryStream xmlStream = new MemoryStream(xmlBytes);

            using (XmlReader xmlreader = XmlTextReader.Create(xmlStream))
            {
                while (xmlreader.Read())
                {
                    if (xmlreader.IsStartElement())
                    {
                        switch (xmlreader.Name)
                        {
                            case "NICKNAME":
                                if (xmlreader.Read())
                                {
                                    nicknames.Add(xmlreader.Value.Trim());
                                }
                                break;
                            case "IMAGE_0":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }
                                break;
                            case "IMAGE_1":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }
                                break;
                            case "IMAGE_2":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }
                                break;
                            case "IMAGE_3":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }
                                break;
                            case "IMAGE_4":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }
                                break;
                        }
                    }
                }
            }

            labels = labelsList.ToArray();
        }

        //Sekmingai atlikus veido atpazinima bus gaunama naudotojo informacija
        /*public IUser GetUser(string nickname)
        {

        }

        //Nepavykus veido atpazinimui bus tikrinami ar naudotojo suvesti duomenys yra teisingi(jei taip grazinamas IUser, jei ne - null)
        public IUser GetUser(string nickname, string password)
        {

        }*/

        //Issaugomas registracija ivykdes vartotojas
        public void AddUser(Image<Gray, byte>[] faceImages, IUser iuser)
        {
            XmlDocument document = new XmlDocument();
            document.Load(location + "faceImages.xml");

            XmlElement root = document.DocumentElement;

            XmlElement user_D = document.CreateElement("USER");

            XmlElement name_D = document.CreateElement("NAME");
            XmlElement surname_D = document.CreateElement("SURNAME");
            XmlElement nickname_D = document.CreateElement("NICKNAME");
            XmlElement password_D = document.CreateElement("PASSWORD");
            XmlElement birth_D = document.CreateElement("DATE_OF_BIRTH");
            XmlElement image_0_D = document.CreateElement("IMAGE_0");
            XmlElement image_1_D = document.CreateElement("IMAGE_1");
            XmlElement image_2_D = document.CreateElement("IMAGE_2");
            XmlElement image_3_D = document.CreateElement("IMAGE_3");
            XmlElement image_4_D = document.CreateElement("IMAGE_4");

            string[] fileNames = SaveImages(faceImages, iuser.Name, iuser.Surname);

            name_D.InnerText = iuser.Name;
            surname_D.InnerText = iuser.Surname;
            nickname_D.InnerText = iuser.Nickname;
            password_D.InnerText = iuser.Password;
            birth_D.InnerText = iuser.DateOfBirth;
            image_0_D.InnerText = fileNames[0];
            image_1_D.InnerText = fileNames[1];
            image_2_D.InnerText = fileNames[2];
            image_3_D.InnerText = fileNames[3];
            image_4_D.InnerText = fileNames[4];

            user_D.AppendChild(name_D);
            user_D.AppendChild(surname_D);
            user_D.AppendChild(nickname_D);
            user_D.AppendChild(password_D);
            user_D.AppendChild(birth_D);
            user_D.AppendChild(image_0_D);
            user_D.AppendChild(image_1_D);
            user_D.AppendChild(image_2_D);
            user_D.AppendChild(image_3_D);
            user_D.AppendChild(image_4_D);

            root.AppendChild(user_D);

            document.Save(location + "faceImages.xml");
        }


        //Pradedami kaupti nauji duomenys (pries naudojant si metoda istryti visus senus)
        public void CreateNewUserList(Image<Gray, byte>[] faceImages, IUser iuser)
        {
            string[] fileNames = SaveImages(faceImages, iuser.Name, iuser.Surname);

            FileStream stream = File.OpenWrite(location + "faceImages.xml");

            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Users_faces");

                writer.WriteStartElement("USER");
                writer.WriteElementString("NAME", iuser.Name);
                writer.WriteElementString("SURNAME", iuser.Surname);
                writer.WriteElementString("NICKNAME", iuser.Nickname);
                writer.WriteElementString("PASSWORD", iuser.Password);
                writer.WriteElementString("DATE_OF_BIRTH", iuser.DateOfBirth);
                for (int i = 0; i < imagesPerPerson; i++)
                {
                    writer.WriteElementString("IMAGE_" + i, fileNames[i]);
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            stream.Close();
        }

        //Metodas issaugantis nuotraukas
        private string[] SaveImages(Image<Gray, byte>[] images, string name, string surname)
        {
            string[] fileNames = new string[imagesPerPerson];

            Random random = new Random();

            for (int i = 0; i < imagesPerPerson; i++)
            {
                fileNames[i] = name + "_" + surname + "_" + random.Next() + ".jpg";
                images[i].Save(location + fileNames[i]);
            }

            return fileNames;
        }

    }
}

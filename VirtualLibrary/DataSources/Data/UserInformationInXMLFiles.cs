using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Emgu.CV;
using Emgu.CV.Structure;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources.Data
{
    internal class UserInformationInXmlFiles
    {
        private readonly int _imagesPerPerson;
        private readonly string _location;

        public UserInformationInXmlFiles(string xmlFileLocation, int imagesPerPerson)
        {
            _location = xmlFileLocation;
            this._imagesPerPerson = imagesPerPerson;
        }


        //Metodas kvieciamas, kai reikia apmokyti FaceRecognizer objekta
        public void GetTrainingSet(out List<Image<Gray, byte>> faceTrainingSet, out int[] labels,
            out List<string> nicknames)
        {
            faceTrainingSet = new List<Image<Gray, byte>>();
            nicknames = new List<string>();
            var labelsList = new List<int>();
            var label = 0;

            var filestream = File.OpenRead(_location + "faceImages.xml");
            var filelength = filestream.Length;
            var xmlBytes = new byte[filelength];
            filestream.Read(xmlBytes, 0, (int) filelength);
            filestream.Close();

            var xmlStream = new MemoryStream(xmlBytes);

            using (var xmlreader = XmlReader.Create(xmlStream))
            {
                while (xmlreader.Read())
                    if (xmlreader.IsStartElement())
                        switch (xmlreader.Name)
                        {
                            case "NICKNAME":
                                if (xmlreader.Read()) nicknames.Add(xmlreader.Value.Trim());
                                break;
                            case "IMAGE_0":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(_location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }

                                break;
                            case "IMAGE_1":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(_location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }

                                break;
                            case "IMAGE_2":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(_location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }

                                break;
                            case "IMAGE_3":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(_location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }

                                break;
                            case "IMAGE_4":
                                if (xmlreader.Read())
                                {
                                    faceTrainingSet.Add(new Image<Gray, byte>(_location + xmlreader.Value.Trim()));
                                    labelsList.Add(label++);
                                }

                                break;
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
            var document = new XmlDocument();
            document.Load(_location + "faceImages.xml");

            var root = document.DocumentElement;

            var userD = document.CreateElement("USER");

            var nameD = document.CreateElement("NAME");
            var surnameD = document.CreateElement("SURNAME");
            var nicknameD = document.CreateElement("NICKNAME");
            var passwordD = document.CreateElement("PASSWORD");
            var birthD = document.CreateElement("DATE_OF_BIRTH");
            var image0D = document.CreateElement("IMAGE_0");
            var image1D = document.CreateElement("IMAGE_1");
            var image2D = document.CreateElement("IMAGE_2");
            var image3D = document.CreateElement("IMAGE_3");
            var image4D = document.CreateElement("IMAGE_4");

            var fileNames = SaveImages(faceImages, iuser.Name, iuser.Surname);

            nameD.InnerText = iuser.Name;
            surnameD.InnerText = iuser.Surname;
            nicknameD.InnerText = iuser.Nickname;
            passwordD.InnerText = iuser.Password;
            birthD.InnerText = iuser.DateOfBirth;
            image0D.InnerText = fileNames[0];
            image1D.InnerText = fileNames[1];
            image2D.InnerText = fileNames[2];
            image3D.InnerText = fileNames[3];
            image4D.InnerText = fileNames[4];

            userD.AppendChild(nameD);
            userD.AppendChild(surnameD);
            userD.AppendChild(nicknameD);
            userD.AppendChild(passwordD);
            userD.AppendChild(birthD);
            userD.AppendChild(image0D);
            userD.AppendChild(image1D);
            userD.AppendChild(image2D);
            userD.AppendChild(image3D);
            userD.AppendChild(image4D);

            root.AppendChild(userD);

            document.Save(_location + "faceImages.xml");
        }


        //Pradedami kaupti nauji duomenys (pries naudojant si metoda istryti visus senus)
        public void CreateNewUserList(Image<Gray, byte>[] faceImages, IUser iuser)
        {
            var fileNames = SaveImages(faceImages, iuser.Name, iuser.Surname);

            var stream = File.OpenWrite(_location + "faceImages.xml");

            using (var writer = XmlWriter.Create(stream))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Users_faces");

                writer.WriteStartElement("USER");
                writer.WriteElementString("NAME", iuser.Name);
                writer.WriteElementString("SURNAME", iuser.Surname);
                writer.WriteElementString("NICKNAME", iuser.Nickname);
                writer.WriteElementString("PASSWORD", iuser.Password);
                writer.WriteElementString("DATE_OF_BIRTH", iuser.DateOfBirth);
                for (var i = 0; i < _imagesPerPerson; i++) writer.WriteElementString("IMAGE_" + i, fileNames[i]);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            stream.Close();
        }

        //Metodas issaugantis nuotraukas
        private string[] SaveImages(Image<Gray, byte>[] images, string name, string surname)
        {
            var fileNames = new string[_imagesPerPerson];

            var random = new Random();

            for (var i = 0; i < _imagesPerPerson; i++)
            {
                fileNames[i] = name + "_" + surname + "_" + random.Next() + ".jpg";
                images[i].Save(_location + fileNames[i]);
            }

            return fileNames;
        }
    }
}
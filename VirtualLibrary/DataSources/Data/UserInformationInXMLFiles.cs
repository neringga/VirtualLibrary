using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Emgu.CV;
using Emgu.CV.Structure;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources.Data
{
    class UserInformationInXmlFiles
    {
        private readonly int _imagesPerPerson;
        private readonly string _location;

        public UserInformationInXmlFiles(string xmlFileLocation, int imagesPerPerson)
        {
            _location = xmlFileLocation;
            _imagesPerPerson = imagesPerPerson;
        }



        public void GetTrainingSet(out List<Image<Gray, byte>> faceTrainingSet, out int[] labels,
            out List<string> nicknames)
        {
            XDocument xml = XDocument.Load(_location + "faceImages.xml");

            List<string>[] imageNamesLists = new List<string>[_imagesPerPerson];
            List<int> labelsList = new List<int>();

            faceTrainingSet = new List<Image<Gray, byte>>();


            for (int i = 0; i < _imagesPerPerson; i++)
            {
                imageNamesLists[i] = xml.Descendants("IMAGE_" + i).Select(element => element.Value).ToList();
            }

            for (int i = 0; i < imageNamesLists[0].Count; i++)
            {
                for (int x = 0; x < _imagesPerPerson; x++)
                {
                    faceTrainingSet.Add(new Image<Gray, byte>(_location + imageNamesLists[x].ElementAt(i)));
                    labelsList.Add(i * _imagesPerPerson + x);
                }
            }

            nicknames = xml.Descendants("NICKNAME").Select(element => element.Value).ToList();

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


        public void AddUser(Image<Gray, byte>[] faceImages, IUser iuser)
        {
            XmlDocument document = new XmlDocument();
            document.Load(_location + "faceImages.xml");

            XmlElement root = document.DocumentElement;

            XmlElement userD = document.CreateElement("USER");

            XmlElement nameD = document.CreateElement("NAME");
            XmlElement surnameD = document.CreateElement("SURNAME");
            XmlElement nicknameD = document.CreateElement("NICKNAME");
            XmlElement passwordD = document.CreateElement("PASSWORD");
            XmlElement birthD = document.CreateElement("DATE_OF_BIRTH");
            XmlElement[] images = new XmlElement[_imagesPerPerson];


            string[] fileNames = SaveImages(faceImages, iuser.Name, iuser.Surname);

            nameD.InnerText = iuser.Name;
            surnameD.InnerText = iuser.Surname;
            nicknameD.InnerText = iuser.Nickname;
            passwordD.InnerText = iuser.Password;
            birthD.InnerText = iuser.DateOfBirth;

            userD.AppendChild(nameD);
            userD.AppendChild(surnameD);
            userD.AppendChild(nicknameD);
            userD.AppendChild(passwordD);
            userD.AppendChild(birthD);

            for (int i = 0; i < _imagesPerPerson; i++)
            {
                images[i] = document.CreateElement("IMAGE_" + i);
                images[i].InnerText = fileNames[i];
                userD.AppendChild(images[i]);
            }

            root.AppendChild(userD);

            document.Save(_location + "faceImages.xml");
        }



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
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace VirtualLibrary.DataSources
{
    class XmlSerializedDataSource<T> : IExternalDataSource<T>
    {
        private readonly string _path;
        private readonly XmlSerializer _serializer;
     

        public XmlSerializedDataSource(string path)
        {
            _path = path;
            _serializer = new XmlSerializer(typeof(T));
        }


        public IList<T> GetList()
        {
            List<T> list = new List<T>();
            StreamReader stream;

            int i = 0;
            while (File.Exists(_path + i + ".xml"))
            {
                stream = new StreamReader(_path + i + ".xml");
                list.Add((T) _serializer.Deserialize(stream));
                i++;
            }

            return list;
        }

        


        public void AddElement(T element)
        {
            int i = 0;
            while (File.Exists(_path + i + ".xml"))
            {
                i++;
            }

            FileStream stream = File.Create(_path + i + ".xml");
            _serializer.Serialize(stream, element);
            stream.Close();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace MapEditor
{
    public class XmlSave
    {
<<<<<<< HEAD
        public static Type[] extraType = { typeof(Tile) };
        public static void SaveData(object IClass, string filename)
        {
            StreamWriter writer = null;
           
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer((IClass.GetType()), extraType);
=======
        public static void SaveData(object IClass, string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer((IClass.GetType()));
>>>>>>> 337fd0a1772d155f1f00848e5c562fd39ab1a88a
                writer = new StreamWriter(filename);
                xmlSerializer.Serialize(writer, IClass);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
                writer = null;
            }
        }
    }

    public class XmlLoad<T>
    {
        public static Type type;
<<<<<<< HEAD
        public static Type[] extraType = { typeof(Tile) };
=======
>>>>>>> 337fd0a1772d155f1f00848e5c562fd39ab1a88a

        public XmlLoad()
        {
            type = typeof(T);
        }

        public T LoadData(string filename)
        {
            T result;
<<<<<<< HEAD
            XmlSerializer xmlserializer = new XmlSerializer(type, extraType);
=======
            XmlSerializer xmlserializer = new XmlSerializer(type);
>>>>>>> 337fd0a1772d155f1f00848e5c562fd39ab1a88a
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            result = (T)xmlserializer.Deserialize(fs);
            fs.Close();
            return result;
        }
    }
}
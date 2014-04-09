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
        public static Type[] extraType = new Type[] { typeof(Tile) };
        public static void SaveData(object IClass, string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer((IClass.GetType()), extraType);
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
        public static Type[] extraType = new Type[] { typeof(Tile) };

        public XmlLoad()
        {
            type = typeof(T);
        }

        public T LoadData(string filename)
        {
            T result;
            XmlSerializer xmlserializer = new XmlSerializer(type, extraType);
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            result = (T)xmlserializer.Deserialize(fs);
            fs.Close();
            return result;
        }
    }
}
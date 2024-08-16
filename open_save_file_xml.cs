using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GME_PLC_EDITOR
{
    internal class open_save_file_xml
    {
        public static List<IO_TAGS> io_tags = new List<IO_TAGS>();
        public static void Serialize(List<IO_TAGS> data, string dosya)
        {
            FileStream fs = new FileStream(dosya, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<IO_TAGS>));
            serializer.Serialize(fs, data);
            fs.Close();
        }

        public static List<IO_TAGS> Deserialize(string dosya)
        {
            FileStream fs = new FileStream(dosya, FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(List<IO_TAGS>));
            List<IO_TAGS> liste = (List<IO_TAGS>)xs.Deserialize(fs);
            fs.Close();
            return liste;
        }

    }
}

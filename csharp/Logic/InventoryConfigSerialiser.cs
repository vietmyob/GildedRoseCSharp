using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using csharp.DTO;

namespace csharp.Logic
{
    public class InventoryConfigSerialiser
    {
        private static readonly XmlSerializer Serialiser = new XmlSerializer(typeof(InventoryConfig));

        public void Generate(InventoryConfig inventoryConfig)
        {
            using (var fs = new FileStream("InventoryConfig", FileMode.OpenOrCreate))
            {
                Serialiser.Serialize(fs, inventoryConfig);
            }
        }

        public InventoryConfig Load(string xmlFilePath)
        {
            xmlFilePath = GetFilePath(xmlFilePath);
            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                return (InventoryConfig)Serialiser.Deserialize(fileStream);
            }
        }

        private static string GetFilePath(string xmlFilePath)
        {
            if (File.Exists(xmlFilePath)) return xmlFilePath;

            var applicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            xmlFilePath = Path.Combine(applicationPath, xmlFilePath);
            return xmlFilePath;
        }
    }
}

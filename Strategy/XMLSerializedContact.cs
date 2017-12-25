using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Strategy
{
    public class XMLSerializedContact : ISerializedContact
    {
        public Contact GetContact(FileStream fs)
        {
            XDocument doc = XDocument.Load(fs);
            XElement root = doc.Root;
            return new Contact()
            {
                name = root.Element("Name").Value,
                phone = root.Element("Phone").Value
            };
        }

        public void SaveContact(FileStream fs, Contact c)
        {
            try
            {
                XElement root = new XElement("Contact",
                    new XElement("Name", c.name),
                    new XElement("Phone", c.phone));
                XDocument doc = new XDocument(root);
                doc.Save(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to serialize as XML. Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}

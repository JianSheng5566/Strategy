using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Strategy
{
    public class BinarySerializedContact : ISerializedContact
    {
        public Contact GetContact(FileStream fs)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return (Contact)formatter.Deserialize(fs);
        }

        public void SaveContact(FileStream fs, Contact c)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, c);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize as binary. Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Strategy
{
    public class JsonSerializedContact : ISerializedContact
    {
        public Contact GetContact(FileStream fs)
        {
            byte[] ba = new byte[fs.Length];
            fs.Read(ba, 0, ba.Length);
            string json = System.Text.Encoding.Default.GetString(ba);
            return JsonConvert.DeserializeObject<Contact>(json);
        }

        public void SaveContact(FileStream fs, Contact c)
        {
            try
            {
                string json = JsonConvert.SerializeObject(c);
                byte[] ba = System.Text.Encoding.Default.GetBytes(json);
                fs.Write(ba, 0, ba.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to serialize as Json. Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}

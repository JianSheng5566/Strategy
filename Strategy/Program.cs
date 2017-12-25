using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Strategy
{
    class Program
    {
        public enum SerialType
        {
            Binary,
            XML,
            Json
        }
        public static ISerializedContact GetSerialization(SerialType type)
        {
            switch (type)
            {
                case SerialType.XML:
                    return new XMLSerializedContact();
                case SerialType.Json:
                    return new JsonSerializedContact();
                case SerialType.Binary:
                default:
                    return new BinarySerializedContact();
            }
        }

        public static void PrintContact(Contact c)
        {
            Console.WriteLine("Contact");
            Console.WriteLine("  Name: {0}", c.name);
            Console.WriteLine("  Phone: {0}", c.phone);
        }

        static void Main(string[] args)
        {
            Contact c = new Contact()
            {
                name = "JianSheng",
                phone = "0800092000"
            };
            FileStream fsb = new FileStream("BinaryContact.txt", FileMode.Create);
            ISerializedContact s = GetSerialization(SerialType.Binary);
            s.SaveContact(fsb, c);

            fsb = new FileStream("BinaryContact.txt", FileMode.Open);
            Contact cb = s.GetContact(fsb);
            Console.WriteLine("Binary");
            PrintContact(cb);

            FileStream fsj = new FileStream("JsonContact.txt", FileMode.Create);
            s = GetSerialization(SerialType.Json);
            s.SaveContact(fsj, c);

            fsj = new FileStream("JsonContact.txt", FileMode.Open);
            Contact cj = s.GetContact(fsj);
            Console.WriteLine("Json");
            PrintContact(cj);

            FileStream fsx = new FileStream("XMLContact.txt", FileMode.Create);
            s = GetSerialization(SerialType.XML);
            s.SaveContact(fsx, c);

            fsx = new FileStream("XMLContact.txt", FileMode.Open);
            Contact cx = s.GetContact(fsx);
            Console.WriteLine("XML");
            PrintContact(cx);

            Console.ReadLine();
        }
    }
}

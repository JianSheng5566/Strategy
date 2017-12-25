using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Strategy
{
    interface ISerializedContact
    {
        Contact GetContact(FileStream fs);
        void SaveContact(FileStream fs, Contact c);
    }
}

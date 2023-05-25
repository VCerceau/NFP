using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NeverForgetPass
{
    public class Cryption
    {
        static string strAlgName = "Pbkdf2Sha256";
        static UInt32 targetKeySize = 32;
        static UInt32 iterationCount = 10000;
    }
}

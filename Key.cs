using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NeverForgetPass
{
    static class Session
    {
        public static string? Key { get; set; }
    }
}

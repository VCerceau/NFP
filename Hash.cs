using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NeverForgetPass
{
    class Hash
    {   
        public string simpleHash(string texttohash)
        {
            // Créez un objet SHA256 pour générer un hachage SHA256
            SHA256 sha256 = SHA256.Create();

            // Convertissez la chaîne en tableau de bytes
            byte[] inputBytes = Encoding.ASCII.GetBytes(texttohash);

            // Calculez le hachage SHA256 de la chaîne
            byte[] hash = sha256.ComputeHash(inputBytes);

            // Convertissez le hachage en chaîne hexadécimale
            string texthashed = BitConverter.ToString(hash).Replace("-", "");

            return texthashed;
        }
        public string doubleHash(string texttohash)
        {
            string firststhash = simpleHash(texttohash).ToString();
            string secondhash = simpleHash(firststhash).ToString();

            return secondhash;
        }
    }
}

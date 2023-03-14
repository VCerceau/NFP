using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Connection : Page
    {

        public Connection()
        {
            string dbPath = "myDatabase.db";
            InitializeComponent();
            SQLiteConnection dbconnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            dbconnection.Open();
            SQLiteCommand cmd;
            SQLiteDataReader dataReader;
            string sql = "Select * from users";
            cmd = new SQLiteCommand(sql, dbconnection);
            dataReader = cmd.ExecuteReader();
            dbconnection.Close();
        }

        private void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dbPath = "myDatabase.db";
            InitializeComponent();
            SQLiteConnection dbconnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            dbconnection.Open();
            SQLiteCommand cmd;
            SQLiteDataReader dataReader;
            string sql = "Select password from users";
            cmd = new SQLiteCommand(sql, dbconnection);
            dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                string password = PasswordBox.Password;

                if (password != null)
                {
                    // Créez un objet SHA256 pour générer un hachage SHA256
                    SHA256 sha256 = SHA256.Create();

                    // Convertissez la chaîne en tableau de bytes
                    byte[] inputBytes = Encoding.ASCII.GetBytes(password);

                    // Calculez le hachage SHA256 de la chaîne
                    byte[] hash = sha256.ComputeHash(inputBytes);

                    // Convertissez le hachage en chaîne hexadécimale
                    string hashedpass = BitConverter.ToString(hash).Replace("-", "");

                    string word = "d&K#sL@1i^Fg8p!v7$U6hTzVQoJjW9uPxYOyZmE2cNl05eAbSa4qrXwRtI3n";

                    byte[] key = new byte[32]; // Clé de 256 bits
                    byte[] iv = new byte[16]; // Vecteur d'initialisation de 128 bits

                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = key;
                        aes.IV = iv;

                        // Créer un déchiffreur pour déchiffrer les données
                        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);


                        // Convertir la chaîne de caractères chiffrée en tableau d'octets
                        byte[] ciphertextBytes = Convert.FromBase64String(dataReader.GetValue(0).ToString());

                        // Déchiffrer les données
                        byte[] plaintextBytes = decryptor.TransformFinalBlock(ciphertextBytes, 0, ciphertextBytes.Length);

                        // Convertir le résultat déchiffré en chaîne de caractères
                        string plaintext = Encoding.UTF8.GetString(plaintextBytes);

                        if (word == plaintext)
                        {
                            MessageBox.Show("connected");
                            User.Key = hashedpass;
                        }
                        else
                        {
                            MessageBox.Show("Password Incorrect" + plaintext + word);
                        }
                    }
                }
                else 
                {
                    MessageBox.Show("Entre a password please");
                }

                
                dbconnection.Close();
            }
        }
    }
}

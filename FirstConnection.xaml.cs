using System.Collections.Generic;
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
using System;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FirstConnection : Page
    {
        public FirstConnection()
        {
            InitializeComponent();
        }

        private void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox_First.Password == PasswordBox_Confirm.Password)
            {
                string dbPath = "myDatabase.db";

                SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
                connection.Open();

                string password = PasswordBox_First.Password;

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

                    // Créer un chiffreur pour chiffrer les données
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    // Convertir la chaîne de caractères en tableau d'octets
                    byte[] plaintextBytes = Encoding.UTF8.GetBytes(word);

                    // Chiffrer les données
                    byte[] ciphertextBytes = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);

                    // Convertir le résultat chiffré en chaîne de caractères
                    string ciphertext = Convert.ToBase64String(ciphertextBytes);
                    string insertQuery = "INSERT INTO users (password) VALUES ('"+ ciphertext + "')";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }

            }
            else
            {
                MessageBox.Show("Les mots de passe sont différents !");
            }
        }
    }
}
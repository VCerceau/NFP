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
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace NeverForgetPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Connection : Page
    {
        private MainWindow mainWindow;


        public Connection(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
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
            InitializeComponent();

            using (var db = new DB())
            {
                db.Database.EnsureCreated();
                var users = db.Users.First();

                Hash hashObject = new Hash();
                string password = PasswordBox.Password;

                if (users.Password == hashObject.doubleHash(password))
                {
                    Session.Key = hashObject.simpleHash(password);


                    this.mainWindow.InformationText("Connected !");
                    this.mainWindow.ConnectNavButton.Visibility = Visibility.Hidden;
                    this.mainWindow.To_Tableau(this.mainWindow);
                }
                else
                {
                    MessageBox.Show("Password Incorrect");
                }

            }
        }
    }
}

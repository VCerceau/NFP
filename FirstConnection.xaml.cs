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
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using WpfApp2;
using SQLitePCL;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FirstConnection : Page
    {
        private MainWindow mainWindow;

        public FirstConnection(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox_First.Password == PasswordBox_Confirm.Password)
            {
                Hash hashObject = new Hash();
                string doublehashedpass = hashObject.doubleHash(PasswordBox_First.Password).ToString();

                using (var db = new DB())
                {
                    var user = new User { Password = doublehashedpass };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                Session.Key = hashObject.simpleHash(PasswordBox_First.Password).ToString();

                MainWindow mainWindow = new MainWindow();
                this.mainWindow.InformationText("Account Created + Connected");
                this.mainWindow.ConnectNavButton.Visibility = Visibility.Hidden;
                this.mainWindow.To_Tableau(mainWindow);

            }
            else
            {
                MessageBox.Show("Les mots de passe sont différents !");
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    public partial class Tableau : Page
    {

        public Tableau(MainWindow mainWindow)
        {
            if (User.Key != null)
            {
                InitializeComponent();
                string dbPath = "myDatabase.db";
                SQLiteConnection dbconnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
                dbconnection.Open();
                SQLiteCommand cmd;
                SQLiteDataReader dataReader;
                string sql = "Select * from pass";
                cmd = new SQLiteCommand(sql, dbconnection);
                dataReader = cmd.ExecuteReader();

                if (dataReader.Read()) { 
                    while(dataReader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", dataReader.GetInt32(0),
                        dataReader.GetString(1));
                    }
                }
            }
            else
            {
                MessageBox.Show("oui");
                mainWindow.MainFrame.Navigate(new Connection());
            }
        }
        private void UsernameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((bool?)UsernameBox.Tag != true)
            {
                UsernameBox.Text = null;
            }
        }

        private void UsernameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                UsernameBox.Text = "Username";
                UsernameBox.Tag = false;
            }
            else
            {
                UsernameBox.Tag = true;
            }
        }
        private void WebsiteBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((bool?)WebsiteBox.Tag != true)
            {
                WebsiteBox.Text = null;
            }
        }

        private void WebsiteBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                WebsiteBox.Text = "Website_Name";
                WebsiteBox.Tag = false;
            }
            else
            {
                WebsiteBox.Tag = true;
            }
        }
        private void UrlBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((bool?)UrlBox.Tag != true)
            {
                UrlBox.Text = null;
            }
        }

        private void UrlBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                UrlBox.Text = "https:website.url";
                UrlBox.Tag = false;
            }
            else
            {
                UrlBox.Tag = true;
            }
        }
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((bool?)UrlBox.Tag != true)
            {
                PasswordBox.Text = null;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                PasswordBox.Text = "Password";
                PasswordBox.Tag = false;
            }
            else
            {
                PasswordBox.Tag = true;
            }
        }
    }
}
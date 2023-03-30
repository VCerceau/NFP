using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
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

namespace NeverForgetPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new DashboardPage());

            using (var db = new DB())
            {
                db.Database.EnsureCreated();
                var users = db.Users.ToList();

                if (users.Count() < 1)
                {
                    MainFrame.Navigate(new FirstConnection(this));
                }
                else
                {
                    MainFrame.Navigate(new Connection(this));
                }
            }
        }

        public void InformationText(string text)
        {
            this.Information.Text = "Information : " + text;
        }

        public void NavigateToConnectionPage()
        {
            MainFrame.Navigate(new Connection(this));
        }
        public void To_Tableau(MainWindow mainWindow)
        {
            // Naviguer vers la page du tableau
            if (Session.Key != null)
            {
                MainFrame.Navigate(new Tableau(mainWindow));
            }
            else
            {
                MessageBox.Show("You need to be connected");
                MainFrame.Navigate(new Connection(mainWindow));
            }
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page du dashboard
            MainFrame.Navigate(new DashboardPage());
        }




        private void Tableau_Click(object sender, RoutedEventArgs e)
        {
            To_Tableau(this);
        }

        private void Connection_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page de Connection
            MainFrame.Navigate(new Connection(this));
        }

    }
}

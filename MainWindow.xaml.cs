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

namespace WpfApp2
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
            string dbPath = "myDatabase.db";

            // Vérification si le fichier de base de données existe déjà
            if (!System.IO.File.Exists(dbPath))
            {
                // Création de la connexion
                SQLiteConnection.CreateFile(dbPath);
                SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
                connection.Open();

                // Création de la table
                string createUserQuery = "CREATE TABLE users (id INTEGER PRIMARY KEY AUTOINCREMENT, password TEXT)";
                SQLiteCommand createTableCommand = new SQLiteCommand(createUserQuery, connection);
                createTableCommand.ExecuteNonQuery();

                string createPassQuery = "CREATE TABLE pass (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, url TEXT, password TEXT, is_superpassword BOOL)";
                SQLiteCommand createPassCommand = new SQLiteCommand(createPassQuery, connection);
                createPassCommand.ExecuteNonQuery();

                MainFrame.Navigate(new FirstConnection());

                // Fermeture de la connexion
                connection.Close();

            }
            else
            {
                SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
                connection.Open();

                SQLiteCommand cmd;
                SQLiteDataReader dataReader;
                string sql = "Select * from users";
                cmd = new SQLiteCommand(sql, connection);
                dataReader = cmd.ExecuteReader();
                Console.WriteLine("Data from the Database..");
                if (!dataReader.Read()){
                    MainFrame.Navigate(new FirstConnection());
                }
                else
                {
                    MainFrame.Navigate(new Connection());
                }
                while (dataReader.Read())
                {

                    MessageBox.Show(dataReader.GetValue(0) + " || " +
                                        dataReader.GetValue(1));
                }

                dataReader.Close();

                // Fermeture de la connexion
                connection.Close();
            }

        }

        public void NavigateToConnectionPage()
        {
            MainFrame.Navigate(new Connection());
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page du dashboard
            MainFrame.Navigate(new DashboardPage());
        }

        private void Tableau_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page du tableau
            MainFrame.Navigate(new Tableau(this));
        }
        
        private void Connection_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page de Connection
            MainFrame.Navigate(new Connection());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("aa");
        }
    }
}

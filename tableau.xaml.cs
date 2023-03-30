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

namespace NeverForgetPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Tableau : Page
    {

        public Tableau(MainWindow mainWindow)
        {
            if (Session.Key != null)
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
                using (var db = new DB())
                {
                    var passList = db.Passes.ToList();
                    if (passList!=null)
                    {
                        foreach (var Data in passList)
                        {
                            // Create a new instance of the stack panel for each website data
                            StackPanel stackPanel = new StackPanel();
                            stackPanel.Name = Data.Id.ToString();
                            stackPanel.Margin = new Thickness(5);

                            // Create the content for the top stack panel
                            StackPanel topStackPanel = new StackPanel();
                            topStackPanel.Background = Brushes.LightGray;
                            topStackPanel.Orientation = Orientation.Vertical;

                            // Create the grid and its definitions
                            Grid grid = new Grid();
                            grid.RowDefinitions.Add(new RowDefinition());
                            grid.RowDefinitions.Add(new RowDefinition());
                            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

                            // Create the website name stack panel and text block
                            StackPanel websiteNameStackPanel = new StackPanel();
                            Label websiteNameLabel = new Label() { Content = "Website Name" };
                            TextBlock websiteNameTextBlock = new TextBlock() { Text = Data.Name, FontSize = 20 };
                            websiteNameStackPanel.Children.Add(websiteNameLabel);
                            websiteNameStackPanel.Children.Add(websiteNameTextBlock);
                            Grid.SetColumn(websiteNameStackPanel, 0);

                            // Create the website URL stack panel and text block
                            StackPanel websiteUrlStackPanel = new StackPanel();
                            Label websiteUrlLabel = new Label() { Content = "Website URL" };
                            TextBlock websiteUrlTextBlock = new TextBlock() { Text = Data.Url, FontSize = 16 };
                            websiteUrlStackPanel.Children.Add(websiteUrlLabel);
                            websiteUrlStackPanel.Children.Add(websiteUrlTextBlock);
                            Grid.SetColumn(websiteUrlStackPanel, 1);

                            // Create the username stack panel and text block
                            StackPanel usernameStackPanel = new StackPanel();
                            Label usernameLabel = new Label() { Content = "Username" };
                            TextBlock usernameTextBlock = new TextBlock() { Text = Data.Username, FontSize = 20 };
                            usernameStackPanel.Children.Add(usernameLabel);
                            usernameStackPanel.Children.Add(usernameTextBlock);
                            Grid.SetRow(usernameStackPanel, 1);
                            Grid.SetColumn(usernameStackPanel, 0);

                            // Create the password stack panel and text block
                            StackPanel passwordStackPanel = new StackPanel();
                            Label passwordLabel = new Label() { Content = "Password" };
                            TextBlock passwordTextBlock = new TextBlock() { Text = Data.Password };
                            passwordStackPanel.Children.Add(passwordLabel);
                            passwordStackPanel.Children.Add(passwordTextBlock);
                            Grid.SetRow(passwordStackPanel, 1);
                            Grid.SetColumn(passwordStackPanel, 1);

                            // Add the grid to the top stack panel
                            grid.Children.Add(websiteNameStackPanel);
                            grid.Children.Add(websiteUrlStackPanel);
                            grid.Children.Add(usernameStackPanel);
                            grid.Children.Add(passwordStackPanel);
                            topStackPanel.Children.Add(grid);

                            // Create the bottom stack panel with the Edit button
                            StackPanel bottomStackPanel = new StackPanel();
                            bottomStackPanel.Orientation = Orientation.Horizontal;
                            bottomStackPanel.HorizontalAlignment = HorizontalAlignment.Right;
                            bottomStackPanel.Margin = new Thickness(6);
                            Button editButton = new Button() { Content = "Edit" };
                            editButton.Width = 100;
                            editButton.Height = 30;
                            editButton.Name = "EditButton";
                            editButton.Click += EditButton_Click;
                            bottomStackPanel.Children.Add(editButton);

                            // Add the top and bottom stack panels to the main stack panel
                            stackPanel.Children.Add(topStackPanel);
                            stackPanel.Children.Add(bottomStackPanel);

                            // Add the main stack panel to your layout
                            PasswordsListe.Children.Add(stackPanel);
                        }
                    }
                    
                }
            }
            else
            {
                InitializeComponent();
                MessageBox.Show("oui");
                mainWindow.MainFrame.Navigate(new Connection(mainWindow));
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text != "" && UsernameBox.Text != "")
            {
                using(DB db = new DB())
                {

                    Pass pass = new Pass(UsernameBox.Text, PasswordBox.Text);
                    db.Passes.Add(pass);
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
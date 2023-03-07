using System;
using System.Collections.Generic;
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

        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page du dashboard
            MainFrame.Navigate(new DashboardPage());
        }

        private void Tableau_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page du tableau
            MainFrame.Navigate(new Tableau());
        }
        
        private void Connection_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page du tableau
            MainFrame.Navigate(new Connection());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("aa");
            /*Label label = new Label();
            label.Height = 100;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.Name = "label";*/
        }
    }
}

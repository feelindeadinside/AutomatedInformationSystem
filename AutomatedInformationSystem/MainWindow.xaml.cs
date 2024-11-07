using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace AutomatedInformationSystem
{
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Data Source=store.db;Version=3;";
        public MainWindow()
        {
            InitializeComponent();
            DatabaseInitializer.InitializeDatabase(); 
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close(); 
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close(); 
        }
    }
}

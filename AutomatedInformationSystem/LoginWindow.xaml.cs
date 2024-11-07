using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AutomatedInformationSystem;

namespace AutomatedInformationSystem
{
    public partial class LoginWindow : Window
    {
        private readonly AppDbContext _context;

        public LoginWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();  
            UsernameTextBox.LostFocus += TextBox_LostFocus;
            PasswordTextBox.LostFocus += TextBox_LostFocus;
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (textBox == UsernameTextBox)
                    {
                        textBox.Text = "Имя пользователя";
                        textBox.Foreground = Brushes.White;
                    }
                    else if (textBox == PasswordTextBox)
                    {
                        textBox.Text = "Пароль";
                        textBox.Foreground = Brushes.White;
                    }
                }
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Text = "";
            }
        }
        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void SubmitLoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text; 

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Авторизация прошла успешно!");
                var role = GetUserRole(username);
                if (role == "Клиент")
                {
                    ClientWindow clientWindow = new ClientWindow();
                    clientWindow.Show();
                }
                else if (role == "Сотрудник")
                {
                    EmployeeWindow employeeWindow = new EmployeeWindow();
                    employeeWindow.Show();
                }
                Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }


        private bool AuthenticateUser(string username, string password)
        {
            var user = _context.User.FirstOrDefault(u => u.username == username);

            if (user == null)
                return false;

            return user.password == password;
        }

        private string GetUserRole(string username)
        {
            var user = _context.User.FirstOrDefault(u => u.username == username);
            return user?.role ?? "Клиент";  
        }
    }
}

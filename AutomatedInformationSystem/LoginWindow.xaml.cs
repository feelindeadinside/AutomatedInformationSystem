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
            _context = new AppDbContext();  // Инициализация контекста базы данных
            UsernameTextBox.LostFocus += TextBox_LostFocus;
            PasswordTextBox.LostFocus += TextBox_LostFocus;
        }

        // Логика очистки текста в полях при потере фокуса
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

        // Логика очистки текста в полях при получении фокуса
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Text = "";
            }
        }

        // Метод для перехода на главный экран
        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        // Метод для обработки входа пользователя
        private void SubmitLoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text; // Используем PasswordBox.Password для пароля

            if (AuthenticateUser(username, password))
            {
                // Если авторизация успешна, показываем основное окно
                MessageBox.Show("Авторизация прошла успешно!");

                // Определяем роль пользователя и открываем соответствующее окно
                var role = GetUserRole(username);
                if (role == "Клиент")
                {
                    // Если роль "Клиент", открываем окно для клиента
                    ClientWindow clientWindow = new ClientWindow();
                    clientWindow.Show();
                }
                else if (role == "Сотрудник")
                {
                    // Если роль "Сотрудник", открываем окно для сотрудника
                    EmployeeWindow employeeWindow = new EmployeeWindow();
                    employeeWindow.Show();
                }

                // Закрываем окно входа
                Close();
            }
            else
            {
                // Если авторизация не удалась, показываем ошибку
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        // Логика авторизации пользователя
        private bool AuthenticateUser(string username, string password)
        {
            // Поиск пользователя в базе данных по имени
            var user = _context.User.FirstOrDefault(u => u.username == username);

            if (user == null)
                return false;

            // Сравниваем введённый пароль с сохранённым в базе
            return user.password == password;
        }

        // Получаем роль пользователя по имени пользователя
        private string GetUserRole(string username)
        {
            var user = _context.User.FirstOrDefault(u => u.username == username);
            return user?.role ?? "Клиент";  // По умолчанию возвращаем роль "Клиент", если пользователь не найден
        }
    }
}

using System;
using System.Windows;
using AutomatedInformationSystem;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutomatedInformationSystem
{
    public partial class RegisterWindow : Window
    {
        private readonly AppDbContext _context;

        public RegisterWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();  // Инициализация контекста базы данных
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

        // Метод для обработки регистрации пользователя
        // Метод для обработки регистрации пользователя
        private void SubmitRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;  // Теперь берем пароль как текст

            if (RegisterUser(username, password))
            {
                // Если регистрация прошла успешно, показываем сообщение
                MessageBox.Show("Регистрация прошла успешно!");

                // Переход в главное окно в зависимости от роли пользователя
                string role = GetUserRole(username); // Получаем роль только что зарегистрированного пользователя
                if (role == "Клиент")
                {
                    // Открываем окно для клиента
                    ClientWindow clientWindow = new ClientWindow();
                    clientWindow.Show();
                }
                else if (role == "Сотрудник")
                {
                    // Открываем окно для сотрудника
                    EmployeeWindow employeeWindow = new EmployeeWindow();
                    employeeWindow.Show();
                }

                // Закрываем окно регистрации
                Close();
            }
            else
            {
                // Если пользователь с таким именем уже существует
                MessageBox.Show("Пользователь с таким именем уже существует.");
            }
        }

// Логика получения роли пользователя по имени
        private string GetUserRole(string username)
        {
            var user = _context.User.FirstOrDefault(u => u.username == username);
            return user?.role ?? "Клиент";  // По умолчанию возвращаем "Клиент", если роль не найдена
        }


        // Логика регистрации нового пользователя
        private bool RegisterUser(string username, string password)
        {
            // Проверка, существует ли уже пользователь с таким именем
            var existingUser = _context.User.FirstOrDefault(u => u.username == username);

            if (existingUser != null)
            {
                // Если такой пользователь уже есть, возвращаем false
                return false;
            }

            // Получаем выбранную роль из RadioButton
            string role = "Клиент"; // Роль по умолчанию
            if (EmployeeRadioButton.IsChecked == true)
            {
                role = "Сотрудник";
            }
            
            var newUser = new User
            {
                username = username,
                password = password,  
                role = role           
            };
            _context.User.Add(newUser);
            _context.SaveChanges();

            return true;
        }
    }
}

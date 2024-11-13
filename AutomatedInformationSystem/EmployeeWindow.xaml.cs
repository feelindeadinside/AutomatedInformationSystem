using System.Linq;
using System.Windows;

namespace AutomatedInformationSystem
{
    public partial class EmployeeWindow : Window
    {
        private readonly AppDbContext _context;

        public EmployeeWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _context.Database.EnsureCreated(); // Убедимся, что база данных создана
        }

        // Обработчик для кнопки "Посмотреть товары"
        private void ViewProductsButton_Click(object sender, RoutedEventArgs e)
        {
            // Скрываем все панели
            HideAllPanels();

            // Получаем список товаров
            var products = _context.Products.ToList();
            string productList = string.Join("\n", products.Select(p => $"{p.product_id}: {p.name} - {p.price} руб."));
            ProductListTextBlock.Text = productList;
            ProductListPanel.Visibility = Visibility.Visible;
        }

        // Обработчик для кнопки "Добавить товары"
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Скрываем все панели
            HideAllPanels();

            // Показываем панель для ввода данных
            InputPanel.Visibility = Visibility.Visible;
        }

        // Обработчик для кнопки "Редактировать товары"
        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Скрываем все панели
            HideAllPanels();

            // Заполняем ComboBox с товарами для редактирования
            ProductComboBox.ItemsSource = _context.Products.ToList();
            ProductComboBox.DisplayMemberPath = "name";
            ProductComboBox.SelectedValuePath = "product_id";
            EditPanel.Visibility = Visibility.Visible;
        }

        // Обработчик для кнопки "Удалить товары"
        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            
            var products = _context.Products.ToList();
            DeleteProductComboBox.ItemsSource = products;
            DeleteProductComboBox.DisplayMemberPath = "name";
            DeleteProductComboBox.SelectedValuePath = "product_id";

            DeletePanel.Visibility = Visibility.Visible;
        }

        // Обработчик для выполнения удаления товара
        private void DeleteProductButton_Click_Confirm(object sender, RoutedEventArgs e)
        {
            var selectedProductId = (int)DeleteProductComboBox.SelectedValue;

            // Находим товар в базе данных
            var productToDelete = _context.Products.FirstOrDefault(p => p.product_id == selectedProductId);

            if (productToDelete != null)
            {
                // Удаляем товар из базы данных
                _context.Products.Remove(productToDelete);
                _context.SaveChanges(); // Сохраняем изменения в базе данных

                MessageBox.Show("Товар удален!", "Успех");

                // Скрываем панели после удаления
                HideAllPanels();
            }
            else
            {
                MessageBox.Show("Товар не найден!", "Ошибка");
            }
        }


        // Обработчик для сохранения нового товара
        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product
            {
                name = ProductNameTextBox.Text,
                price = double.Parse(ProductPriceTextBox.Text),
                expiration_date = ProductExpirationDatePicker.SelectedDate
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            MessageBox.Show("Товар добавлен!", "Успех");
            HideAllPanels();
        }

        // Обработчик для редактирования товара
        private void EditProductSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var productId = (int)ProductComboBox.SelectedValue;
            var product = _context.Products.FirstOrDefault(p => p.product_id == productId);
            if (product != null)
            {
                product.price = double.Parse(EditProductPriceTextBox.Text);
                _context.SaveChanges();
                MessageBox.Show("Товар обновлен!", "Успех");
            }
            HideAllPanels();
        }

        // Метод для скрытия всех панелей
        private void HideAllPanels()
        {
            InputPanel.Visibility = Visibility.Collapsed;
            EditPanel.Visibility = Visibility.Collapsed;
            DeletePanel.Visibility = Visibility.Collapsed;
            ProductListPanel.Visibility = Visibility.Collapsed;
        }
    }
}

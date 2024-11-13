using System.Linq;
using System.Windows;

namespace AutomatedInformationSystem
{
    public partial class ClientWindow : Window
    {
        private readonly AppDbContext _context;

        public ClientWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
        }

        // Обработчик для кнопки "Посмотреть товары"
        private void ViewProductsButton_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            var products = _context.Products.ToList();
            string productList = string.Join("\n", products.Select(p => $"{p.product_id}: {p.name} - {p.price} руб."));
            ProductListTextBlock.Text = productList;
            ProductListPanel.Visibility = Visibility.Visible;
        }

        // Обработчик для кнопки "Создать продажу"
        private void CreateSaleButton_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            ProductComboBox.ItemsSource = _context.Products.ToList();
            ProductComboBox.DisplayMemberPath = "name";
            ProductComboBox.SelectedValuePath = "product_id";
            CreateSalePanel.Visibility = Visibility.Visible;
        }

        // Обработчик для кнопки "Посмотреть продажи"
        private void ViewSalesButton_Click(object sender, RoutedEventArgs e)
        {
            HideAllPanels();
            var sales = _context.Sales.ToList();
            string salesList = string.Join("\n", sales.Select(s => 
                $"Продажа ID: {s.sales_id}, Товар: {s.Product.name}, Количество: {s.quantity}, Клиент: {s.Customer.name}, Цена: {s.Product.price * s.quantity} руб."));
            SalesListTextBlock.Text = salesList;
            SalesListPanel.Visibility = Visibility.Visible;
        }

        // Обработчик для сохранения продажи
        private void SaveSaleButton_Click(object sender, RoutedEventArgs e)
        {
            var productId = (int)ProductComboBox.SelectedValue;
            var product = _context.Products.FirstOrDefault(p => p.product_id == productId);
            if (product != null && int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                // Получаем текущего клиента и пользователя
                var currentCustomer = _context.Customers.FirstOrDefault(c => c.customer_id == 1); // Предполагаем, что клиент с id=1
                var currentUser = _context.User.FirstOrDefault(u => u.user_id == 1); // Предполагаем, что пользователь с id=1

                var sale = new Sales
                {
                    product_id = productId,
                    customer_id = currentCustomer.customer_id,
                    user_id = currentUser.user_id,
                    quantity = quantity,
                    sale_date = DateTime.Now
                };

                _context.Sales.Add(sale);
                _context.SaveChanges();
                MessageBox.Show("Продажа создана!", "Успех");
            }
            else
            {
                MessageBox.Show("Ошибка при создании продажи!", "Ошибка");
            }

            HideAllPanels();
        }

        // Метод для скрытия всех панелей
        private void HideAllPanels()
        {
            ProductListPanel.Visibility = Visibility.Collapsed;
            CreateSalePanel.Visibility = Visibility.Collapsed;
            SalesListPanel.Visibility = Visibility.Collapsed;
        }
    }
}

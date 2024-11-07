using System;
using System.Data.SQLite;

namespace AutomatedInformationSystem
{
    public class DatabaseInitializer
    {
        private const string DatabaseFilePath = "store.db";

        public static void InitializeDatabase()
        {
            if (!System.IO.File.Exists(DatabaseFilePath))
            {
                SQLiteConnection.CreateFile(DatabaseFilePath);
                Console.WriteLine("База данных создана.");
            }

            using (var connection = new SQLiteConnection($"Data Source={DatabaseFilePath};Version=3;"))
            {
                connection.Open();

                // Таблица User
                string createUserTable = @"
                    CREATE TABLE IF NOT EXISTS User (
                        user_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        username TEXT NOT NULL UNIQUE,
                        password TEXT NOT NULL,
                        role TEXT NOT NULL CHECK (role IN ('Клиент', 'Сотрудник'))
                    );";

                // Таблица Product
                string createProductTable = @"
                    CREATE TABLE IF NOT EXISTS Product (
                        product_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        name TEXT NOT NULL,
                        price REAL NOT NULL,
                        expiration_date DATE
                    );";

                // Таблица Customer
                string createCustomerTable = @"
                    CREATE TABLE IF NOT EXISTS Customer (
                        customer_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        name TEXT NOT NULL,
                        phone TEXT,
                        email TEXT
                    );";

                // Таблица Sales
                string createSalesTable = @"
                    CREATE TABLE IF NOT EXISTS Sales (
                        sales_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        product_id INTEGER NOT NULL,
                        customer_id INTEGER NOT NULL,
                        user_id INTEGER NOT NULL,
                        quantity INTEGER NOT NULL,
                        sale_date DATE NOT NULL,
                        FOREIGN KEY (product_id) REFERENCES Product (product_id) ON DELETE CASCADE,
                        FOREIGN KEY (customer_id) REFERENCES Customer (customer_id) ON DELETE CASCADE,
                        FOREIGN KEY (user_id) REFERENCES User (user_id) ON DELETE SET NULL
                    );";

                // Выполнение SQL команд для создания таблиц
                ExecuteNonQuery(createUserTable, connection);
                ExecuteNonQuery(createProductTable, connection);
                ExecuteNonQuery(createCustomerTable, connection);
                ExecuteNonQuery(createSalesTable, connection);

                connection.Close();
                Console.WriteLine("База данных и таблицы успешно инициализированы.");
            }
        }

        private static void ExecuteNonQuery(string commandText, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(commandText, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}

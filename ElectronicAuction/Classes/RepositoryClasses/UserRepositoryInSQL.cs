using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Classes.UserClasses;
using System.Data.SqlClient;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class UserRepositoryInSQL: RepositoryInSQL, IUserRepository 
    {
        public UserRepositoryInSQL(string connectionString) : base(connectionString) { } //конструктор класса

        public IUser GetUser(int id) {
            IUser user = null;
            // Подготовьте SQL-запрос для получения информации о пользователе по идентификатору
            string query = "SELECT Name, Email, Password FROM Users WHERE Id = @Id";
            // Устанавливаем соединение с SQL Server
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Открываем соединение
                connection.Open();
                // Создаём объект команды с запросом и соединением
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавляем параметр для UserId
                    command.Parameters.AddWithValue("@Id", id);
                    // Выполнение команды для получения информации о пользователе
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Проверяем, существует ли пользователь с указанным идентификатором
                        if (reader.Read())
                        {
                            // Получаем данные о пользователе из результата SQL-запроса
                            user = new User(id, reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString());
                        }
                        // Закрываем считыватель
                        reader.Close();
                    }
                }
            }

            return user;
        } //получение пользователя по его id

        public IUser GetUser(string email, string password)
        {
            string query = "SELECT Id, Name FROM Users WHERE Email = @Email AND Password = @Password";
            IUser user = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // если пользователь с такими почтой и паролем найден
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0); // Преобразование Id в int
                            user = new User(userId, reader["Name"].ToString(), email, password);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return user;
        } //получение пользователя по его email и паролю - т.е. то же самое что функция логина

        public void AddUser(IUser user) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)";
                // Открываем соединение
                connection.Open();
                // Создаем объект команды с запросом и соединением
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавляем параметры в запрос
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Email", user.GetEmail());
                    command.Parameters.AddWithValue("@Password", user.GetPassword());
                    try
                    {
                        // Выполнение команды (вставка пользователя в базу данных)
                        command.ExecuteNonQuery();
                        Console.WriteLine("Вы успешно зарегистрированы в системе.");
                    }
                    catch (SqlException ex)
                    {
                        // Обработка SQL-исключений
                        Console.WriteLine("Ошибка при добавлении пользователя в базу данных: " + ex.Message);
                    }
                }
            }

        } //добавление пользователя в базу

        public List<IUser> GetAllUsers()
        {
            List<IUser> users = new List<IUser>();

            // Подготовка SQL-запроса для получения всех пользователей
            string query = "SELECT Id, Name, Email, Password FROM Users";

            // Установка соединения с SQL Server
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Открытие соединения
                connection.Open();

                // Создание объекта команды с запросом и соединением
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Выполнение команды для получения информации о пользователях
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Чтение данных о пользователях
                        while (reader.Read())
                        {
                            // Получение данных о пользователе из результата SQL-запроса
                            int id = reader.GetInt32(0);
                            string name = reader["Name"].ToString();
                            string email = reader["Email"].ToString();
                            string password = reader["Password"].ToString();

                            // Создание объекта пользователя и добавление его в список
                            IUser user = new User(id, name, email, password);
                            users.Add(user);
                        }
                        // Закрытие считывателя
                        reader.Close();
                    }
                }
            }

            return users;
        } // получение инфы о всех пользователях
    }
}

using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Classes.AuctionClasses;
using System.Data.SqlClient;


namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class BidRepositoryInSQL: RepositoryInSQL, IBidRepository
    {
        public BidRepositoryInSQL(string connectionString) : base(connectionString) { } //конструктор класса
        public IBid GetBid(int id)
        {
            IBid bid = null;

            // Подготовка SQL-запроса для получения информации о ставке по идентификатору
            string query = "SELECT UserId, Amount FROM Bids WHERE Id = @Id";

            // Установка соединения с SQL Server
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Открытие соединения
                connection.Open();

                // Создание объекта команды с запросом и соединением
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавление параметра для идентификатора ставки
                    command.Parameters.AddWithValue("@Id", id);

                    // Выполнение команды для получения информации о ставке
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Проверка, существует ли ставка с указанным идентификатором
                        if (reader.Read())
                        {
                            // Получение данных о ставке из результата SQL-запроса
                            bid = new Bid(id, reader.GetInt32(0), reader.GetInt32(1));
                        }
                        // Закрытие считывателя
                        reader.Close();
                    }
                }
            }

            return bid;
        } //метод получения ставки по id

        public void AddBid(IBid bid, int auctionId) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Bids (AuctionId, UserId, Amount) VALUES (@AuctionId, @UserId, @Amount)";
                // Открываем соединение
                connection.Open();

                // Создаем объект команды с запросом и соединением
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавляем параметры в запрос
                    //command.Parameters.AddWithValue("@BidId", bid.BidId);
                    command.Parameters.AddWithValue("@AuctionId", auctionId);
                    command.Parameters.AddWithValue("@UserId", bid.UserId);
                    command.Parameters.AddWithValue("@Amount", bid.Amount);

                    try
                    {
                        // Выполнение команды (вставка пользователя в базу данных)
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Обработка SQL-исключений
                        Console.WriteLine("Ошибка при добавлении ставки: " + ex.Message);
                    }
                }
            }
        } //метод добавления ставки в базу данных
    }
}

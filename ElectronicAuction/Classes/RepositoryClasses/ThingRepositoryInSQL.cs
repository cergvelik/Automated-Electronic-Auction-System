using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class ThingRepositoryInSQL: RepositoryInSQL, IThingRepository
    {
        public ThingRepositoryInSQL(string connectionString) : base(connectionString) { } //конструктор класса

        public IThing GetThing(int ThingId) { return null; }

        public void AddThing(IThing thing, int auctionId) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Things (AuctionId, Name) VALUES (@AuctionId, @Name)";
                // Открываем соединение
                connection.Open();

                // Создаем объект команды с запросом и соединением
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавляем параметры в запрос
                    command.Parameters.AddWithValue("@AuctionId", auctionId);
                    command.Parameters.AddWithValue("@Name", thing.Title);

                    try
                    {
                        // Выполнение команды (вставка пользователя в базу данных)
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Обработка SQL-исключений
                        Console.WriteLine("Ошибка при добавлении вещи: " + ex.Message);
                    }
                }
            }
        }
    }
}

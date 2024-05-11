using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Classes.AuctionClasses;
using System.Data.SqlClient;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class AuctionRepositoryInSQL:IAuctionRepository
    {
        private readonly string _connectionString;

        public AuctionRepositoryInSQL(string connectionString) 
        {
            _connectionString = connectionString;
        } //конструктор класса

        public void AddAuctionWithBid(IAuctionWithBid auction)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Auctions (CreatorId, StartTime, EndTime) VALUES (@AuctionCreator, @StartDate, @EndDate); SELECT SCOPE_IDENTITY();";                // Открываем соединение
                connection.Open();

                // Создаем объект команды с запросом и соединением
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавляем параметры в запрос
                    //command.Parameters.AddWithValue("@AuctionId", auction.AuctionId);
                    command.Parameters.AddWithValue("@AuctionCreator", auction.AuctionCreator.UserId);
                    command.Parameters.AddWithValue("@StartDate", auction.StartDate);
                    command.Parameters.AddWithValue("@EndDate", auction.EndDate);

                    try
                    {
                        // Выполнение команды (вставка аукциона в базу данных и получение AuctionId)
                        int auctionId = Convert.ToInt32(command.ExecuteScalar());

                        // Устанавливаем полученный AuctionId в объект auction
                        if (auctionId > 0) // Проверяем, что AuctionId получено корректно
                        {
                            // Приведем auction к типу Auction, чтобы установить AuctionId
                            if (auction is Auction concreteAuction)
                            {
                                //concreteAuction = new Auction(auctionId, auction.AuctionCreator, auction.StartDate, auction.EndDate);
                                concreteAuction = AuctionCreating.CreateAuctionWithBid(auctionId, auction.Things, auction.AuctionCreator);
                                //auction = concreteAuction;
                                Console.WriteLine($"Аукцион успешно создан. AuctionId: {auctionId}");
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Обработка SQL-исключений
                        Console.WriteLine("Ошибка при добавлении аукциона со ставками: " + ex.Message);
                    }
                }
            }

        } //добавление аукциона со ставкой в базу данных

        public void ReturnAuctionWithBid(int id, IAuctionWithBid auction) { } //обновление аукциона со ставкой в базе

        public IAuctionWithBid GetAuctionWithBid(int id) { return null; } //получение аукциона со ставкой из базы

        public List<IAuction> GetAllAuctions() { return null; }

        public List<IAuctionWithBid> GetAllAuctionsWithBid() { return null; } //получение списка всех аукционов со ставкой
    }
}

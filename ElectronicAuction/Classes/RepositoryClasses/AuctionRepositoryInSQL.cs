using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Classes.AuctionClasses;
using System.Data.SqlClient;

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
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Auctions (AuctionId, StartDate, EndDate, AuctionCreator) VALUES (@AuctionId, @StartDate, @EndDate, @AuctionCreator)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AuctionId", auction.AuctionId);
                command.Parameters.AddWithValue("@StartDate", auction.StartDate);
                command.Parameters.AddWithValue("@EndDate", auction.EndDate);
                command.Parameters.AddWithValue("@AuctionCreator", auction.AuctionCreator);
                // ещо
                command.ExecuteNonQuery();
            }
        } //добавление аукциона со ставкой в базу данных

        public void ReturnAuctionWithBid(int id, IAuctionWithBid auction) { } //обновление аукциона со ставкой в базе

        public IAuctionWithBid GetAuctionWithBid(int id) { return null; } //получение аукциона со ставкой из базы

        public List<IAuction> GetAllAuctions() { return null; }

        public List<IAuctionWithBid> GetAllAuctionsWithBid() { return null; } //получение списка всех аукционов со ставкой
    }
}

using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Classes.AuctionClasses;
using System.Data.SqlClient;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces.UserInterfaces;
using System.Collections.Generic;
using ElectronicAuction.Interfaces;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class AuctionRepositoryInSQL : RepositoryInSQL, IAuctionRepository
    {
        public AuctionRepositoryInSQL(string connectionString) : base(connectionString) { } //конструктор класса

        public int AddAuctionWithBid(IAuctionWithBid auction)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Auctions (CreatorId, StartTime, EndTime) VALUES (@AuctionCreator, @StartDate, @EndDate); SELECT SCOPE_IDENTITY();"; // Открываем соединение
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
                                concreteAuction = AuctionCreating.CreateAuctionWithBid(auctionId, auction.Things, auction.AuctionCreator);
                                return auctionId;
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
            return 0;

        } //добавление аукциона со ставкой в базу данных

        public void ReturnAuctionWithBid(int id, IAuctionWithBid auction)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Обновление информации об аукционе
                string auctionUpdateQuery = "UPDATE Auctions SET CreatorId = @AuctionCreator, StartTime = @StartDate, EndTime = @EndDate WHERE AuctionId = @AuctionId";
                using (SqlCommand auctionUpdateCommand = new SqlCommand(auctionUpdateQuery, connection))
                {
                    auctionUpdateCommand.Parameters.AddWithValue("@AuctionId", id);
                    auctionUpdateCommand.Parameters.AddWithValue("@AuctionCreator", auction.AuctionCreator.UserId);
                    auctionUpdateCommand.Parameters.AddWithValue("@StartDate", auction.StartDate);
                    auctionUpdateCommand.Parameters.AddWithValue("@EndDate", auction.EndDate);
                    auctionUpdateCommand.ExecuteNonQuery();
                }

                // Получение списка существующих ставок из базы данных
                string selectBidsQuery = "SELECT BidId, UserId, Amount FROM Bids WHERE AuctionId = @AuctionId";
                var existingBids = new List<IBid>();
                using (SqlCommand selectBidsCommand = new SqlCommand(selectBidsQuery, connection))
                {
                    selectBidsCommand.Parameters.AddWithValue("@AuctionId", id);
                    using (SqlDataReader reader = selectBidsCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int bidId = reader.GetInt32(0);
                            int userId = reader.GetInt32(1);
                            decimal amount = reader.GetDecimal(2);
                            existingBids.Add(new Bid(bidId, userId, amount));
                        }
                    }
                }

                // Вставка новых ставок, которых нет в существующих
                string insertBidQuery = "INSERT INTO Bids (AuctionId, UserId, Amount) VALUES (@AuctionId, @UserId, @Amount)";
                foreach (var bid in auction.Bids)
                {
                    // Проверка, существует ли уже такая ставка в базе данных
                    bool exists = existingBids.Any(existingBid =>
                        existingBid.UserId == bid.UserId && existingBid.Amount == bid.Amount);

                    if (!exists)
                    {
                        using (SqlCommand insertBidCommand = new SqlCommand(insertBidQuery, connection))
                        {
                            insertBidCommand.Parameters.AddWithValue("@AuctionId", id);
                            insertBidCommand.Parameters.AddWithValue("@UserId", bid.UserId);
                            insertBidCommand.Parameters.AddWithValue("@Amount", bid.Amount);
                            insertBidCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public IAuctionWithBid GetAuctionWithBid(int id) {

            AuctionWithBid auction = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string auctionQuery = "SELECT AuctionId, CreatorId FROM Auctions WHERE AuctionId = @AuctionId";
                string thingsQuery = "SELECT ThingId, AuctionId, Name FROM Things WHERE AuctionId = @AuctionId";
                string userQuery = "SELECT Name FROM Users WHERE Id = @UserId";
                string bidsQuery = "SELECT BidId, AuctionId, UserId, Amount FROM Bids WHERE AuctionId = @AuctionId";

                connection.Open();

                using (SqlCommand auctionCommand = new SqlCommand(auctionQuery, connection))
                {
                    auctionCommand.Parameters.AddWithValue("@AuctionId", id);

                    try
                    {
                        using (SqlDataReader auctionReader = auctionCommand.ExecuteReader())
                        {
                            if (auctionReader.Read())
                            {
                                int auctionId = auctionReader.GetInt32(0);
                                int creatorId = auctionReader.GetInt32(1);

                                string creatorName = string.Empty;
                                using (SqlCommand userCommand = new SqlCommand(userQuery, connection))
                                {
                                    userCommand.Parameters.AddWithValue("@UserId", creatorId);
                                    using (SqlDataReader userReader = userCommand.ExecuteReader())
                                    {
                                        if (userReader.Read())
                                        {
                                            creatorName = userReader.GetString(0);
                                        }
                                    }
                                }

                                IUser user = new User(creatorId, creatorName);

                                List<IThing> thingsList = new List<IThing>();

                                using (SqlCommand thingsCommand = new SqlCommand(thingsQuery, connection))
                                {
                                    thingsCommand.Parameters.AddWithValue("@AuctionId", auctionId);

                                    using (SqlDataReader thingsReader = thingsCommand.ExecuteReader())
                                    {
                                        while (thingsReader.Read())
                                        {
                                            int thingId = thingsReader.GetInt32(0);
                                            string thingName = thingsReader.GetString(2);

                                            Thing thing = new Thing(thingId, thingName);

                                            thingsList.Add(thing);
                                        }
                                    }
                                }

                                auction = AuctionCreating.CreateAuctionWithBid(auctionId, thingsList, user);

                                using (SqlCommand bidsCommand = new SqlCommand(bidsQuery, connection))
                                {
                                    bidsCommand.Parameters.AddWithValue("@AuctionId", auctionId);

                                    using (SqlDataReader bidsReader = bidsCommand.ExecuteReader())
                                    {
                                        List<IBid> bidsList = new List<IBid>();

                                        while (bidsReader.Read())
                                        {
                                            int bidId = bidsReader.GetInt32(0);
                                            int userId = bidsReader.GetInt32(2);
                                            decimal amount = bidsReader.GetDecimal(3);

                                            // Получаем информацию о пользователе (для участника ставки)
                                            string bidderName = string.Empty;
                                            using (SqlCommand userCommand = new SqlCommand(userQuery, connection))
                                            {
                                                userCommand.Parameters.AddWithValue("@UserId", userId);
                                                using (SqlDataReader userReader = userCommand.ExecuteReader())
                                                {
                                                    if (userReader.Read())
                                                    {
                                                        bidderName = userReader.GetString(0);
                                                    }
                                                }
                                            }

                                            IBid bid = new Bid(userId, amount);

                                            bidsList.Add(bid);
                                        }

                                        // Добавляем список ставок в аукцион
                                        auction.Bids = bidsList;
                                    }
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Ошибка при получении аукциона: " + ex.Message);
                    }
                }
            }
            return auction;
        } //получение аукциона со ставкой из базы

        public List<IAuction> GetAllAuctions() { return null; }

        public List<IAuctionWithBid> GetAllAuctionsWithBid()
        {
            List<IAuctionWithBid> auctionsList = new List<IAuctionWithBid>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string auctionQuery = "SELECT AuctionId, CreatorId FROM Auctions";
                string thingsQuery = "SELECT ThingId, AuctionId, Name FROM Things WHERE AuctionId = @AuctionId";
                string userQuery = "SELECT Name FROM Users WHERE Id = @UserId";
                string bidsQuery = "SELECT BidId, AuctionId, UserId, Amount FROM Bids WHERE AuctionId = @AuctionId";

                connection.Open();

                using (SqlCommand auctionCommand = new SqlCommand(auctionQuery, connection))
                {
                    try
                    {
                        using (SqlDataReader auctionReader = auctionCommand.ExecuteReader())
                        {
                            while (auctionReader.Read())
                            {
                                int auctionId = auctionReader.GetInt32(0);
                                int creatorId = auctionReader.GetInt32(1);

                                string creatorName = string.Empty;
                                using (SqlCommand userCommand = new SqlCommand(userQuery, connection))
                                {
                                    userCommand.Parameters.AddWithValue("@UserId", creatorId);
                                    using (SqlDataReader userReader = userCommand.ExecuteReader())
                                    {
                                        if (userReader.Read())
                                        {
                                            creatorName = userReader.GetString(0);
                                        }
                                    }
                                }

                                IUser user = new User(creatorId, creatorName);

                                List<IThing> thingsList = new List<IThing>();

                                using (SqlCommand thingsCommand = new SqlCommand(thingsQuery, connection))
                                {
                                    thingsCommand.Parameters.AddWithValue("@AuctionId", auctionId);

                                    using (SqlDataReader thingsReader = thingsCommand.ExecuteReader())
                                    {
                                        while (thingsReader.Read())
                                        {
                                            int thingId = thingsReader.GetInt32(0);
                                            string thingName = thingsReader.GetString(2);

                                            Thing thing = new Thing(thingId, thingName);

                                            thingsList.Add(thing);
                                        }
                                    }
                                }

                                var auction = AuctionCreating.CreateAuctionWithBid(auctionId, thingsList, user);
                                auctionsList.Add(auction);

                                using (SqlCommand bidsCommand = new SqlCommand(bidsQuery, connection))
                                {
                                    bidsCommand.Parameters.AddWithValue("@AuctionId", auctionId);

                                    using (SqlDataReader bidsReader = bidsCommand.ExecuteReader())
                                    {
                                        List<IBid> bidsList = new List<IBid>();

                                        while (bidsReader.Read())
                                        {
                                            int bidId = bidsReader.GetInt32(0);
                                            int userId = bidsReader.GetInt32(2);
                                            decimal amount = bidsReader.GetDecimal(3);

                                            // Получаем информацию о пользователе (для участника ставки)
                                            string bidderName = string.Empty;
                                            using (SqlCommand userCommand = new SqlCommand(userQuery, connection))
                                            {
                                                userCommand.Parameters.AddWithValue("@UserId", userId);
                                                using (SqlDataReader userReader = userCommand.ExecuteReader())
                                                {
                                                    if (userReader.Read())
                                                    {
                                                        bidderName = userReader.GetString(0);
                                                    }
                                                }
                                            }
                                            IBid bid = new Bid(userId, amount);

                                            bidsList.Add(bid);
                                        }

                                        // Добавляем список ставок в аукцион
                                        auction.Bids = bidsList;
                                    }
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Ошибка при получении списка аукционов: " + ex.Message);
                    }
                }
            }

            return auctionsList;
        }
    }
}

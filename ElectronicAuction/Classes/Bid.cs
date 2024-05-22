using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;


namespace ElectronicAuction.Classes
{
    public class Bid:IBid
    {
        private static int _id = 0; 
        public int BidId { get; } //уникальное Id ставки
        public int UserId { get; } //Id Пользователя ставки
        public decimal Amount { get; private set; } //величина ставки

        public Bid( int userId, decimal amount) { 
            BidId = ++_id; 
            UserId = userId; 
            Amount = amount; 
        }
        public Bid(int id, int userId, decimal amount) { 
            BidId = id; 
            UserId = userId; 
            Amount = amount; 
        }
    }
}

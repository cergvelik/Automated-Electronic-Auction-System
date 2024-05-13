using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Classes.UserClasses;

namespace ElectronicAuction.Classes.AuctionClasses
{
    public abstract class Auction //пришлось все-таки использовать абстрактный класс чтобы создавать уникальный id аукциона
    {
        private static int _id = 10000;
        public int AuctionId { get; } //Уникальное Id аукциона

        public DateTime StartDate { get; } //Дата начала аукциона
        public DateTime EndDate { get; } //Дата окончания аукциона

        public IUser AuctionCreator { get; }//Создатель аукциона 

        protected Auction(IUser Creator, DateTime startTime, DateTime endDate )
        {
            AuctionId = ++_id;
            StartDate = startTime;
            EndDate = endDate;
            AuctionCreator = Creator;
        }        
        protected Auction(int id, IUser Creator, DateTime startTime, DateTime endDate )
        {
            AuctionId = id;
            StartDate = startTime;
            EndDate = endDate;
            AuctionCreator = Creator;
        }
        protected bool _isAuctionClosed { get { if (DateTime.Now >= EndDate) return true; else return false; } }/*если сейчас время больше чем EndDate
                                                                                                                 * то аукцион завершен. Преобразовал 
                                                                                                                 * метод в свойство, потому-что так удобнее*/

    }
}

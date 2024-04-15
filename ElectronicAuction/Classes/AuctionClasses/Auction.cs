using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;


namespace ElectronicAuction.Classes.AuctionClasses
{
    abstract class Auction //пришлось все-таки использовать абстрактный класс чтобы создавать уникальный id аукциона
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

    }
}

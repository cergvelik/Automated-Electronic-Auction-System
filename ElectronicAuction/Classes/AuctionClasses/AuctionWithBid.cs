using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;


namespace ElectronicAuction.Classes.AuctionClasses
{
    class AuctionWithBid:Auction,IAuctionWithBid
    {
        public List<Bid> Bids { get; set; } //Список всех ставок
        public List<IThing> Things { get; } //Коллекция вещей на продажу, ставка делается на всю коллекцию
        //т.е. выкупаются все вещи

        public decimal PossibleBid
        {
            get
            {
                decimal bid = Bids.Last().Amount + Bids.Last().Amount * 0.05m;
                return bid;
            }
        } //Возможная ставка (должна превышать последнюю ставку на 5%)

        public AuctionWithBid(List<IThing> things, IUser Creator) : base(Creator) //Когда создается аукцион в лист ставок добавляется первая ставка-стартовая стоимость всех вещей
        {
            Things = things;
            Bids = new List<Bid>();

            decimal FirstBid = 0m;
            foreach(IThing price in things)
            {
                FirstBid += price.StartPrice;
            }
            Bids.Add(new Bid(Creator.UserId, FirstBid));
        }

        public void AddBid(IUser user, decimal amount)
        {
            if (amount < PossibleBid) { } //добавить ошибку если ставка меньше возможной ставки и если аукцион завершен
            else
            {
                Bids.Add(new Bid(user.UserId, amount));//иначе добавить ставку в аукцион
            }
        }
    }
}

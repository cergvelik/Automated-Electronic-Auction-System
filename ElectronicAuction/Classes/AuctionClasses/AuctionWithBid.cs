using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Classes.UserClasses;

namespace ElectronicAuction.Classes.AuctionClasses
{
    public class AuctionWithBid:Auction,IAuctionWithBid
    {
        public List<IBid> Bids { get; set; } //Список всех ставок
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

        public AuctionWithBid(List<IThing> things, IUser Creator, IBid FirstBid) : base(Creator, DateTime.Now, DateTime.Now.AddDays(14)) //Когда создается аукцион в лист ставок добавляется первая ставка-стартовая стоимость всех вещей
        //аукцион со ставкой длится 14 дней, создается в момент когда вы его создаете
        {
            Things = things;
            Bids = new List<IBid>();
            Bids.Add(FirstBid);
        }

        private bool _isBidValid(IBid bid)
        {
            return bid.Amount > PossibleBid;//если ставка больше предволагаемой ставки, то её можно размещать т.е. возвращаем true
        }
        
        public void AddBid(IBid bid)
        {
            if (!_isBidValid(bid) | _isAuctionClosed) //если что-то одно не соблюдено, то ставку разместить нельзя
            {
                //ошибка
                return;
            } 
            else
            {
                Bids.Add(bid);//иначе добавить ставку в аукцион
            }
        }
    }
}

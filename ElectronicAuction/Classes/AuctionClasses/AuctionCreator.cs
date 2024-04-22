using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.AuctionClasses
{
    internal class AuctionCreating
    {
        public IAuctionWithBid CreateAuctionWithBid(List<IThing> things, IUser user)//создатель аукциона со ставкой
        {
            decimal FirstBid = 0m;
            foreach (IThing price in things)
            {
                FirstBid += price.StartPrice;
            }
            AuctionWithBid auction = new AuctionWithBid(things, user, FirstBid);
            return auction;
        }
    }
}

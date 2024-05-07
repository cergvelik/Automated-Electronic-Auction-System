using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Classes.UserClasses;

namespace ElectronicAuction.Classes.AuctionClasses
{
    public class AuctionCreating
    {
        public  static AuctionWithBid CreateAuctionWithBid(List<IThing> things, IUser user)//создатель аукциона со ставкой
        {
            decimal FirstBid = 0m;
            foreach (IThing price in things)
            {
                FirstBid += price.StartPrice;
            }
            Bid bid = new Bid(user.UserId, FirstBid);
            AuctionWithBid auction = new AuctionWithBid(things, user, bid);
            return auction;
        }
    }
}

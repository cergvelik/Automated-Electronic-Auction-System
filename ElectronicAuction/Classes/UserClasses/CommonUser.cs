using System;
using ElectronicAuction;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;
using System;


namespace ElectronicAuction.Classes.UserClasses
{
	public class CommonUser:ICommonUser
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }

		private string _Email { get; set; }
		private string _Password { get; set; }

		public void CreateAuction() { }
		public void PlaceABet(IAuction Auction, IBid Bid) { }

	}
}

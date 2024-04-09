using System;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Classes.UserClasses
{
	class CommonUser:ICommonUser
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string _Email { get; set; }
		public string _Password { get; set; }

		public void CreateAuction() { }
		public void PlaceABet(IAuction Auction, IBid Bid) { }

	}
}

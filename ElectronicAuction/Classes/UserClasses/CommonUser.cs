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
		int UserId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		private string Email { get; set; }
		private string Password { get; set; }

		public void CreateAuction() { }
		public void PlaceABet(IAuction Auction, IBid Bid) { }

	}
}

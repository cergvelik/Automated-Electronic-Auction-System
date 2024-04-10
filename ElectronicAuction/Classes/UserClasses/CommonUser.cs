using System;
using ElectronicAuction;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;



namespace ElectronicAuction.Classes.UserClasses
{
	public class CommonUser:ICommonUser
	{
		private static int _id = 0;
		public int UserId { get; }
		public string Name { get; private set; }
		public string Surname { get; private set; }

		private string _email { get; set; }
		private string _password { get; set; }

		public CommonUser(string name, string surname, string email, string password)
		{
			UserId = ++_id;
			Name = name;
			Surname = surname;
			_email = email;
			_password = password;
		}

		public void CreateAuction() { }
		public void PlaceABet(IAuction Auction, IBid Bid) { }

	}
}

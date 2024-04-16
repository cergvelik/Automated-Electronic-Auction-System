using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Classes.UserClasses
{
    public class UserCreator
    {
        private static int _id = 1000;

        public User CreateUser(string name, string email, string password)
        {
            return new User(name, email, password)
            {
                UserId = ++_id
            };
        }
    }
}

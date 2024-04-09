using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces.UserInterfaces
{
    internal interface IUser
    {
        private int UserId { get; }
        string Name { get; }
        string Surname { get; }
        private string Email { get; }
        private string Password { get; }
    }
}

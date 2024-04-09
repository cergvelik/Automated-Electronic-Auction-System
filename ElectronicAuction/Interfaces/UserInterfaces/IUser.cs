using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces.UserInterfaces
{
    public interface IUser
    {
        int UserId { get; }
        string Name { get; }
        string Surname { get; }
        string _Email { get; }
        string _Password { get; } 
    }
}

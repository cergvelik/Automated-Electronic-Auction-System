using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Interfaces.ServicesInterfaces
{
    public interface IUserLoginService
    {
        IUser LoginUser(string email, string password);
    }
}

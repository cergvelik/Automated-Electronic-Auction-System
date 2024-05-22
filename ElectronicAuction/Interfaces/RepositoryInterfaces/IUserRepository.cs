using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Classes.UserClasses;


namespace ElectronicAuction.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        IUser GetUser(int id);
        IUser GetUser(string email, string password);

        void AddUser(IUser user);

        List<IUser> GetAllUsers();
    }
}

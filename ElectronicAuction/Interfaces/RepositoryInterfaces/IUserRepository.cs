using ElectronicAuction.Interfaces.UserInterfaces;


namespace ElectronicAuction.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        IUser GetUser(int id);

        void AddUser(IUser user);
    }
}

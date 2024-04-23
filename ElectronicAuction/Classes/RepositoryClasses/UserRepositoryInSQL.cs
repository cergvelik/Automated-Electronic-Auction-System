using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Classes.UserClasses;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class UserRepositoryInSQL:IUserRepository 
    {
        public UserRepositoryInSQL() { } //конструктор класса

        public IUser GetUser(int id) { return null; } //получение пользователя по его id

        public void AddUser(IUser user) { } //добавление пользователя в базу

        public List<IUser> GetAllUsers() { return null; }
    }
}

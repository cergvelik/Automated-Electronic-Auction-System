using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    internal class UserRepositoryInMemory:IUserRepository //класс репозитория пользователей в памяти(не SQL)
    {
        private readonly Dictionary<int, IUser> _users = new Dictionary<int, IUser>(); //словарь пользователей

        public IUser GetUser(int id) { return null; } //получение пользователя по его id

        public void AddUser(IUser user) { } //добавление пользователя в словарь


    }
}

using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Interfaces.ServicesInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.Services
{
    public class UserService
    {
        private readonly IUserCreateService _userCreateService;//класс отвечающий за создание и добавление пользователя в базу данных

        public UserService() { } //конструктор класса

        void CreateNewUser(IUser user) { _userCreateService.CreateUser(user); }
    }
}

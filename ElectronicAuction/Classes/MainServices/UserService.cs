using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Interfaces.ServicesInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Classes.UserClasses;

namespace ElectronicAuction.Classes.Services
{
    public class UserService
    {
        private readonly IUserCreateService _userCreateService;//класс отвечающий за создание и добавление пользователя в базу данных

        public UserService() { } //конструктор класса

        public void CreateNewUser(string name, string email, string password) {
            User user = new User(name, email, password);
            _userCreateService.CreateUser(user); }
    }
}

using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Interfaces.ServicesInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Classes.UserClasses;

namespace ElectronicAuction.Classes.MainServices
{
    public class UserService
    {
        private readonly IUserCreateService _userCreateService;//класс отвечающий за создание и добавление пользователя в базу данных
        private readonly IUserLoginService _userLoginService;//класс отвечающий за логин

        public UserService(IUserCreateService userCreateService, IUserLoginService userLoginService) { 
            _userCreateService = userCreateService; 
            _userLoginService = userLoginService; 
        } //конструктор класса

        public void CreateNewUser(string name, string email, string password) {
            User user = new User(name, email, password);
            _userCreateService.CreateUser(user); 
        }        
        
        public IUser LoginUser(string email, string password) {
            return _userLoginService.LoginUser(email, password); 
        }
    }
}

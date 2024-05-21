
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces.ServicesInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.SecondaryServices
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserRepository _userRepository;

        public UserLoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IUser LoginUser(string email, string password)
        {
            return _userRepository.GetUser(email, password);
        }
    }
}

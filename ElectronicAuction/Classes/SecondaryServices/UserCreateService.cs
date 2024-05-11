
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces.ServicesInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.SecondaryServices
{
    public class UserCreateService:IUserCreateService
    {
        private readonly IUserRepository _userRepository;

        public UserCreateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(IUser user) {
            _userRepository.AddUser(user);
        }
    }
}

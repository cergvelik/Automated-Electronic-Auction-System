
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.SecondaryServices
{
    public class UserCreateService
    {
        private readonly IUserRepository _userRepository;

        public UserCreateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        void CreateUser(IUser user) { }
    }
}

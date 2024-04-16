using ElectronicAuction.Interfaces.UserInterfaces;


namespace ElectronicAuction.Classes.UserClasses
{
	public class User:IUser
	{
        
        public string Name { get; } //никнейм пользователя

        public int UserId { get; set; }//уникальное Id пользователя

        private string _email { get; set; }
        private string _password { get; set; }

        public User(string name, string email, string password)
        {
            Name = name;
            _email = email;
            _password = password;
        }

        public static User Create(string name, string email, string password)
        {
            return new UserCreator().CreateUser(name, email, password);
        }

    }
}

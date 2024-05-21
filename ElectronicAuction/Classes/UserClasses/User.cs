using ElectronicAuction.Interfaces.UserInterfaces;


namespace ElectronicAuction.Classes.UserClasses
{
	public class User:IUser
	{
        private static int _id = 1000;

        public string Name { get; } //никнейм пользователя
        public int UserId { get; } //уникальное Id пользователя

        private string _email { get; set; }
        private string _password { get; set; }

        public User(string name, string email, string password)
        {
            UserId = ++_id;
            Name = name;
            _email = email;
            _password = password;
        }           
        
        public User(int id, string name)
        {
            UserId = id;
            Name = name;
            _email = null;
            _password = null;
        }        
        
        public User(int id, string name, string email, string password)
        {
            UserId = id;
            Name = name;
            _email = email;
            _password = password;
        }

        public string GetEmail()
        {
            return _email;
        }

        public string GetPassword()
        {
            return _password;
        }

    }
}

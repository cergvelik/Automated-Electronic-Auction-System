using ElectronicAuction.Classes.Account;


namespace ElectronicAuction
{
    internal class Program
    {
        // LAPTOP - B4VML6MR\SQLEXPRESS

        static void Main(string[] args)
        {
            ConsolePersonalAccount account = AccountCreator.CreateConsolePersonalAccount("");//строка подключения к БД
            account.InitializateAccount();//начало работы аккаунта
        }


    }

}
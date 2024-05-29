using ElectronicAuction.Classes.Account;
using ElectronicAuction.Classes.UserClasses;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ElectronicAuction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // название приложения в окне
            Console.Title = "Электронный аукцион";
            //строка подключения к БД
            string connectionString = 
                "Data Source=\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;MultipleActiveResultSets=True";
            ConsolePersonalAccount account = AccountCreator.CreateConsolePersonalAccount(connectionString);
            account.InitializateAccount();//начало работы аккаунта
        }
    }

}
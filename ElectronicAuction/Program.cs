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
            //строка подключения к БД
            string connectionString =
                "Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test3;Integrated Security=True;MultipleActiveResultSets=True";
            ConsolePersonalAccount account = AccountCreator.CreateConsolePersonalAccount(connectionString);
            account.InitializateAccount();//начало работы аккаунта
        }
    }

}
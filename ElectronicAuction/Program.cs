using ElectronicAuction.Classes.Account;
using ElectronicAuction.Classes.UserClasses;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ElectronicAuction
{
    internal class Program
    {
        // string connectionString = "Data Source= LAPTOP-B4VML6MR\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
        
        static void Main(string[] args)
        {
            ConsolePersonalAccount account = AccountCreator.CreateConsolePersonalAccount("Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True"); //строка подключения к БД
            account.InitializateAccount();//начало работы аккаунта
        }
    }

}
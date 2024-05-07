/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using ElectronicAuction.Classes.Account;
using ElectronicAuction.Classes.Services;
using ElectronicAuction.Interfaces.ServicesInterfaces;
using System.Data.SqlClient;

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
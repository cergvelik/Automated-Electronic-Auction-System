using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Classes.Services;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using System.Data.SqlClient;


namespace ElectronicAuction.Classes.Account
{
    internal class ConsolePersonalAccount
    {
        private IUser? _user;
        private AuctionService _auctionService;
        private UserService _userService;

        public ConsolePersonalAccount() // тест - удалить
        {
            _user = null;
            _auctionService = null;
            _userService = null;
        }
        public ConsolePersonalAccount(AuctionService AuctionService) // тест - удалить
        {
            _user = null;
            _auctionService = AuctionService;
            _userService = null;
        }
        public ConsolePersonalAccount(AuctionService AuctionService, UserService UserSercice)
        {
            _user = null;
            _auctionService = AuctionService;
            _userService = UserSercice;
        }

        public void InitializateAccount(string connectionString)
        {
            Console.WriteLine("--------Аккаунт--------\n");
            Console.WriteLine("Чтобы вы хотели сделать? 1-Войти в существующий аккаунт, 2-Зарегистрироваться");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input)) // Считывание информации с клавиатуры
            {
                Console.WriteLine("Ошибка ввода.");
                return; // или какая-то другая логика обработки ошибки
            };

            switch (input)
            {
                case 1:
                    AccountLogin(connectionString);
                    break;
                case 2:
                    AccountRegistration(connectionString);
                    break;
            }
        }

        public void AccountLogin(string connectionString)
        {
            Console.WriteLine("--------Вход--------\n");
            Console.WriteLine("Введите свой email: ");
            string? email = Console.ReadLine();// Считывание информации с клавиатуры
            Console.WriteLine("Введите свой пароль: ");
            string? password = Console.ReadLine();// Считывание информации с клавиатуры
            // Проверка не введена ли пустая строка

            string Hash = PasswordEncrypt.Encrypt(password);
            AccountMenu(connectionString);
        }

        public void AccountRegistration(string connectionString)
        {
            Console.WriteLine("--------Регистрация--------\n");
            Console.WriteLine("Введите своё имя: ");
            string? name = Console.ReadLine();// Считывание информации с клавиатуры
            Console.WriteLine("Введите email: ");
            string? email = Console.ReadLine();// Считывание информации с клавиатуры
            Console.WriteLine("Введите пароль: ");
            //тут ввод данных понятно дело
            string? password = Console.ReadLine();// Считывание информации с клавиатуры
            // Проверка не введена ли пустая строка

            string Hash = PasswordEncrypt.Encrypt(password);

            _userService.CreateNewUser(name, email, password);
            AccountLogin(connectionString);
        }

        public void AccountMenu(string connectionString)
        {
            Console.WriteLine("--------Меню--------\n");
            Console.WriteLine("Что бы вы хотели сделать? \n1-Создать аукцион, 2-Выставить ставку, \n3-Получить информацию о всех аукционах, 4-Получить информацию о конкретном аукционе");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input)) // Считывание информации с клавиатуры
            {
                Console.WriteLine("Ошибка ввода.");
                return; // или какая-то другая логика обработки ошибки
            };
            // Проверка не введена ли пустая строка

            switch (input)
            {
                case 1:
                    AuctionCreate(connectionString);
                    break;
                case 2:
                    PlaceBid(connectionString);
                    break;
                case 3:
                    PrintInfoAboutAllAuctions(connectionString);
                    break;
                case 4:
                    PrintInfoAboutAuction(connectionString);
                    break;
            }
        }

        public void AuctionCreate(string connectionString)
        {
            Console.WriteLine("--------Создание аукциона--------\n");
            Console.WriteLine("Что бы вы хотели сделать? 1-Создать аукцион со ставкой , 0-Выйти в меню");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input)) // Считывание информации с клавиатуры
            {
                Console.WriteLine("Ошибка ввода.");
                return; // или какая-то другая логика обработки ошибки
            };

            Console.WriteLine("Введите вещи. После окончания ввода нажмите 0.");
            string? password = Console.ReadLine();// Считывание информации с клавиатуры
            
            List<IThing> things = null; // пока что

            // Проверка не введена ли пустая строка
            switch (input)
            {
                case 1:
                    _auctionService.CreateAuctionWithBid(_user.UserId, things);
                    break;
                case 0:
                    AccountMenu(connectionString);
                    break;
            }
        }

        public void PlaceBid(string connectionString)
        {
            Console.WriteLine("--------Размещение ставки--------\n");
            Console.WriteLine("Чтобы вы хотели сделать? 1-Разместить ставку , 0-Выйти в меню");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input)) // Считывание информации с клавиатуры
            {
                Console.WriteLine("Ошибка ввода.");
                return; // или какая-то другая логика обработки ошибки
            };

            // Проверка не введена ли пустая строка
            switch (input)
            {
                case 1:
                    Console.WriteLine("Введите ID аукциона: ");
                    int auctionId;
                    if (!int.TryParse(Console.ReadLine(), out auctionId))
                    {
                        Console.WriteLine("Ошибка ввода ID аукциона.");
                        return; // или какая-то другая логика обработки ошибки
                    }

                    Console.WriteLine("Введите сумму: ");
                    decimal sum;
                    if (!decimal.TryParse(Console.ReadLine(), out sum))
                    {
                        Console.WriteLine("Ошибка ввода суммы.");
                        return; // или какая-то другая логика обработки ошибки
                    }
                    _auctionService.PlaceBid(_user.UserId, auctionId, sum);
                    break;
                case 0:
                    AccountMenu(connectionString);
                    break;
            }
        }

        public void PrintInfoAboutAllAuctions(string connectionString)
        {
            /*Console.WriteLine("Auctions:");
            Console.WriteLine("AuctionId | UserId | ThingId | Title | Description | StartPrice");
            Console.WriteLine("--------------------------------------------------------------");

            List<AuctionInfo> auctions = _auctionService.InfoAboutAllAuctions();
            foreach (var auction in auctions)
            {
                Console.WriteLine($"{auction.AuctionId,-10} | {auction.UserId,-7} | {auction.ThingId,-8} | {auction.Title,-20} | {auction.Description,-30} | {auction.StartPrice}");
            }*/
            
            
            /*Console.WriteLine("--------Информация о всех аукционах--------\n");
            List<AuctionInfo> info = _auctionService.InfoAboutAllAuctions();
            foreach (AuctionInfo auctionInfo in info)
            {
                Console.WriteLine(auctionInfo.ToString());
            }*/


            // //
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT a.AuctionId, a.UserId, t.ThingId, t.Title, t.Description, t.StartPrice " +
                               "FROM Auctions a " +
                               "INNER JOIN Things t ON a.AuctionId = t.AuctionId";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Аукционы:\n");
                Console.WriteLine($"{"auctionId",-10} | {"userId",-7} | {"thingId",-8} | {"название",-20} | {"описание",-40} | {"начальная цена"}");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");

                while (reader.Read())
                {
                    int auctionId = reader.GetInt32(0);
                    int userId = reader.GetInt32(1);
                    int thingId = reader.GetInt32(2);
                    string title = reader.GetString(3);
                    string description = reader.GetString(4);
                    decimal startPrice = reader.GetDecimal(5);

                    Console.WriteLine($"{auctionId,-10} | {userId,-7} | {thingId,-8} | {title,-20} | {description,-40} | {startPrice}");
                }
                Console.WriteLine("\n\n");
                reader.Close();
            }
        }
            public void PrintInfoAboutAuction(string connectionString)
            {
                Console.WriteLine("--------Информация о аукционе--------\n");
                Console.WriteLine("Чтобы вы хотели сделать? 1-Узнать информацию о аукционе , 0-Выйти в меню");
                int input;
                if (!int.TryParse(Console.ReadLine(), out input)) // Считывание информации с клавиатуры
                {
                    Console.WriteLine("Ошибка ввода.");
                    return; // или какая-то другая логика обработки ошибки
                };
                // Проверка не введена ли пустая строка
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Введите номер аукциона: ");
                        int number = Console.Read();// Считывание информации с клавиатуры
                                                    // Проверка не введена ли пустая строка
                        AuctionInfo info = _auctionService.InfoAboutAuction(connectionString, number);
                        Console.WriteLine(info.ToString());
                        break;
                    case 0:
                        AccountMenu(connectionString);
                        break;
                }
            }
        }
    } 

using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Classes.MainServices;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using System.Data.SqlClient;
using System.Security.Principal;


namespace ElectronicAuction.Classes.Account
{
    internal class ConsolePersonalAccount
    {
        private IUser? _user;
        private AuctionService _auctionService;
        private UserService _userService;

        public ConsolePersonalAccount(AuctionService AuctionService, UserService UserSercice)
        {
            _user = null;
            _auctionService = AuctionService;
            _userService = UserSercice;
        }

        public void InitializateAccount()
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
                    AccountLogin();
                    break;
                case 2:
                    AccountRegistration();
                    break;
            }
        }

        public void AccountLogin()
        {
            Console.WriteLine("--------Вход--------\n");
            Console.WriteLine("Введите свой email: ");
            string? email = Console.ReadLine();// Считывание информации с клавиатуры
            Console.WriteLine("Введите свой пароль: ");
            string? password = Console.ReadLine();// Считывание информации с клавиатуры
            // Проверка не введена ли пустая строка

            _user = _userService.LoginUser(email, password); // логин
            Console.WriteLine($"Добро пожаловать, {_user.Name}!");
            //string Hash = PasswordEncrypt.Encrypt(password);

            AccountMenu();
        }
        public void AccountLogin(string email,string password)
        {
            _user = _userService.LoginUser(email, password); // логин
            Console.WriteLine($"Добро пожаловать, {_user.Name}!");
            //string Hash = PasswordEncrypt.Encrypt(password);

            AccountMenu();
        }

        public void AccountRegistration()
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
            AccountLogin();
        }

        public void AccountMenu()
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
                    AuctionCreate();
                    break;
                case 2:
                    PlaceBid();
                    break;
                case 3:
                    PrintInfoAboutAllAuctions();
                    break;
                case 4:
                    PrintInfoAboutAuction();
                    break;
            }
        }

        public void AuctionCreate()
        {
            Console.WriteLine("--------Создание аукциона--------\n");
            Console.WriteLine("Что бы вы хотели сделать? 1-Создать аукцион со ставкой , 0-Выйти в меню");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input)) // Считывание информации с клавиатуры
            {
                Console.WriteLine("Ошибка ввода.");
                return; // или какая-то другая логика обработки ошибки
            };

            List<IThing> things = new List<IThing>(); // пока что

            // Проверка не введена ли пустая строка
            switch (input)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("Введите название вещи:");
                        string title = Console.ReadLine();

                        Console.WriteLine("Введите описание вещи:");
                        string description = Console.ReadLine();

                        Console.WriteLine("Введите стартовую цену вещи:");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal startPrice))
                        {
                            Console.WriteLine("Некорректный формат стартовой цены. Пожалуйста, введите число.");
                            continue;
                        }

                        IThing newThing = new Thing(title, description, startPrice);
                        things.Add(newThing);

                        Console.WriteLine("Вещь успешно добавлена!");

                        Console.WriteLine("Хотите добавить еще одну вещь? (y/n)");
                        string answer = Console.ReadLine().ToLower();
                        if (answer != "y")
                            break;
                    }
                    /*
                    Console.WriteLine("Список вещей:");
                    foreach (var thing in things)
                    {
                        Console.WriteLine($"ID: {thing.ThingId}, Название: {thing.Title}, Описание: {thing.Description}, Стартовая цена: {thing.StartPrice}");
                    }*/
                    _auctionService.CreateAuctionWithBid(_user.UserId, things);
                    break;
                case 0:
                    AccountMenu();
                    break;
            }
        }

        public void PlaceBid()
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
                    AccountMenu();
                    break;
            }
        }

        public void PrintInfoAboutAllAuctions()
        {
            Console.WriteLine("--------Информация о всех аукционах--------\n");
            List<AuctionInfo> info = _auctionService.InfoAboutAllAuctions();
            foreach (AuctionInfo auctionInfo in info)
            {
                Console.WriteLine(auctionInfo.ToString());
            }
        }

        public void PrintInfoAboutAuction()
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
                    AuctionInfo info = _auctionService.InfoAboutAuction(number);
                    Console.WriteLine(info.ToString());
                    break;
                case 0:
                    AccountMenu();
                    break;
                }
            }
        }
    } 

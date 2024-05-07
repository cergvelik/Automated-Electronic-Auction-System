using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Classes.MainServices;
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

            string Hash = PasswordEncrypt.Encrypt(password);
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

            Console.WriteLine("Введите вещи. После окончания ввода нажмите 0.");
            string? thing = Console.ReadLine();// Считывание информации с клавиатуры
            
            List<IThing> things = null; // пока что

            // Проверка не введена ли пустая строка
            switch (input)
            {
                case 1:
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

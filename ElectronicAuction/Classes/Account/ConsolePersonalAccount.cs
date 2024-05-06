using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Classes.Services;
using ElectronicAuction.Interfaces.UserInterfaces;


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
            Console.WriteLine("--------Аккаунт--------\n\n\n");
            Console.WriteLine("Чтобы вы хотели сделать? 1-Войти в существующий аккаунт, 2-Зарегистрироваться");
            int? input = Console.Read();// Считывание информации с клавиатуры
            // Проверка не введена ли пустая строка

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
            Console.WriteLine("--------Вход--------\n\n\n");
            Console.WriteLine("Введите свой email: ");
            Console.WriteLine("Введите свой пароль: ");
            string? password  = Console.ReadLine();// Считывание информации с клавиатуры
            // Проверка не введена ли пустая строка
            string Hash = PasswordEncrypt.Encrypt(password);
            AccountMenu();
        }

        public void AccountRegistration()
        {
            Console.WriteLine("--------Регистрация--------\n\n\n");
            Console.WriteLine("Введите своё имя: ");
            Console.WriteLine("Введите email: ");
            Console.WriteLine("Введите пароль: ");
            //тут ввод данных понятно дело

            string? password = Console.ReadLine();// Считывание информации с клавиатуры
            // Проверка не введена ли пустая строка
            string Hash = PasswordEncrypt.Encrypt(password);


            _userService.CreateNewUser();
             AccountLogin();
        }

        public void AccountMenu()
        {
            Console.WriteLine("--------Меню--------\n\n\n");
            Console.WriteLine("Чтобы вы хотели сделать? 1-Создать аукцион , 2-Выставить ставку, 3-Получить информацию о всех аукционах, 4-Получить информацию о конкретном аукционе");
            int? input = Console.Read();// Считывание информации с клавиатуры
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
            Console.WriteLine("--------Создание аукциона--------\n\n\n");
            Console.WriteLine("Чтобы вы хотели сделать? 1-Создать аукцион со ставкой , 0-Выйти в меню");
            int? input = Console.Read();// Считывание информации с клавиатуры
            // Проверка не введена ли пустая строка
            switch (input)
            {
                case 1:
                    _auctionService.CreateAuctionWithBid(_user.UserId,things);
                    break;
                case 0:
                    AccountMenu();
                    break;
            }
        }

        public void PlaceBid()
        {
            Console.WriteLine("--------Размещение ставки--------\n\n\n");
            Console.WriteLine("Чтобы вы хотели сделать? 1-Разместить ставку , 0-Выйти в меню");
            int? input = Console.Read();// Считывание информации с клавиатуры
            // Проверка не введена ли пустая строка
            switch (input)
            {
                case 1:
                    _auctionService.PlaceBid(_user.UserId, auctionId, sum);
                    break;
                case 0:
                    AccountMenu();
                    break;
            }
        }

        public void PrintInfoAboutAllAuctions()
        {
            Console.WriteLine("--------Информация о всех аукционах--------\n\n\n");
            List<AuctionInfo> info = _auctionService.InfoAboutAllAuctions();
            foreach(AuctionInfo auctionInfo in info)
            {
                Console.WriteLine(auctionInfo.ToString());
            }

        }

        public void PrintInfoAboutAuction()
        {
            Console.WriteLine("--------Информация о аукционе--------\n\n\n");
            Console.WriteLine("Чтобы вы хотели сделать? 1-Узнать информацию о аукционе , 0-Выйти в меню");
            int? input = Console.Read();// Считывание информации с клавиатуры
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

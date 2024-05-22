using System.Text.RegularExpressions;

namespace ElectronicAuction.Classes
{
    public static class EmailValidator
    {
        public static bool IsValidEmail(string email)
        {
            // Паттерн для проверки email адреса
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Проверка соответствия email адреса паттерну
            return Regex.IsMatch(email, pattern);
        }
    }
}

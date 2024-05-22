using System.Security.Cryptography;
using System.Text;

namespace ElectronicAuction.Classes
{
    public class PasswordEncrypt
    {
        public static string Encrypt(string password)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(password);

            // Создаем хэш-значение из массива байтов.
            byte[] hashValue = SHA256.HashData(messageBytes);

            // Выводим хэш-значение на консоль.
            string EncrPassword = Convert.ToHexString(hashValue);

            return EncrPassword;
        }

    }
}

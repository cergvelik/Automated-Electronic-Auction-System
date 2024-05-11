using System.Security.Cryptography;
using System.Text;

namespace ElectronicAuction.Classes
{
    public class PasswordEncrypt
    {
        public static string Encrypt(string password)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(password);

            //Create the hash value from the array of bytes.
            byte[] hashValue = SHA256.HashData(messageBytes);

            //Display the hash value to the console.
            string EncrPassword = Convert.ToHexString(hashValue);

            return EncrPassword;
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ElectronicAuction.Classes.Tests
{
    [TestClass()]
    public class PasswordEncryptTests
    {
        //даже, не знаю какие тесты писать для зашифровщика паролей
        //в будущем может дополнится
        [TestMethod()]
        public void Encrypt_String_PasswordNotEqualToHash()
        {
            string password = "1111";

            string Hash = PasswordEncrypt.Encrypt(password);

            Assert.AreNotEqual(password, Hash, "Пароль почему то не изменился");
            Debug.WriteLine(Hash+" "+password);
        }
        [TestMethod()]
        public void Encrypt_EqualPasswords_HashAreEqual()
        {
            string password1 = "1111";
            string password2 = "1111";

            string Hash1 = PasswordEncrypt.Encrypt(password1);
            string Hash2 = PasswordEncrypt.Encrypt(password2);

            Assert.AreEqual(Hash1, Hash2, "Один и тот же пароль шифруется по разному");
            Debug.WriteLine(Hash1 + " " + password1);
            Debug.WriteLine(Hash2 + " " + password2);
        }
    }
}
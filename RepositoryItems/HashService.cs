using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TestAchieveClubApi.RepositoryItems
{
    public class HashService
    {
        public class HashAndSalt
        {
            public string Hash { get; private set; }
            public string Salt { get; private set; }
            public HashAndSalt(string hash, string salt)
            {
                Hash = hash;
                Salt = salt;
            }
            public override string ToString()
            {
                return Hash + Salt;
            }
            public static HashAndSalt FromString(string hashAndSalt)
            {
                string hash = hashAndSalt.Substring(0, 44);
                string salt = hashAndSalt.Substring(44);
                return new HashAndSalt(hash, salt);
            }
        }
        public HashAndSalt HashPassword(string password)
        {
            byte[] saltBytes = new byte[128 / 8];

            RandomNumberGenerator.Create().GetNonZeroBytes(saltBytes);


            string hash = GenerateHash(password, saltBytes);
            string salt = Convert.ToBase64String(saltBytes);

            return new HashAndSalt(hash, salt);
        }

        public bool ValidPassword(string firstPassword, string secondPassword)
        {
            return ValidPassword(firstPassword, HashAndSalt.FromString(secondPassword));
        }

        public bool ValidPassword(string firstPassword, HashAndSalt secondPassword)
        {
            byte[] saltBytes = Convert.FromBase64String(secondPassword.Salt);
            string firstPasswordHash = GenerateHash(firstPassword, saltBytes);
            return firstPasswordHash == secondPassword.Hash;
        }

        private string GenerateHash(string text, byte[] salt)
        {
            byte[] hashBytes = KeyDerivation.Pbkdf2(text, salt, KeyDerivationPrf.HMACSHA256, 100000, 256 / 8);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
using System;
using System.Text;
using System.Security.Cryptography;
using Bellini.Cryptography;

/// <summary>
/// Exemplo de como usar
/// </summary>
namespace BitCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputValue = "AndersonBellini";

            string expectedResult256 = "8DF9ED29944F9CA323C122DA2EEA72BBF1EF83F51835599D7FFEC18CBAF0E8DC";
            string actualResult256 = SHA.GenerateSHA256String(inputValue);

            string expectedResult512 = "1003DDCEE2363E4DF418CDABD1918F4D8ACB8A4AC6BFF442E4DBB1ACAF6D9E2EEEEA2E36D1FEAADC2050188EC8A3D85AD91B3157F0CA3133E4460BA1E54E37AE";
            string actualResult512 = SHA.GenerateSHA512String(inputValue);

            Console.WriteLine("256 Input:    " + inputValue);
            Console.WriteLine("256 Expected: " + expectedResult256);
            Console.WriteLine("256 Actual:   " + actualResult256);
            Console.WriteLine("256 Matches:  " + string.Equals(expectedResult256, actualResult256));
            Console.WriteLine();
            Console.WriteLine("512 Input:    " + inputValue);
            Console.WriteLine("512 Expected: " + expectedResult512);
            Console.WriteLine("512 Actual:   " + actualResult512);
            Console.WriteLine("512 Matches:  " + string.Equals(expectedResult512, actualResult512));
     
            Console.ReadKey();
        }
    }
}

namespace Bellini.Cryptography
{
    public static class SHA
    {
        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

    }
}

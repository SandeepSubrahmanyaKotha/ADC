using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ADC
{
    public class Day4
    {
        public static string PartOne(string input)
        {
            var key = input;
            var number = 1;
            string s;
            Console.WriteLine($"in class {key}");
            while (true)
            {
                 s = CreateMD5Hash($"{key}{number}");
                if (s.StartsWith("000000")) //Partwo is to test for 6 zeros prefix
                    break;
                number++;
            }
            return number.ToString();
        }

        public static string CreateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            byte[] hashbytes = md5.ComputeHash(bytes);

            StringBuilder strB = new StringBuilder();

           // Console.WriteLine("in method");
            foreach (var hashByte in hashbytes)
            {
                strB.Append(hashByte.ToString("X2"));
            }
           // Console.WriteLine("in mthod return");
            return strB.ToString();
        }
    }
}

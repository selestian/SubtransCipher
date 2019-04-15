using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technique
{
    public class SubTransCypher
    {
        //transposition function for generating shuffle pattern
        public static int[] generator(int size, int key)
        {
            int[] exchanges = new int[size - 1];
            var rand = new Random(key);
            for (int i = size - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                exchanges[size - 1 - i] = n;
            }
            return exchanges;
        }

        public static string Shuffle(string toShuffle, int key)
        {
            int size = toShuffle.Length;
            char[] chars = toShuffle.ToArray();
            var exchanges = generator(size, key);
            for (int i = size - 1; i > 0; i--)
            {
                int n = exchanges[size - 1 - i];
                char tmp = chars[i];
                chars[i] = chars[n];
                chars[n] = tmp;
            }
            return new string(chars);
        }

        public static string DeShuffle(string shuffled, int key)
        {
            int size = shuffled.Length;
            char[] chars = shuffled.ToArray();
            var exchanges = generator(size, key);
            for (int i = 1; i < size; i++)
            {
                int n = exchanges[size - i - 1];
                char tmp = chars[i];
                chars[i] = chars[n];
                chars[n] = tmp;
            }
            return new string(chars);
        }
        // Main initiation program
        static void Main(string[] args)
        {
            string key = "SECURITYZXWVQPONMLKJHGFDBA";//substitution key
            Console.WriteLine("Enter your String:");
            Console.Write("\n");
            string plainText = Console.ReadLine();
            Console.Write("\n");
            int transkey = 123;        //my transposition key
            string trans = Shuffle(plainText, transkey);  //transposition
            Console.WriteLine("Your Encrypted Data:\t" + trans);
            string cipherText = Encrypt(plainText, key);        //substitution
            Console.WriteLine("Your Encrypted Data:\t" + cipherText);    //encrypted data
            string decryptedText = Decrypt(cipherText, key);    //reverse substitute
            string detrans = DeShuffle(decryptedText, transkey);    // reverse transposition 
            Console.WriteLine("Your Decrypted Data:\t" + detrans);  //decrypted data

            Console.ReadKey();

        }
        //substitution functions
        static string Encrypt(string plainText, string key)
        {
            char[] chars = new char[plainText.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                if (plainText[i] == ' ')
                {
                    chars[i] = ' ';
                }

                else
                {
                    int j = plainText[i] - 65;
                    chars[i] = key[j];
                }
            }

            return new string(chars);
        }

        static string Decrypt(string cipherText, string key)
        {
            char[] chars = new char[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (cipherText[i] == ' ')
                {
                    chars[i] = ' ';
                }
                else
                {
                    int j = key.IndexOf(cipherText[i]) + 97;
                    chars[i] = (char)j;
                }
            }
            return new string(chars);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class StreamCipher
    {
        public static string Encrypt(string inputText, string initialSeed, string polynomialBitMask)
        {
            return HandleStreamCipher(inputText, initialSeed, polynomialBitMask);
        }

        public static string Decrypt(string inputText, string initialSeed, string polynomialBitMask)
        {
            return HandleStreamCipher(inputText, initialSeed, polynomialBitMask);
        }

        private static string HandleStreamCipher(string text, string initialSeed, string polynomialBitMask)
        {
            LFSR keyGenerator = new LFSR(initialSeed, polynomialBitMask);
            string key = keyGenerator.GenerateKey(text);
            Console.WriteLine(key);

            for (int i = 0; i < text.Length; i++)
            {
                string replacement = (text[i] ^ key[i]).ToString();
                text = text.Remove(i, 1).Insert(i, replacement);
            }
            return text;
        }
    }
}

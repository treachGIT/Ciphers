using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class CiphertextAutokey
    {
        public static string Encrypt(string inputText, string initialSeed, string polynomialBitMask)
        {
            LFSR keyGenerator = new LFSR(initialSeed, polynomialBitMask);
            string key = keyGenerator.EncryptCiphertextAutokey(inputText);

            return key;
        }

        public static string Decrypt(string inputText, string initialSeed, string polynomialBitMask)
        {
            LFSR keyGenerator = new LFSR(initialSeed, polynomialBitMask);
            string key = keyGenerator.DecryptCiphertextAutokey(inputText);

            return key;
        }


    }
}

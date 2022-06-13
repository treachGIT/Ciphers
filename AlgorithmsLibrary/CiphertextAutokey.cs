using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsLibrary
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

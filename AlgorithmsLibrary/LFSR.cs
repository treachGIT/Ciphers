using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsLibrary
{
    public class LFSR
    {
        private string seed;
        private List<int> powerBits;
        private string result;

        public LFSR(string initialSeed, string polynomialBitMask)
        {
            seed = initialSeed;
            SetPowerBits(polynomialBitMask);
            result = String.Empty;
        }

        private string XOR(char[] bitsToXor)
        {
            //char current = '0';
            //foreach (char value in bitsToXor)
            //{
            //    current ^= value;
            //}
            //return current.ToString();
            int[] intElements = Array.ConvertAll(bitsToXor, c => (int)char.GetNumericValue(c));
            int result = intElements.Aggregate((x, y) => x ^ y);
            return result.ToString();
        }

        private void SetPowerBits(string polynomialBitMask)
        {
            powerBits = new List<int>();
            for (int i = 0; i < polynomialBitMask.Length; i++)
            {
                if (polynomialBitMask[i] == '1')
                {
                    powerBits.Add(i);
                }
            }
        }

        public string GenerateNumber()
        {
            char[] bitsToXor = new char[powerBits.Count];
            for (int i = 0; i < powerBits.Count; i++)
                bitsToXor[i] = seed[powerBits[i]];

            string newFirstBit = XOR(bitsToXor);
            seed = seed.Insert(0, newFirstBit);
            char lastBit = seed[seed.Length - 1];
            seed = seed.Remove(seed.Length - 1);

            result += lastBit;

            return result;
        }

        public void GenerateNumber2()
        {
            char[] bitsToXor = new char[powerBits.Count];
            for (int i = 0; i < powerBits.Count; i++)
                bitsToXor[i] = seed[powerBits[i]];

            string newFirstBit = XOR(bitsToXor);
            seed = seed.Insert(0, newFirstBit);
            char lastBit = seed[seed.Length - 1];
            seed = seed.Remove(seed.Length - 1);

            result += newFirstBit;
        }

        public string EncryptCiphertextAutokey(string inputText)
        {
            result = string.Empty;
            for (int i = 0; i < inputText.Length; i++)
            {
                char[] bitsToXor = new char[powerBits.Count];
                for (int j = 0; j < powerBits.Count; j++)
                    bitsToXor[j] = seed[powerBits[j]];

                string newFirstBit = XOR(bitsToXor);
                char c = newFirstBit[0];
                char t = inputText[i];

                string res = (c ^ t).ToString();

                seed = seed.Insert(0, res);
                char lastBit = seed[seed.Length - 1];
                seed = seed.Remove(seed.Length - 1);

                result += res;
            }
            return result;
        }

        public string DecryptCiphertextAutokey(string inputText)
        {
            result = string.Empty;
            for (int i = 0; i < inputText.Length; i++)
            {
                char[] bitsToXor = new char[powerBits.Count];
                for (int j = 0; j < powerBits.Count; j++)
                    bitsToXor[j] = seed[powerBits[j]];

                string newFirstBit = XOR(bitsToXor);
                char c = newFirstBit[0];
                char t = inputText[i];

                string res = (c ^ t).ToString();
                result += res;

                seed = seed.Insert(0, inputText[i].ToString());
                char lastBit = seed[seed.Length - 1];
                seed = seed.Remove(seed.Length - 1);


            }
            return result;
        }

        public string GenerateKey(string plainText)
        {
            result = string.Empty;
            for (int i = 0; i < plainText.Length; i++)
                GenerateNumber2();

            return result;
        }

    }
}

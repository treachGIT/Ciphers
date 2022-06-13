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
            //inicjacja ziarna i ustawienie bitów potęg wielomianu
            seed = initialSeed;
            SetPowerBits(polynomialBitMask);
            result = String.Empty;
        }

        private string XOR(char[] bitsToXor)
        {
            int[] bits = Array.ConvertAll(bitsToXor, c => (int)char.GetNumericValue(c));
            int result = 0;
            foreach (int bit in bits)
            {
                result ^= bit;
            }

            return result.ToString();
        }

        //ustawiamy które bity znajdują się na pozycjach odpowiadających potęgom wielomianu
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

        //metoda do generowania wyniku LFSR
        public string GenerateNumber()
        {
            //zapisujemy bity które zostaną poddane operacji XOR
            char[] bitsToXor = new char[powerBits.Count];
            for (int i = 0; i < powerBits.Count; i++)
                bitsToXor[i] = seed[powerBits[i]];

            //wynik operacji XOR ustawiamy jako najstarszy bit
            string newFirstBit = XOR(bitsToXor);
            seed = seed.Insert(0, newFirstBit);

            //przesuwamy rejestr usuwając ostatni bit 
            char lastBit = seed[seed.Length - 1];
            seed = seed.Remove(seed.Length - 1);

            //usunięty bit dodajemy do wyniku
            result += lastBit;

            return result;
        }

        //metoda do generowania klucza dla Stream Cipher
        public void GenerateForStreamCipher()
        {
            //zapisujemy bity które zostaną poddane operacji XOR
            char[] bitsToXor = new char[powerBits.Count];
            for (int i = 0; i < powerBits.Count; i++)
                bitsToXor[i] = seed[powerBits[i]];

            //wynik operacji XOR ustawiamy jako najstarszy bit
            string newFirstBit = XOR(bitsToXor);
            seed = seed.Insert(0, newFirstBit);

            //przesuwamy rejestr usuwając ostatni bit 
            char lastBit = seed[seed.Length - 1];
            seed = seed.Remove(seed.Length - 1);

            //wynik operacji XOR dodajemy do wyniku
            result += newFirstBit;
        }

        public string EncryptCiphertextAutokey(string inputText)
        {
            result = string.Empty;
            for (int i = 0; i < inputText.Length; i++)
            {
                //zapisujemy bity które zostaną poddane operacji XOR
                char[] bitsToXor = new char[powerBits.Count];
                for (int j = 0; j < powerBits.Count; j++)
                    bitsToXor[j] = seed[powerBits[j]];

                //wynik operacji XOR ustawiamy jako najstarszy bit
                string newFirstBit = XOR(bitsToXor);

                //char c = newFirstBit[0];
                //char t = inputText[i];
                int c = (int)char.GetNumericValue(newFirstBit[0]);
                int t = (int)char.GetNumericValue(inputText[i]);

                //nowy bit XORujemy jeszcze raz z bitem tekstu
                string res = (c ^ t).ToString();

                //wynik ustawiamy jako najstarszy bit
                seed = seed.Insert(0, res);

                //przesuwamy rejestr usuwając ostatni bit 
                char lastBit = seed[seed.Length - 1];
                seed = seed.Remove(seed.Length - 1);

                //wynik res dodajemy do wyniku
                result += res;
            }
            return result;
        }

        public string DecryptCiphertextAutokey(string inputText)
        {
            result = string.Empty;
            for (int i = 0; i < inputText.Length; i++)
            {
                //zapisujemy bity które zostaną poddane operacji XOR
                char[] bitsToXor = new char[powerBits.Count];
                for (int j = 0; j < powerBits.Count; j++)
                    bitsToXor[j] = seed[powerBits[j]];

                //wynik operacji XOR ustawiamy jako najstarszy bit
                string newFirstBit = XOR(bitsToXor);

                //char c = newFirstBit[0];
                //char t = inputText[i];
                int c = (int)char.GetNumericValue(newFirstBit[0]);
                int t = (int)char.GetNumericValue(inputText[i]);

                //nowy bit XORujemy jeszcze raz z bitem tekstu
                string res = (c ^ t).ToString();

                // XOR wyniku z LSFR i znaku tekstu dodajemy do wyniku
                result += res;

                //bit tekstu ustawiamy jako najstarszy bit
                seed = seed.Insert(0, inputText[i].ToString());

                //przesuwamy rejestr usuwając ostatni bit 
                char lastBit = seed[seed.Length - 1];
                seed = seed.Remove(seed.Length - 1);

            }
            return result;
        }

        //Generowanie klucza dla Stream Cipher
        public string GenerateKey(string plainText)
        {
            result = string.Empty;
            for (int i = 0; i < plainText.Length; i++)
                GenerateForStreamCipher();

            return result;
        }

    }
}

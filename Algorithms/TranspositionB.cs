using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class TranspositionB
    {
        public static string Encrypt(string inputText, string keyWord)
        {
            //wyznaczamy liczbę rzędów macierzy
            //najpierw dzielimy długość tekstu na długość rzędu
            //jeżeli zostaje nam reszta z dzielenia dodajemy kolejny rząd 
            int length = keyWord.Length;
            int rowCount = inputText.Length / length;
            if ((inputText.Length % length) != 0)
            {
                rowCount++;
            }

            //inicjujemy macierz
            char[,] matrix = new char[rowCount, length];

            //wypełniamy macierz
            int index = 0;
            for (int i = 0; i < rowCount; i++)
            {
                string row = String.Empty;
                for (int j = 0; j < length; j++)
                {
                    if (index < inputText.Length)
                    {
                        matrix[i, j] = inputText[index];
                        index++;
                 
                    }
                    else
                    {
                        matrix[i, j] = '\0';
                    }
                    row += matrix[i, j];
                }
            }

            string keyAlphabetical = SortKeyWord(keyWord);
            char [] tempKeyWord = keyWord.ToArray();

            int[] key = new int[length];
            int index1 = 0;
            foreach(char c in keyAlphabetical)
            {
                for(int i = 0; i < tempKeyWord.Length; i++)
                {
                    if(c == tempKeyWord[i])
                    {
                        key[index1] = i;
                        index1++;

                        tempKeyWord[i] = '\0';
                        break; 
                    }
                }
            }
            for (int i = 0; i < key.Length; i++)
            {
                Console.WriteLine(key[i]);
            } 

            //przechodzimy po każdej kolumnie
            string result = String.Empty;

            //przechodzimy po wszystkich kluczach, poruszamy się w rzędzie i dodajemy do wyniku dane komórki
            foreach (int keyIndex in key)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    result += matrix[i, keyIndex];
                }
                result += " ";
            }

            return result;
        }

        public static string Decrypt(string inputText, string keyWord)
        {
            //wyznaczamy liczbę rzędów macierzy
            //najpierw dzielimy długość tekstu na długość rzędu
            //jeżeli zostaje nam reszta z dzielenia dodajemy kolejny rząd 
            int length = keyWord.Length;
            int rowCount = inputText.Length / length;
            if ((inputText.Length % length) != 0)
            {
                rowCount++;
            }

            //inicjujemy macierz
            char[,] matrix = new char[rowCount, length];

            //dzielimy tekst na kolumny
            string[] textCols = new string[rowCount];
            int index = 0;
            for (int i = 0; i < rowCount; i += length)
            {
                if (inputText.Length < i + length)
                {
                    textCols[index] = inputText.Substring(i);
                }
                else
                {
                    textCols[index] = inputText.Substring(i, length);
                }

                Console.WriteLine(textCols[index]);
                index++;
            }

            return "test";
        }

        private static string SortKeyWord(string keyWord)
        {
            char[] sortedCharacters = keyWord.ToArray();
            Array.Sort(sortedCharacters);
            return new string(sortedCharacters);
        }
    }
}

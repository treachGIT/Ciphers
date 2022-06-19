using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class TranspositionA
    {
        public static string Encrypt(string inputText, int length, string orderKey)
        {
            //wyznaczamy liczbę rzędów macierzy
            //najpierw dzielimy długość tekstu na długość rzędu
            //jeżeli zostaje nam reszta z dzielenia dodajemy kolejny rząd 
            int rowCount = inputText.Length / length;
            if ( (inputText.Length % length) != 0)
            {
                rowCount++;
            }

            //inicjujemy macierz
            char[,] matrix = new char[rowCount, length];

            //wypełniamy macierz
            int index = 0;
            for(int i = 0; i < rowCount; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    if(index < inputText.Length)
                    {
                        matrix[i, j] = inputText[index];
                        index++;
                    }
                    else
                    {
                        matrix[i, j] = '\0';
                    }               
                }
            }

            //przygotowujemy klucz
            string[] tempKey = orderKey.Split('-');
            int[] key = Array.ConvertAll(tempKey, s => int.Parse(s));

            //przechodzimy po każdym rzędzie
            string result = String.Empty;
            for (int i = 0; i < rowCount; i++)
            {
                //przechodzimy po wszystkich kluczach, poruszamy się w kolumnie i dodajemy do wyniku dane komórki
                foreach (int keyIndex in key)
                {                 
                     result += matrix[i, keyIndex-1];                   
                }
            }

            return result;
        }

        public static string Decrypt(string inputText, int length, string orderKey)
        {
            //wyznaczamy liczbę rzędów macierzy
            //najpierw dzielimy długość tekstu na długość rzędu
            //jeżeli zostaje nam reszta z dzielenia dodajemy kolejny rząd 
            int rowCount = inputText.Length / length;
            if ((inputText.Length % length) != 0)
            {
                rowCount++;
            }

            //inicjujemy macierz
            char[,] matrix = new char[rowCount, length];

            //przygotowujemy klucz
            string[] tempKey = orderKey.Split('-');
            int[] key = Array.ConvertAll(tempKey, s => int.Parse(s));

            //dzielimy tekst na rzędy
            string[] textLines = new string[rowCount];
            int index = 0;
            for (int i = 0; i < inputText.Length; i += length)
            {

                if (inputText.Length < i + length)
                {
                    textLines[index] = inputText.Substring(i);
                }
                else
                {
                    textLines[index] = inputText.Substring(i, length);
                }
        
                Console.WriteLine(textLines[index]);
                index++;
           
            }

            //przechodzimy po każdym rzędzie i go porządkujemy 
            string result = String.Empty;
            for (int i = 0; i < rowCount; i++)
            {
                //przygotowujemy nową tablicę do uprządkowanego rzędu
                char[] resultline = new char[length];
                Array.Fill(resultline, '\0');

                //przechodzimy po wszystkich kluczach
                int j = 0;

                //jeżeli jesteśmy w ostatnim rzędzie
                if (i + 1 == rowCount && textLines[i].Length != key.Length)
                {
                    //ile wolnego miejsca w ostatnim rzędzie
                    int freePlacesCount = key.Length - textLines[i].Length;

                    //wyliczamy najwyższą wartość klucza
                    int maxNewKey = key.Max() - freePlacesCount;

                    //inicjujemy nową tabelę dla kluczy ostatniego rzędu
                    int[] lastLineKey = new int[textLines[i].Length];

                    int lastLineKeyIndex = 0;
           
                    //ze starego klucza bierzemy tylko potrzebbne wartości
                    foreach (int keyIndex in key)
                    {
                        if (keyIndex <= maxNewKey)
                        {
                            lastLineKey[lastLineKeyIndex] = keyIndex;
                            lastLineKeyIndex++;
                        }
                    }           

                    foreach (int keyIndex in lastLineKey)
                    {
                        //dodajemy znak w odpowiednim miejscu do uporządkowanego rzędu
                        resultline[keyIndex - 1] = textLines[i][j];
                        j++;
                    }

                    //dodajemy uporządkowany rząd do wyniku
                    string temp1 = new string(resultline);
                    result += temp1;

                    break;
                }

                foreach (int keyIndex in key)
                {                   
                    Console.WriteLine(keyIndex + ": " + textLines[i][j]);
                    //dodajemy znak w odpowiednim miejscu do uporządkowanego rzędu
                    resultline[keyIndex - 1] = textLines[i][j];
                    j++;
                }

                //dodajemy uporządkowany rząd do wyniku
                string temp = new string(resultline);
                result += temp;
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsLibrary
{
    public class TranspositionA
    {
        public static string Encrypt(string inputText, int length, string orderKey)
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

            //wypełniamy macierz
            int index = 0;
            for (int i = 0; i < rowCount; i++)
            {
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
                    result += matrix[i, keyIndex - 1];
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
                for(int x = 0; x < resultline.Length; x++)
                    resultline[x] = '\0';

                //przechodzimy po wszystkich kluczach
                int j = 0;
                foreach (int keyIndex in key)
                {
                    //jeżeli jesteśmy w ostatnim rzędzie w ostatnim znaku, wpisujemy go w kolumnę o najniższym indeksie
                    if (textLines[i].Length - 1 == j && i + 1 == rowCount)
                    {
                        for (int x = 0; x < resultline.Length; x++)
                        {
                            if (resultline[x] == '\0')
                            {
                                resultline[x] = textLines[i][j];
                                break;
                            }

                        }
                        break;
                    }

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

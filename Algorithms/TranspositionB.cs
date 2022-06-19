﻿using System;
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

            int lastLineLenght = inputText.Length % length;

            string keyAlphabetical = SortKeyWord(keyWord);
            char[] tempKeyWord = keyWord.ToArray();

            int[] key = new int[length];
            int index1 = 0;
            foreach (char c in keyAlphabetical)
            {
                for (int j = 0; j < tempKeyWord.Length; j++)
                {
                    if (c == tempKeyWord[j])
                    {
                        key[index1] = j;
                        index1++;

                        tempKeyWord[j] = '\0';
                        break;
                    }
                }
            }

            //dzielimy tekst na kolumny
            string[] textCols = new string[length];
            int i = 0;
            int index = 0;
            while (index < length)
            {
                if (lastLineLenght == 0 || key[index] + 1 <= lastLineLenght)
                {
                    textCols[index] = inputText.Substring(i, rowCount);
                    i += rowCount;
                }
                else
                {
                    textCols[index] = inputText.Substring(i, rowCount - 1);
                    i += (rowCount - 1);
                }

                Console.WriteLine(textCols[index]);
                index++;
            }

            int colIndex = 0;
            foreach (int keyIndex in key)
            {
                int rowIndex = 0;
                while (rowIndex < textCols[colIndex].Length)
                {
                    matrix[rowIndex, keyIndex] = textCols[colIndex][rowIndex];
                    rowIndex++;
                }

                colIndex++;
            }

            string result = String.Empty;
            for(int j = 0; j < rowCount; j++)
            {
                for (int x = 0; x < length; x++)
                {
                    result += matrix[j, x];
                }
            }

            return result;
        }

        private static string SortKeyWord(string keyWord)
        {
            char[] sortedCharacters = keyWord.ToArray();
            Array.Sort(sortedCharacters);
            return new string(sortedCharacters);
        }
    }
}

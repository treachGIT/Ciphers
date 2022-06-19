using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsLibrary
{
    public static class TranspositionB
    {
        public static string Encrypt(string inputText, string keyWord)
        {
            inputText = inputText.Replace(" ", String.Empty);
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

            //sortujemy litery klucza alfabetycznie
            string keyAlphabetical = SortKeyWord(keyWord);
            char[] tempKeyWord = keyWord.ToArray();

            //wyznaczamy klucz (kolejność rzedów)
            int[] key = new int[length];
            int index1 = 0;

            //przechodzimy po wszystkich posortowanych literach
            foreach (char c in keyAlphabetical)
            {
                //kiedy odnajdziemy literę w nieposortowanym kluczu ustawiamy zapisujemy jej kolejność i wywołujemy break
                for (int i = 0; i < tempKeyWord.Length; i++)
                {
                    if (c == tempKeyWord[i])
                    {
                        key[index1] = i;
                        index1++;

                        //usuwamy odnalezioną literę żeby nie została znaleziona jeszcze raz
                        tempKeyWord[i] = '\0';
                        break;
                    }
                }
            }
       
            string result = String.Empty;

            //przechodzimy po wszystkich kluczach, poruszamy się w rzędzie i dodajemy do wyniku dane komórki
            foreach (int keyIndex in key)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (matrix[i, keyIndex] != '\0')
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

            //sortujemy litery klucza alfabetycznie
            string keyAlphabetical = SortKeyWord(keyWord);
            char[] tempKeyWord = keyWord.ToArray();

            //wyznaczamy klucz (kolejność rzedów)
            int[] key = new int[length];
            int index1 = 0;
            //przechodzimy po wszystkich posortowanych literach
            foreach (char c in keyAlphabetical)
            {
                //kiedy odnajdziemy literę w nieposortowanym kluczu ustawiamy zapisujemy jej kolejność i wywołujemy break
                for (int j = 0; j < tempKeyWord.Length; j++)
                {
                    if (c == tempKeyWord[j])
                    {
                        key[index1] = j;
                        index1++;

                        //usuwamy odnalezioną literę żeby nie została znaleziona jeszcze raz
                        tempKeyWord[j] = '\0';
                        break;
                    }
                }
            }

            //wyznaczamy długość ostatniego rzędu
            int lastLineLenght = inputText.Length % length;

            //dzielimy tekst na kolumny
            string[] textCols = new string[length];
            int i = 0;
            int index = 0;
            while (index < length)
            {
                //jeżeli kolumna mieści się w ostatnim rzędzie to ma maksymalną długość
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

                index++;
            }

            //przechodzimy po wszystkich kluczach i wpisujemy znaki z kolumn w odpowiedniej kolejności do tablicy 
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

            //przechodzimy po uporządkowanej macierzy i czytamy wynik
            string result = String.Empty;
            for (int j = 0; j < rowCount; j++)
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

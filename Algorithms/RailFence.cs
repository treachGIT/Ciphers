using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class RailFence
    {
        public static string Encrypt(string inputText, int key)
        {
            //inicjujemy tablicę do przechowywania liter
            char[,] matrix = new char[key,inputText.Length];

            //wypełniamy tablicę pustymi znakami
            for(int i = 0; i < key; i++)
            {
                for (int j = 0; j < inputText.Length; j++)
                {
                    matrix[i, j] = '\0';
                }
            }

            //wyznaczamy kierunek wpisywania znaków (w górę lub w dół)
            bool directionDown = false;
            int row = 0;
            int col = 0;

            //w pętli wpisujemy poszczególne litery do tabeli
            for (int i = 0; i < inputText.Length; i++)
            {
                //jeżeli jesteśmy w rzędzie pierwszym lub ostatnim należy zmienić kierunek
                if (row == 0 || row == key - 1)
                {
                    directionDown = !directionDown;
                }
                
                //wstawiamy znak na miejsce w tabeli i przechodzimy do następnej kolumny
                matrix[row, col] = inputText[i];
                col++;

                //przechodzimy do nastepnego rzędu w górę lub w dół w zależności od aktualnego kierunku
                if (directionDown)
                    row++;
                else
                    row--;
            }

            //po odpowiednim wypełnieniu tabeli wystarczy przejść kolejno po każdym rzędzie i zczytać litery
            string encryptedResult = String.Empty;
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < inputText.Length; j++)
                {
                    //pomijamy puste komórki
                    if (matrix[i, j] != '\0')
                        encryptedResult += matrix[i, j];
                }                
            }
          
            return encryptedResult;
        }

        public static string Decrypt(string cipherText, int key)
        {
            //inicjujemy tablicę do przechowywania liter
            char[,] matrix = new char[key, cipherText.Length];

            //wypełniamy tablicę pustymi znakami
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < cipherText.Length; j++)
                {
                    matrix[i, j] = '\0';
                }
            }

            bool directionDown = false;
            int row = 0;
            int col = 0;

            //w pętli wpisujemy poszczególne litery do tabeli
            for (int i = 0; i < cipherText.Length; i++)
            {
                //jeżeli jesteśmy w rzędzie pierwszym lub ostatnim należy zmienić kierunek
                if (row == 0)
                    directionDown = true;
                if (row == key - 1)
                    directionDown = false;

                //zaznaczamy miejsce w które trzeba wstawić znak
                matrix[row, col] = '*';
                col++;

                //przechodzimy do nastepnego rzędu w górę lub w dół w zależności od aktualnego kierunku
                if (directionDown)
                    row++;
                else
                    row--;
            }

            //przechodzimy kolejno po każdym rzędzie i w zaznaczonych miejscach wstawiamy kolejne znaki tekstu
            int index = 0;
            for (int i = 0; i < key; i++)
                for (int j = 0; j < cipherText.Length; j++)
                    if (matrix[i,j] == '*' && index < cipherText.Length)
                        matrix[i, j] = cipherText[index++];


            string decryptedResult = String.Empty;
            row = 0;
            col = 0;
            for (int i = 0; i < cipherText.Length; i++)
            {
                //jeżeli jesteśmy w rzędzie pierwszym lub ostatnim należy zmienić kierunek
                if (row == 0)
                    directionDown = true;
                if (row == key - 1)
                    directionDown = false;

                //zczytujemy znak z odpowiednej komórki i dodajemy do wyniku
                if (matrix[row, col] != '*')
                    decryptedResult += matrix[row, col++];

                //przechodzimy do nastepnego rzędu w górę lub w dół w zależności od aktualnego kierunku
                if (directionDown)
                    row++;
                else
                    row--;
            }
            return decryptedResult;
        }
    }   
}

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
            char[,] matrix = new char[key,inputText.Length];

            for(int i = 0; i < key; i++)
            {
                for (int j = 0; j < inputText.Length; j++)
                {
                    matrix[i, j] = '*';
                }
            }

            bool directionDown = false;
            int row = 0;
            int col = 0;
            for (int i = 0; i < inputText.Length; i++)
            {
                if (row == 0 || row == key - 1)
                    directionDown = !directionDown;

                matrix[row, col] = inputText[i];
                col++;

                if (directionDown)
                    row++;
                else
                    row--;
            }

            string encryptedResult = String.Empty;
            for (int i = 0; i < key; i++)
                for (int j = 0; j < inputText.Length; j++)
                    if (matrix[i, j] != '*')
                        encryptedResult += matrix[i, j];

            return encryptedResult;
        }

        public static string Decrypt(string cipherText, int key)
        {
            char[,] matrix = new char[key, cipherText.Length];

            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < cipherText.Length; j++)
                {
                    matrix[i, j] = ' ';
                }
            }

            bool directionDown = false;
            int row = 0;
            int col = 0;
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (row == 0)
                    directionDown = true;
                if (row == key - 1)
                    directionDown = false;

                matrix[row, col] = '*';
                col++;

                if (directionDown)
                    row++;
                else
                    row--;
            }

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
                if (row == 0)
                    directionDown = true;
                if (row == key - 1)
                    directionDown = false;

                if (matrix[row, col] != '*')
                    decryptedResult += matrix[row, col++];

                if (directionDown)
                    row++;
                else
                    row--;
            }
            return decryptedResult;
        }

    }   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class TranspositionA
    {
        public static string Encrypt(string inputText, int lenght, string key)
        {
            int rowCount = inputText.Length / lenght;
            if ( (inputText.Length % lenght) != 0)
            {
                rowCount++;
            }

            char[,] matrix = new char[rowCount, lenght];

            int index = 0;
            for(int i = 0; i < rowCount; i++)
            {
                for(int j = 0; j < lenght; j++)
                {
                    if(index < inputText.Length)
                    {
                        matrix[i, j] = inputText[index];
                        index++;
                    }
                    else
                    {
                        matrix[i, j] = ' ';
                    }               
                }
            }

            for (int i = 0; i < key.Length; i++)
            {
                int currentKey = int.Parse(key[i].ToString());

            }
        }
    }
}

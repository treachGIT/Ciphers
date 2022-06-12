using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class TranspositionA
    {
        public static string Encrypt(string inputText, int lenght, string orderKey)
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
                        matrix[i, j] = '\0';
                    }               
                }
            }

            string[] tempKey = orderKey.Split('-');
            int[] key = Array.ConvertAll(tempKey, s => int.Parse(s));

            string result = String.Empty;
            for (int i = 0; i < rowCount; i++)
            {
                foreach(int keyIndex in key)
                {                 
                     result += matrix[i, keyIndex-1];                   
                }
            }

            return result;
        }

        public static string Decrypt(string inputText, int lenght, string orderKey)
        {
            int rowCount = inputText.Length / lenght;
            if ((inputText.Length % lenght) != 0)
            {
                rowCount++;
            }
            char[,] matrix = new char[rowCount, lenght];

            string[] tempKey = orderKey.Split('-');
            int[] key = Array.ConvertAll(tempKey, s => int.Parse(s));

            string[] textLines = new string[rowCount];
            int index = 0;
            for (int i = 0; i < inputText.Length; i += lenght)
            {

                if (inputText.Length < i + lenght)
                {
                    textLines[index] = inputText.Substring(i);
                }
                else
                {
                    textLines[index] = inputText.Substring(i, lenght);
                }
        
                Console.WriteLine(textLines[index]);
                index++;
           
            }

            string result = String.Empty;
            for (int i = 0; i < rowCount; i++)
            {
                key = key.OrderBy(x => x).ToArray();
                foreach (int keyIndex in key)
                {
                    try
                    {
                        result += textLines[i][keyIndex - 1];
                    }
                    catch(Exception ex)
                    {

                    }
                    Console.WriteLine(keyIndex);
                }

            }

            return result;

        }
    }
}

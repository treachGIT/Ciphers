using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class LFSR
    {
        public static int XOR(int a, int b)
        {
            return a ^ b;
        }

        public static string ConvertToBinaryCode(string plainText)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in plainText.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static int[] ConvertToBinaryCode2(string plainText)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in plainText.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }

            int length = sb.ToString().Length;
            string word = sb.ToString();
            int[] result = new int[length];
            for(int i = 0; i < length; i++)
            {
                result[i] = int.Parse(word[i].ToString());
            }

            return result;
        }

        public static void StartGenerating()
        {

        }

        public static List<int> SetXorOrder(string ziarno)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < ziarno.Length; i++)
            {
                if (ziarno[i] == 1)
                {
                    list.Add(i);
                }
            }
            return list;
        }

       
    }
}

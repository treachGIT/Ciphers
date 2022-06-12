using System;
using System.IO;
using System.Text;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // string res = CiphertextAutokey.Decrypt("11101001", "0011", "1001");
            //DES des = new DES();
            //string res = des.Encrypt("01000101", "0001001100110100010101110111100110011011101111001101111111110001");
            string res = TranspositionA.Decrypt("YCPRGTROHAYPAOS", 4,"3-1-4-2");
            Console.WriteLine(res);

        }

    }
}

using System;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string result = RailFence.Encrypt("CRYPTOGRAPHY", 3);

            string result1 = RailFence.Decrypt("CTARPORPYYGH", 3);

            int[] binaryword = LFSR.ConvertToBinaryCode2("e");

            Console.WriteLine(binaryword);
        }
    }
}

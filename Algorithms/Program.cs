using System;
using System.IO;
using System.Text;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string res = CiphertextAutokey.Decrypt("11101001", "0011", "1001");
            Console.WriteLine(res);

        }

    }
}

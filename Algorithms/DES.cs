using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class DES
    {
        public string Encrypt(string inputText, string key)
        {
            List<string> inputBlocks = SplitTextIntoBlocks(inputText);
            string[] keys = GetKeys(key);

            List<string> encryptedBlocks = new List<string>();
            foreach (string block in inputBlocks)
            {
                encryptedBlocks.Add(ExecuteDES(block, keys));
            }

            string result = string.Join("", encryptedBlocks.ToArray());
            return result;
        }

        private List<string> SplitTextIntoBlocks(string inputText)
        {
            List<string> blocks = new List<string>();
            int dataSize = 56;

            for (int i = 0; i < inputText.Length; i += dataSize)
            {
                blocks.Add(inputText.Substring(i, Math.Min(56, inputText.Length - i)));
            }

            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i] = AddBytes(blocks[i]);
            }

            return blocks;
        }

        private string AddBytes(string block)
        {
            int stringLength = block.Length;
            int difference = 56 - stringLength;
            int bytesNumberToAdd = difference / 8;

            for (int i = 0; i < bytesNumberToAdd; i++)
                block += "00000000";

            block += Convert.ToString(bytesNumberToAdd, 2).PadLeft(8, '0');

            return block;
        }

        private string[] GetKeys(string key)
        {
            string keyAfterPermutation = Permutation(key, DES_Constants.PermutedChoice1);

            string partC = keyAfterPermutation.Substring(0, 28);
            string partD = keyAfterPermutation.Substring(28);

            string[] keys = new string[16];
            for (int i = 0; i < 16; i++)
            {
                partC = LeftShiftTable(partC, DES_Constants.ShiftTable[i]);
                partD = LeftShiftTable(partD, DES_Constants.ShiftTable[i]);

                keys[i] = Permutation(partC + partD, DES_Constants.PermutedChoice2);
            }

            return keys;
        }

        private string Permutation(string inputBits, int[] permutationArray)
        {
            string result = String.Empty;
            for (int i = 0; i < permutationArray.Length; i++)
            {
                int position = permutationArray[i];
                int index = position - 1;

                result += inputBits[index];
            }

            return result;
        }

        private string LeftShiftTable(string tableToShift, int shiftNumber)
        {
            string newTable = tableToShift[shiftNumber..] + tableToShift[..shiftNumber];
            return newTable;
        }

        private string ExecuteDES(string block, string[] keys)
        {
            string blockAfterInitialPermutation = Permutation(block, DES_Constants.InitialPermutation);
            string leftBlock = blockAfterInitialPermutation.Substring(0, 32);
            string rightBlock = blockAfterInitialPermutation.Substring(32);

            for (int i = 0; i < 16; i++)
            {
              
            }

     

            return "test";
        }

       

        private string XORStrings(string left, string right)
        {
            char[] temp = left.ToCharArray();

            for (int i = 0; i < left.Length; i++)
            {
                string xor = (left[i] ^ right[i]).ToString();
                temp[i] = xor[0];
            }

            return new string(temp);
        }

    }   
}

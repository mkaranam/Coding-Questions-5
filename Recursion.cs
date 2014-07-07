using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        public int BinarySearch(int[] input,int key)
        {
            if (input.Length == 0) return -1;
            return BS(key, input, 0, input.Length - 1);
        }

        private int BS(int key, int[] input, int low, int high)
        {
            if (low > high) return -1;
            int mid = (low + high) / 2;
            if (input[mid] == key) return mid;
            if (key < input[mid]) return BS(key, input, low, mid - 1);
            else return BS(key, input, mid + 1, high);
        }

        public void printPermutations(String input)
        {
            if (input.Length == 0) return;
            if (input.Length == 1)
            {
                Console.WriteLine(input[0]);
                return;
            }
            StringBuilder sb = new StringBuilder();
            bool[] inPermut = new bool[input.Length];
            for (int i = 0; i < input.Length; i++) inPermut[i] = false;

            printStringPermutations(input.ToCharArray(), sb, inPermut);
        }

        private void printStringPermutations(char[] input, StringBuilder sb, bool[] inPermut)
        {
            if (sb.Length == input.Length)
            {
                Console.WriteLine(sb.ToString());
                return;
            }

            int[] candidates = getCandidates(input, inPermut);
            for (int i = 0; i < candidates.Length; i++)
            {
                sb.Append(input[candidates[i]]);    //Add to string
                inPermut[candidates[i]] = true;                 //Mark as in string
                printStringPermutations(input, sb, inPermut);   //Continue building string
                sb.Remove(sb.Length - 1 , 1);
                inPermut[candidates[i]] = false;
            }
        }

        private int[] getCandidates(char[] input, bool[] inPermut)
        {
            List<int> candidates = new List<int>();
            for (int i = 0; i < inPermut.Length; i++)
            {
                if (!inPermut[i]) candidates.Add(i);
            }
            return candidates.ToArray();
        }

        public void printCombinations(String input)
        {
            if (input.Length == 0) return;

            StringBuilder sb = new StringBuilder();
            bool[] inPermut = new bool[input.Length];
            for (int i = 0; i < input.Length; i++) inPermut[i] = false;

            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i]);
                inPermut[i] = true;
                printStringCombinations(input.ToCharArray(), sb, inPermut, input.Length - i, i);
                sb.Clear();
            }
        }

        private void printStringCombinations(char[] input, StringBuilder sb, bool[] inPermut, int targetLength, int start)
        {
            if (targetLength == 0)
            {
                return;
            }
            targetLength--;
            for (int i = start; i < input.Length; i++)
            {
                if (!inPermut[i])
                {
                    sb.Append(input[i]);
                    inPermut[i] = true;
                    printStringCombinations(input, sb, inPermut, targetLength, i);
                    sb.Remove(sb.Length - 1, 1);
                    inPermut[i] = false;
                }
            }
            Console.WriteLine(sb.ToString());
        }

        public void printPhoneNumberCombination(int[] input)
        {
            if (input.Length == 0) return;
            StringBuilder sb = new StringBuilder();
            printPhoneNumber(input, sb, 0);
        }

        private void printPhoneNumber(int[] input, StringBuilder sb, int index)
        {
            if (sb.Length == input.Length)
            {
                Console.WriteLine(sb.ToString());
                return;
            }
            char[] dialPad = getDialPad(input[index]);
            index++;
            if (dialPad.Length <= 0)
            {
                sb.Append(input[index]);
                printPhoneNumber(input, sb, index);
                sb.Remove(sb.Length - 1, 1);
            }
            else 
            {
                for (int i = 0; i < dialPad.Length; i++)
                {
                    sb.Append(dialPad[i]);
                    printPhoneNumber(input, sb, index);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
            
        }

        private char[] getDialPad(int number)
        {
            switch (number)
            {
                case 2:
                    return new char[] { 'A', 'B', 'C' };
                case 3:
                    return new char[] { 'D', 'E', 'F' };
                case 4:
                    return new char[] { 'G', 'H', 'I' };
                case 5:
                    return new char[] { 'J', 'K', 'L' };
                case 6:
                    return new char[] { 'M', 'N', 'O' };
                case 7:
                    return new char[] { 'P', 'R', 'S' };
                case 8:
                    return new char[] { 'T', 'U', 'V' };
                case 9:
                    return new char[] { 'W', 'X', 'Y' };
                default:
                    return new char[] { };
            }
        }

    }
}

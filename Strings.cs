using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    class Strings
    {

        public char? firstNonRepeatedChar(string input)
        {
            int[] charSet = new int[256];
            for (int i = 0; i < 256; i++) charSet[i] = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input.ElementAt(i);
                charSet[c]++;
            }

            for (int i = 0; i < input.Length; i++)
            {
                char c = input.ElementAt(i);
                if (charSet[c] == 1) return c;
            }
            return null;
        }

        public string removeChars(string input, string remove)
        {
            if (input.Length == 0 || remove.Length == 0) return input;

            char[] removeChar = remove.ToCharArray();
            bool[] charSet = new bool[256];
            for (int i = 0; i < 256; i++) charSet[i] = false;
            for (int i = 0; i < removeChar.Length; i++) charSet[removeChar[i]] = true;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input.ElementAt(i);
                if (!charSet[c]) sb.Append(c);
            }
            return sb.ToString();
        }

        public string reverseWords(string input)
        {
            if (input.Length < 2) return input;

            StringBuilder sb = new StringBuilder();

            int wordLength=0;
            for (int i = input.Length-1; i >= 0; i--)
            {
                char c = input.ElementAt(i);
                if (c == ' ')
                {
                    sb.Append(input.Substring(i + 1, wordLength) + ' ');
                    wordLength = 0;
                }
                else wordLength++;
            }
            if (wordLength >= 0) sb.Append(input.Substring(0, wordLength));
            return sb.ToString();
        }

        public int StringToInt(string input)
        {
            bool negative = false;
            int number = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input.ElementAt(i);
                if (i == 0 && c == '-') negative = true;
                else number = number * 10 + (c - '0');
            }
            if (negative) number *= -1;
            return number;
        }

        public string IntToString(int number)
        {
            Stack<char> s = new Stack<char>();
            StringBuilder sb = new StringBuilder();
            if (number < 0)
            {
                number = -1 * number;
                sb.Append("-");
            }
            do
            {
                int digit = number % 10;
                number = number / 10;
                s.Push((char)(digit + '0'));
            } while (number != 0);
            while (s.Count > 0) sb.Append(s.Pop());
            return sb.ToString();
        }
    }
}

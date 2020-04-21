using System;
using System.Text.RegularExpressions;

namespace RegularExpressionMatching
{
    public static class Solution
    {

        public static bool IsMatch(string s, string p)
        {
            /*
               '.' Matches any single character.
                '*' Matches zero or more of the preceding element.
                The matching should cover the entire input string (not partial).
            */
            return Regex.IsMatch(s, "^" + p + '$');
        }

        public static bool IsManualMatch(string input, string pattern)
        {
            var indexOfPattern = 0;

            for (var index = 0; index < input.Length; index++)
            {
                var currentCharFromInput = input[index];
                
                char currentCharFromPattern;
                try
                {
                    currentCharFromPattern = pattern[indexOfPattern];
                }
                catch (IndexOutOfRangeException)
                {
                    return false;
                }

                char? nextCharFromPattern = null;
                try
                {
                    nextCharFromPattern = pattern[indexOfPattern + 1];
                }
                catch (IndexOutOfRangeException)
                {
                }

                // input:   ?
                // pattern: .*
                if (currentCharFromPattern == '.' && nextCharFromPattern.HasValue && nextCharFromPattern.Value == '*')
                    return true;
                
                if (currentCharFromPattern != currentCharFromInput && currentCharFromPattern != '.')
                    // input:   a
                    // pattern: c*
                    if (nextCharFromPattern.HasValue && nextCharFromPattern.Value == '*')
                    {
                        indexOfPattern += 2;
                        index--;
                        continue;
                    }
                    // input:   a
                    // pattern: c
                    else
                        return false;
                
                // input:   a
                // pattern: a*
                if (nextCharFromPattern.HasValue && nextCharFromPattern.Value == '*')
                    continue;

                // input:   a
                // pattern: a
                indexOfPattern++;
            }

            return true;
        }

        public static bool IsManualMatch2(string input, string pattern)
        {
            var indexOfPattern = 0;
            var indexOfInput = 0;

            while (true)
            {
                var currentCharFromInput = input[indexOfInput];
                var currentCharFromPattern = input[indexOfPattern];
                var previousCharFromPattern = input[indexOfPattern-1];

                switch (currentCharFromPattern)
                {
                    case '.':
                        indexOfPattern++;
                        indexOfInput++;
                        break;
                    case '*' when (previousCharFromPattern == currentCharFromInput):
                        indexOfInput++;
                        break;
                    case '*' when (previousCharFromPattern != currentCharFromInput):
                        indexOfInput++;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

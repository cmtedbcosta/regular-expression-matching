using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace RegularExpressionMatching.Test
{
    public class MatchTest
    {
        public static IEnumerable<object[]> InputsAndOutputs()
        {
            //yield return new object[] { "aa", "a", false, "'a' does not match the entire string 'aa'" };
            //yield return new object[] { "aa", "a*", true, "'*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes 'aa'" };
            //yield return new object[] { "ab", ".*", true, "'.*' means 'zero or more (*) of any character (.)'" };
            //yield return new object[] { "aab", "c*a*b", true, "c can be repeated 0 times, a can be repeated 1 time. Therefore, it matches 'aab'"};
            //yield return new object[] { "mississippi", "mis*is*p*.", false, "" };

            yield return new object[] { "cbaa", "c*ba*", true, "" };
            yield return new object[] { "baa", "c*ba*", true, "" };
        }

        [Theory]
        [MemberData(nameof(InputsAndOutputs))]
        public void TestIfInputMatchesPattern(string input, string pattern, bool result, string reason)
        {
            Solution.IsManualMatch(input, pattern).Should().Be(result, reason);
        }
    }
}

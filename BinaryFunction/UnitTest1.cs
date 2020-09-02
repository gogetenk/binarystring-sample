using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace BinaryFunction
{
    public class UnitTest1
    {
        private bool IsValidBinaryString(string input)
        {
            List<char> zeros = GetZerosInString(input);
            List<char> ones = GetOnesInString(input);
            List<string> prefixes = new List<string>();

            if (zeros.Count != ones.Count)
                return false;

            for (int i = 1; i <= input.Count(); i++)
            {
                prefixes.Add(new string(input.Take(i).ToArray()));
            }

            foreach (var prefix in prefixes)
            {
                zeros = GetZerosInString(prefix);
                ones = GetOnesInString(prefix);
                if (ones.Count < zeros.Count)
                    return false;
            }
            return true;
        }

        private static List<char> GetOnesInString(string input)
        {
            return input.Where(x => x == '1').ToList();
        }

        private static List<char> GetZerosInString(string input)
        {
            return input.Where(x => x == '0').ToList();
        }

        [Fact]
        public void IsValidBinaryString_WhenNbOfZerosEqualsNbOfOne_ExpectTrue()
        {
            // Arrange
            var str = "110010";

            // Act
            var result = IsValidBinaryString(str);

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void IsValidBinaryString_WhenNbOfZerosDoesntEqualsNbOfOne_ExpectFalse()
        {
            // Arrange
            var str = "100010";

            // Act
            var result = IsValidBinaryString(str);

            // Assert
            result.Should().Be(false);
        }

        [Fact]
        public void IsValidBinaryString_WhenNumberOfZerosDoesntEqualNbOfOne_ExpectFalse()
        {
            // Arrange
            var str = "11010";

            // Act
            var result = IsValidBinaryString(str);

            // Assert
            result.Should().Be(false);
        }

        [Fact]
        public void IsValidBinaryString_WhenPrefixesHaveLessOneThanZeros_ExpectFalse()
        {
            // Arrange
            var str = "001110";

            // Act
            var result = IsValidBinaryString(str);

            // Assert
            result.Should().Be(false);
        }
    }
}

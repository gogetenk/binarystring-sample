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
            // Null check
            if (string.IsNullOrEmpty(input))
                return false;

            // Binary check
            if (!input.Any(x => x == '0' || x == '1'))
                return false;

            List<char> zeros = GetCharsInString(input, '0');
            List<char> ones = GetCharsInString(input, '1');
            List<string> prefixes = new List<string>();

            // Comparison check
            if (zeros.Count != ones.Count)
                return false;

            // Prefixes Check
            for (int i = 1; i <= input.Count(); i++)
            {
                prefixes.Add(new string(input.Take(i).ToArray()));
            }

            foreach (var prefix in prefixes)
            {
                zeros = GetCharsInString(prefix, '0');
                ones = GetCharsInString(prefix, '1');
                if (ones.Count < zeros.Count)
                    return false;
            }
            return true;
        }

        private static List<char> GetCharsInString(string input, char binary)
        {
            return input.Where(x => x == binary).ToList();
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

        [Fact]
        public void IsValidBinaryString_WhenStringIsEmpty_ExpectFalse()
        {
            // Arrange
            var str = string.Empty;

            // Act
            var result = IsValidBinaryString(str);

            // Assert
            result.Should().Be(false);
        }

        [Fact]
        public void IsValidBinaryString_WhenStringIsNotBinary_ExpectFalse()
        {
            // Arrange
            var str = "foobar";

            // Act
            var result = IsValidBinaryString(str);

            // Assert
            result.Should().Be(false);
        }
    }
}

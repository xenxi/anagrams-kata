using System;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class WordShould
    {
        [Test]
        public void return_empty_list_of_string_for_empty_input_string()
        {
            var aGivenEmptyInputString = string.Empty;
            var word = new Word(aGivenEmptyInputString);

            var anagrams = word.GetConvinations();

            anagrams.Should().BeEmpty();
        }

        [TestCase("ab")]
        [TestCase("below")]
        [TestCase("angered")]
        public void return_a_list_with_lengh_equal_to_the_factorial_of_the_characters_in_the_word(string aGivenString)
        {
            var word = new Word(aGivenString);

            var convinations = word.GetConvinations();

            var expectedTotalAnagrams = Factorial(aGivenString.Length);
            convinations.Count().Should().Be(expectedTotalAnagrams);
        }

        private int Factorial(int number)
        {
            var factorial = 1;
            for (var i = 1; i <= number; i++)
                factorial *= i;

            return factorial;
        }
    }
}
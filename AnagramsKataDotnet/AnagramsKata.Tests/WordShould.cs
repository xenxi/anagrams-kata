using System.Collections.Generic;
using System.Linq;
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
            var emptyWord = new Word(string.Empty);

            var combinations = emptyWord.GetCombinations();

            combinations.Should().BeEmpty();
        }

        [TestCase("ab")]
        [TestCase("below")]
        [TestCase("angered")]
        public void return_a_list_with_length_equal_to_the_factorial_of_the_characters_in_the_word(string aGivenString)
        {
            var word = new Word(aGivenString);

            var combinations = word.GetCombinations();

            var expectedTotalAnagrams = VariationsWithoutRepetition(aGivenString);
            combinations.Count().Should().Be(expectedTotalAnagrams);
        }

        private int VariationsWithoutRepetition(string aGivenString)
        {
            var length = aGivenString.Length - aGivenString.GroupBy(x => x).Count(x => x.Count() == 1);
            var expectedTotalAnagrams = Factorial(aGivenString.Length) / Factorial(length);
            return expectedTotalAnagrams;
        }

        [Test]
        public void return_all_combinations()
        {
            var aGivenWord = new Word("abc");

            var combinations = aGivenWord.GetCombinations();

            var expectedCombinations = new List<string> { "abc", "acb", "cba", "bac", "bca", "cab" };
            combinations.Should().BeEquivalentTo(expectedCombinations);
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
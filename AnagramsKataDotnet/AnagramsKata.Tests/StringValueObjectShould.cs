using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class StringValueObjectShould : StringValueObjectTestCase
    {
        [Test]
        public void return_empty_list_of_string_for_empty_input_string()
        {
            var emptyWord = new StringValueObject(string.Empty);

            var combinations = emptyWord.GetCombinations();

            combinations.Should().BeEmpty();
        }

        [TestCase("ab")]
        [TestCase("below")]
        [TestCase("angered")]
        public void return_a_list_with_length_equal_to_the_variations_without_repetition_of_the_characters_in_the_word(
            string aGivenString)
        {
            var word = new StringValueObject(aGivenString);

            var combinations = word.GetCombinations();

            var expectedTotalAnagrams = VariationsWithoutRepetition(word.Value);
            combinations.Count().Should().Be(expectedTotalAnagrams);
        }

        [Test]
        public void return_all_combinations()
        {
            var aGivenWord = new StringValueObject("abc");

            var combinations = aGivenWord.GetCombinations();

            var expectedCombinations = new List<string> { "abc", "acb", "cba", "bac", "bca", "cab" };
            combinations.Should().BeEquivalentTo(expectedCombinations);
        }
    }
}
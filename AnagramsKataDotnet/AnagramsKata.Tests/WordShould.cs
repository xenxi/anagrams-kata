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

            var anagrams = word.GetConvinations(aGivenEmptyInputString);

            anagrams.Should().BeEmpty();
        }
    }
}
using FluentAssertions;
using NUnit.Framework;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class AnagramFinderShould
    {
        [Test]
        public void return_empty_list_of_words_for_empty_input_string()
        {
            var anagramSearcher = new AnagramSearcher();
            var aGivenEmptyInputString = string.Empty;

            var anagrams = anagramSearcher.Search(aGivenEmptyInputString);

            anagrams.Should().BeEmpty();
        }
    }

}
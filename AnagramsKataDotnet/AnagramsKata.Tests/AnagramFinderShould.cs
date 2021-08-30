using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class AnagramFinderShould
    {
        private AnagramSearcher _anagramSearcher;

        [SetUp]
        public void SetUp()
        {
            _anagramSearcher = new AnagramSearcher();
        }

        [Test]
        public void return_empty_list_of_words_for_empty_input_string()
        {
            var aGivenEmptyInputString = string.Empty;

            var anagrams = _anagramSearcher.Search(aGivenEmptyInputString);

            anagrams.Should().BeEmpty();
        }

        [Test]
        public void return_empty_list_of_words_for_null_input()
        {
            var anagrams = _anagramSearcher.Search(null);

            anagrams.Should().BeEmpty();
        }

        [Test]
        [TestCase("a")]
        [TestCase("B")]
        [TestCase("c")]
        public void return_empty_list_of_words_for_string_with_only_one_character(string aGivenEmptyInputString)
        {
            var anagrams = _anagramSearcher.Search(aGivenEmptyInputString);

            anagrams.Should().BeEmpty();
        }

        [Test]
        [TestCase("below", "elbow")]
        public void return_one_anagram(string aGivenWord, string expectedAnagram)
        {
            var anagrams = _anagramSearcher.Search(aGivenWord);

            anagrams.Should().ContainSingle(expectedAnagram);
        }
    }
}
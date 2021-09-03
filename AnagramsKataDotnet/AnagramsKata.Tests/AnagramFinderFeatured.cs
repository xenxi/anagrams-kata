using FluentAssertions;
using NUnit.Framework;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class AnagramFinderFeatured
    {
        [SetUp]
        public void SetUp()
        {
            _anagramSearcher = new AnagramSearcher(FileDictionaryWordValidator.FromFile("./Sources/en_words.txt"));
        }

        private AnagramSearcher _anagramSearcher;

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
        [TestCase("angered", "enraged")]
        [TestCase("creative", "reactive")]
        [TestCase("observe", "verbose")]
        public void return_one_anagram(string aGivenWord, string expectedAnagram)
        {
            var anagrams = _anagramSearcher.Search(aGivenWord);

            anagrams.Should().Contain(expectedAnagram);
        }

        [Test]
        [TestCase("BELOW", "elbow")]
        [TestCase("ANGERED", "enraged")]
        [TestCase("CREATIVE", "reactive")]
        [TestCase("OBSERVE", "verbose")]
        public void found_anagram_ignore_case(string aGivenWord, string expectedAnagram)
        {
            var anagrams = _anagramSearcher.Search(aGivenWord);

            anagrams.Should().Contain(expectedAnagram);
        }

        [Test]
        [TestCase("below")]
        [TestCase("angered")]
        [TestCase("creative")]
        [TestCase("observe")]
        public void no_include_current_word_as_an_anagram(string aGivenWord)
        {
            var anagrams = _anagramSearcher.Search(aGivenWord);

            anagrams.Should().NotContain(aGivenWord);
        }
    }
}
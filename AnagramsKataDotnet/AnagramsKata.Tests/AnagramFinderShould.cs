using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class AnagramFinderShould
    {
        private AnagramSearcher _anagramSearcher;

        private Mock<IWordDictionary> _wordDictionary;

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
            ShouldSearchWord(expectedAnagram);

            var anagrams = _anagramSearcher.Search(aGivenWord);

            anagrams.Should().Contain(expectedAnagram);
        }

        [Test]
        [TestCase("below", "elbow")]
        [TestCase("angered", "enraged")]
        [TestCase("creative", "reactive")]
        [TestCase("observe", "verbose")]
        public void no_include_current_word_as_an_anagram(string aGivenWord, string expectedWordWithSameLength)
        {
            ShouldSearchWord(expectedWordWithSameLength);

            var anagrams = _anagramSearcher.Search(aGivenWord);

            anagrams.Should().NotContain(aGivenWord);
        }

        [Test]
        [TestCase("BELOW", "elbow")]
        [TestCase("ANGERED", "enraged")]
        [TestCase("CREATIVE", "reactive")]
        [TestCase("OBSERVE", "verbose")]
        public void found_anagram_ignore_case(string aGivenWord, string expectedAnagram)
        {
            ShouldSearchWord(expectedAnagram);

            var anagrams = _anagramSearcher.Search(aGivenWord);

            anagrams.Should().Contain(expectedAnagram);
        }

        [SetUp]
        public void SetUp()
        {
            _wordDictionary = new Mock<IWordDictionary>();
            _anagramSearcher = new AnagramSearcher(_wordDictionary.Object);
        }
        private void ShouldSearchWord(string expectedWordWithSameLength) 
            => _wordDictionary.Setup(x => x.SearchWordsByLength(expectedWordWithSameLength.Length))
                .Returns(new Words(new List<Word> { expectedWordWithSameLength }));
    }
}
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class FileDictionaryWordValidatorShould
    {
        private static FileDictionaryWordValidator _englishFileDictionaryWordValidator;

        [OneTimeSetUp]
        public void Setup()
        {
            _englishFileDictionaryWordValidator = FileDictionaryWordValidator.FromFile("./Sources/en_words.txt");
        }

        [Test]
        public void return_empty_list_when_length_is_zero()
        {
            var totalWords = _englishFileDictionaryWordValidator.SearchWordsByLength(0);

            totalWords.Should().BeEmpty();
        }
        [Test]
        public void return_empty_list_when_length_is_less_than_zero()
        {
            var totalWords = _englishFileDictionaryWordValidator.SearchWordsByLength(-1);

            totalWords.Should().BeEmpty();
        }
        [Test]
        public void have_0_words_for_empty_input()
        {
            var englishFileDictionaryWordValidator = new FileDictionaryWordValidator(string.Empty);

            var totalWords = englishFileDictionaryWordValidator.Count();

            totalWords.Should().Be(0);
        }

        [Test]
        public void have_4_words()
        {
            var englishFileDictionaryWordValidator = new FileDictionaryWordValidator("a\nb\nc\nd");

            var totalWords = englishFileDictionaryWordValidator.Count();

            totalWords.Should().Be(4);
        }

        [Test]
        public void have_3_words()
        {
            var englishFileDictionaryWordValidator = new FileDictionaryWordValidator("a\nb\nc");

            var totalWords = englishFileDictionaryWordValidator.Count();

            totalWords.Should().Be(3);
        }

        [Test]
        public void load_dictionary_from_file()
        {
            var totalWords = _englishFileDictionaryWordValidator.Count();

            totalWords.Should().Be(370103);
        }

        [TestCase("")]
        [TestCase(null)]
        public void throw_no_found_dictionary_exception(string aGivenInvalidFilePath)
        {
            Action action = () => FileDictionaryWordValidator.FromFile(aGivenInvalidFilePath);

            action.Should().Throw<DictionaryNotFound>();
        }

        [Test]
        [TestCase("pOtatoes")]
        [TestCase("LIKE")]
        [TestCase("potatoes")]
        [TestCase("like")]
        public void return_empty_list_when_not_fount_words_with_same_length(string aGivenDictionaryData)
        {
            var englishFileDictionaryWordValidator = new FileDictionaryWordValidator(aGivenDictionaryData);

            var words = englishFileDictionaryWordValidator.SearchWordsByLength(aGivenDictionaryData.Length + 1);

            words.Should().BeEmpty();
        }

    

        [TestCase("pOtatoes")]
        [TestCase("LIKE")]
        [TestCase("potatoes")]
        [TestCase("like")]
        public void return_a_list_with_word(string aGivenDictionaryData)
        {
            var englishFileDictionaryWordValidator = new FileDictionaryWordValidator(aGivenDictionaryData);

            var words = englishFileDictionaryWordValidator.SearchWordsByLength(aGivenDictionaryData.Length);

            words.Should().OnlyContain((w) => w == aGivenDictionaryData);
        }
    }
}
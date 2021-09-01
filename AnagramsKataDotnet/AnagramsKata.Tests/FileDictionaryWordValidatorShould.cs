using System;
using FluentAssertions;
using NUnit.Framework;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class FileDictionaryWordValidatorShould
    {
        [Test]
        public void have_0_words_for_null_input()
        {
            var englishFileDictionaryWordValidator = new FileDictionaryWordValidator(null);

            var totalWords = englishFileDictionaryWordValidator.Count();

            totalWords.Should().Be(0);
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
            var englishFileDictionaryWordValidator = FileDictionaryWordValidator.FromFile("./Sources/en_words.txt");

            var totalWords = englishFileDictionaryWordValidator.Count();

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
        public void return_false_if_word_is_empty()
        {
            var englishFileDictionaryWordValidator = FileDictionaryWordValidator.FromFile("./Sources/en_words.txt");

            var isValidWord = englishFileDictionaryWordValidator.IsValid(string.Empty);

            isValidWord.Should().BeFalse();
        }

        [Test]
        public void return_false_if_word_is_null()
        {
            var englishFileDictionaryWordValidator = FileDictionaryWordValidator.FromFile("./Sources/en_words.txt");

            var isValidWord = englishFileDictionaryWordValidator.IsValid(null);

            isValidWord.Should().BeFalse();
        }

        [Test]
        public void return_false_if_word_do_not_exist_in_the_dictionary()
        {
            var englishFileDictionaryWordValidator = FileDictionaryWordValidator.FromFile("./Sources/en_words.txt");

            var isValidWord = englishFileDictionaryWordValidator.IsValid("adfasdfasd");

            isValidWord.Should().BeFalse();
        }


    }
}
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using NUnit.Framework;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class FileDictionaryWordValidatorShould
    {
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
    }
}
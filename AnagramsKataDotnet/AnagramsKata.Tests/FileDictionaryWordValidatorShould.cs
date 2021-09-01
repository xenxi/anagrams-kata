using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using NUnit.Framework;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class FileDictionaryWordValidatorShould
    {
        [Test]
        public void have_370103_words()
        {
            var englishFileDictionaryWordValidator = new FileDictionaryWordValidator();

            var totalWords = englishFileDictionaryWordValidator.Count();

            totalWords.Should().Be(370103);
        }
    }
}
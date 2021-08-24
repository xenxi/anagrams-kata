using FluentAssertions;
using NUnit.Framework;

namespace AnagramsKata.Tests
{
    [TestFixture]
    public class AnagramFinderShould
    {
        [Test]
        public void return_false_for_empty_input_string()
        {
            var anagramFinder = new AnagramFinder();
            var aGivenEmptyInputString = string.Empty;

            var isAnagram = anagramFinder.IsAnagram(aGivenEmptyInputString);

            isAnagram.Should().Be(false);
        }
    }

}
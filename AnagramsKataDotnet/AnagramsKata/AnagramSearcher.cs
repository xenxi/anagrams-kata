using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnagramsKata
{
    public class AnagramSearcher
    {
        private readonly IWordValidator wordValidator;

        public AnagramSearcher(IWordValidator validator)
        {
            this.wordValidator = validator;
        }

        public ICollection<string> Search(string aGivenEmptyInputString)
        {
            return GetAllAnagrams(new Word(aGivenEmptyInputString));
        }

        private ICollection<string> GetAllAnagrams(Word word)
        {
            if (word.Length < 2)
                return new Collection<string>();

            IEnumerable<Word> wordsWithSameLegth = wordValidator.SearchWordsByLength(word.Length);

            var anagrams = wordsWithSameLegth.Where(word.IsAnagramOf);

            return anagrams.Select(x => x.Value).ToList();
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnagramsKata
{
    public class AnagramSearcher
    {
        private WordValidator wordValidator;

        public AnagramSearcher()
        {
            this.wordValidator = new WordValidator();
        }

        public ICollection<string> Search(string aGivenEmptyInputString)
        {
            return GetAllAnagrams(new Word(aGivenEmptyInputString));
        }

        private ICollection<string> GetAllAnagrams(Word word)
        {
            if (word.GetCombinations().Distinct().Count() < 2)
                return new Collection<string>();

            return word.GetCombinations().Where(wordValidator.IsValid).ToList();
        }
    }
}
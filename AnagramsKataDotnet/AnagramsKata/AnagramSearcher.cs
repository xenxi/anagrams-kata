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
            return GetAllAnagrams(new StringValueObject(aGivenEmptyInputString));
        }

        private ICollection<string> GetAllAnagrams(StringValueObject stringValueObject)
        {
            if (stringValueObject.GetCombinations().Distinct().Count() < 2)
                return new Collection<string>();

            return stringValueObject.GetCombinations().Where(wordValidator.IsValid).ToList();
        }
    }
}
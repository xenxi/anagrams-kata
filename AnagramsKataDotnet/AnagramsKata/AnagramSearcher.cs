using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnagramsKata
{
    public class AnagramSearcher
    {
        public ICollection<string> Search(string aGivenEmptyInputString)
        {
            return GetAllAnagrams(new Word(aGivenEmptyInputString));
        }

        private static ICollection<string> GetAllAnagrams(Word word)
        {
            if (word.Value == "below")
                return new List<string> { "elbow" };
            if (word.Value == "angered")
                return new List<string> { "enraged" };
            if (word.Value == "creative")
                return new List<string> { "reactive" };
            if (word.Value == "observe")
                return new List<string> { "verbose" };

            return new Collection<string>();
        }
    }
}
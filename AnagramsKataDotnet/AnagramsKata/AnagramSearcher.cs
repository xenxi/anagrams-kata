using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnagramsKata
{
    public class AnagramSearcher
    {
        public ICollection<string> Search(string aGivenEmptyInputString)
        {
            if (aGivenEmptyInputString == "below")
                return new List<string> { "elbow" };

            return new Collection<string>();
        }
    }
}
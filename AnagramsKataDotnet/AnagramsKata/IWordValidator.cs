using System.Collections.Generic;

namespace AnagramsKata
{
    public interface IWordValidator
    {
        bool IsValid(string word);
        IEnumerable<Word> SearchWordsByLength(int length);
    }
}
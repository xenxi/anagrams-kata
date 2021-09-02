using System.Collections.Generic;

namespace AnagramsKata
{
    public interface IWordValidator
    {
        IEnumerable<Word> SearchWordsByLength(int length);
    }
}
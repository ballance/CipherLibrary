using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public class WordRecognizer
    {
        private readonly IEnumerable<string> _dictionary;

        public WordRecognizer(IEnumerable<string> dictionary)
        {
            _dictionary = dictionary;
        }

        public bool ContainsDictionaryWord(string candidateString)
        {
            return _dictionary.Any(word => word.Contains(candidateString));
        }
    }
}

using Library3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Library3
{
    public class Library : IEnumerable<Reader>
    {
        public string Name { get; }
        public string Address { get; }
        public int ReaderCount => _readers.Count;
        private readonly List<Reader> _readers;

        public Library(string name, string address, IEnumerable<Reader> readers)
        {
            Name = name;
            Address = address;
            _readers = readers
                .GroupBy(r => r.CardNumber)
                .Select(g => g.First())
                .ToList();
        }

        public IEnumerator<Reader> GetEnumerator() => _readers.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}



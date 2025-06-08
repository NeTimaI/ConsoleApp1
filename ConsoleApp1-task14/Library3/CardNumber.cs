using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3
{
    public class ReaderCardNumberComparer : IComparer<Reader>
    {
        public int Compare(Reader x, Reader y)
        {
            return string.Compare(x.CardNumber, y.CardNumber, StringComparison.Ordinal);
        }
    }
}
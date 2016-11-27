using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Service.Adapters
{
    public class ComparerAdapter:Comparer<Book>
    {
        public Comparison<Book> Comparison { get; set; }

        public ComparerAdapter(Comparison<Book> comparison)
        {
            Comparison = comparison;
        }

        public override int Compare(Book x, Book y) => Comparison(x,y);
    }
}

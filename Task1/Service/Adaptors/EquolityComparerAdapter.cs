using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Service.Adapters
{
    public class EquolityComparerAdapter : EqualityComparer<Book>
    {
        public Func<Book,Book,bool> EquolityComparer { get; set; }

        public EquolityComparerAdapter(Func<Book, Book, bool> equolityComparer)
        {
            EquolityComparer = equolityComparer;
        }

        public override bool Equals(Book x, Book y) => EquolityComparer(x, y);

        public override int GetHashCode(Book obj)
        {
            throw new NotImplementedException();
        }
    }
    
}
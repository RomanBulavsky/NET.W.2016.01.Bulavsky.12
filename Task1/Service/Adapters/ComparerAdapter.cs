using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookNS;

namespace Task1.Service.Adapters
{
    public class ComparerAdapter:Comparer<Book>
    {
        public Comparison<Book> Comparison { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="comparison"> Comparison delegate.</param>
        public ComparerAdapter(Comparison<Book> comparison)
        {
            Comparison = comparison;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type 
        /// and returns an integer that indicates whether the current instance precedes,
        /// follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="x">  Object with the Book type. </param>
        /// <param name="y">  Object with the Book type. </param>
        /// <returns>Integer that indicates whether the current instance precedes,
        /// follows, or occurs in the same position in the sort order as the other object.</returns>
        public override int Compare(Book x, Book y) => Comparison(x,y);
    }
}

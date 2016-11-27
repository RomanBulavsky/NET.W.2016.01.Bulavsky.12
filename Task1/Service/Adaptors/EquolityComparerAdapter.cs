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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equolityComparer"> Func delegate that takes 2 input Book type params and bool like return type.</param>
        public EquolityComparerAdapter(Func<Book, Book, bool> equolityComparer)
        {
            EquolityComparer = equolityComparer;
        }

        /// <summary>
        /// Indicates equality between Book type objects.
        /// </summary>
        /// <param name="x">Book type object for comparing.</param>
        /// <param name="y">Book type object for comparing. </param>
        /// <returns> Boolean value indicates equality of the parameters. </returns>
        public override bool Equals(Book x, Book y) => EquolityComparer(x, y);

        /// <summary>
        /// Computes a hash code of the Book type object.
        /// </summary>
        /// <returns> Integer type, hash code.</returns>
        public override int GetHashCode(Book obj)
        {
            return obj.GetHashCode();
        }
    }
    
}
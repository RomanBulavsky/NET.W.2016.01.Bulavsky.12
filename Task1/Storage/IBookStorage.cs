using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface IBookStorage<T> where T : class, IEnumerable
    {
        T Collection { get; }

        /// <summary>
        /// Load Books from storage.
        /// </summary>
        /// <returns> Collection of the books. </returns>
        T LoadBooks();

        /// <summary>
        /// Saves Book collection to the storage.
        /// </summary>
        /// <param name="collection"> Collection of the books.</param>
        void SaveBooks(T collection);
    }
}

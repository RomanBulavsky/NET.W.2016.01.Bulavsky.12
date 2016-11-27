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
        T Collection { get;set; }
        T LoadBooks();
        void SaveBooks(T collection);
    }
}

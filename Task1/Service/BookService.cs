using System;
using System.Collections.Generic;
using System.Linq;
using Task1.CustomException;
using Task1.Logger;
using Task1.Service.Adapters;
using ILogger = NLog.ILogger;

namespace Task1.Service
{
    class BookService
    {
        public SortedSet<Book> Collection { private set; get; }// Question about ref

        private IBookStorage<SortedSet<Book>> storage;        

        /// <summary>
        /// Constructors with different params.
        /// </summary>
        #region ctors
        public BookService()
        {
            storage = new BookSetStorage();
            Collection = new SortedSet<Book>();
        }

        public BookService(SortedSet<Book> collection)
        {
            if(collection == null) throw new ServiceException("Ctor collection exception", new ArgumentNullException());
            storage = new BookSetStorage();
            Collection = collection;
        }

        public BookService(IBookStorage<SortedSet<Book>> storage, SortedSet<Book> collection)
        {

            if (collection == null || storage == null) throw new ServiceException("Ctor storage or collection exception", new ArgumentNullException());
            this.storage = storage;
            Collection = collection;
        }
        #endregion

        /// <summary>
        /// Adds book into collection.
        /// </summary>
        /// <param name="newBook"> Book type, contender to add to the collection.</param>
        public void AddBook(Book newBook)
        {
            if (newBook != null)
                Collection.Add(newBook);
            else throw new ServiceException("Adding error", new ArgumentNullException());
        }

        /// <summary>
        /// Removes book from the collection.
        /// </summary>
        /// <param name="removingBook">Book type object for removing.</param>
        public void RemoveBook(Book removingBook)
        {
            if(removingBook != null)
                Collection.Remove(removingBook);
            else throw new ServiceException("Removing error", new ArgumentNullException());  
        }

    
        /// <summary>
        /// Indicates equality between objects and return one from the Collection if they are equal.
        /// </summary>
        /// <param name="customEqualityComparer"> EqualityComparer - rule for comparing.</param>
        /// <param name="book"> Book type object for compare.</param>
        /// <returns> Book type object.</returns>
        public Book FindBookByTag(EqualityComparer<Book> customEqualityComparer, Book book)
        {
            if (customEqualityComparer == null || book == null) throw new ServiceException("Bad params for finding", new ArgumentNullException());
            return  Collection.Single(o => customEqualityComparer.Equals(o, book));
        }

        /// <summary>
        /// Indicates equality between objects and return one from the Collection if they are equal.
        /// </summary>
        /// <param name="customEqualityComparer"> EqualityComparer - rule for comparing.</param>
        /// <param name="book"> Book type object for compare.</param>
        /// <returns> Book type object.</returns>
        public Book FindBookByTag(Func<Book, Book, bool> customEqualityComparer, Book book)
        {
            if(customEqualityComparer == null || book == null) throw new ServiceException("Bad params for finding", new ArgumentNullException());
            return FindBookByTag(new EquolityComparerAdapter(customEqualityComparer), book);
        }

        /// <summary>
        /// Sorts books in collection by the given rule.
        /// </summary>
        /// <param name="customComparer"> Comparer - rule for sorting.</param>
        public void SortBooksByTag(Comparer<Book> customComparer)
        {
            if (customComparer == null) throw new ServiceException("Bad Comparer");
            Collection = new SortedSet<Book>(Collection, customComparer);
        }

        /// <summary>
        /// Sorts books in collection by the given rule.
        /// </summary>
        /// <param name="customComparer"> Comparison - rule for sorting.</param>
        public void SortBooksByTag(Comparison<Book> customComparer)
        {
            if(customComparer == null) throw new ServiceException("Bad Comparison");
            Collection = new SortedSet<Book>(Collection, new ComparerAdapter(customComparer));
        }

        /// <summary>
        /// Shows inner sortedset.
        /// </summary>
        public void ShowCollection()
        {
            Collection?.ToList().ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Saves the Collection to the storage.
        /// </summary>
        public void Save()
        {
            storage.SaveBooks(Collection);
        }

        /// <summary>
        /// Load Books from storage to the Collection.
        /// </summary>
        public void Load()
        {
            Collection = storage.LoadBooks();
        }
    }
}

/*public Book FindBookByTag(Comparison<Book> comparison, Book book)
{
    return Collection?.Single(o => comparison(o, book) == 0);// Test Collection null but we have a ctor
}*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Service.Adapters;

/*BookListService (как сервис для работы с коллекцией книг) с
функциональностью AddBook (добавить книгу, если такой книги нет, в
противном случае выбросить исключение); RemoveBook (удалить книгу, если
она есть, в противном случае выбросить исключение); FindBookByTag (найти
книгу по заданному критерию); SortBooksByTag (отсортировать список книг по
заданному критерию).*/

namespace Task1.Service
{
    class BookService
    {
        public SortedSet<Book> Collection { private set; get; }// Question about
        private IBookStorage<SortedSet<Book>> storage;

        public void Save()
        {
            storage.SaveBooks(Collection);
        }

        public void Load()
        {
            Collection =  storage.LoadBooks();
        }

        public BookService(IBookStorage<SortedSet<Book>> storage, SortedSet<Book> collection)
        {
            this.storage = storage;
            Collection = collection;
        }

        public BookService(SortedSet<Book> collection)
        {
            storage = new BookSetStorage();
            Collection = collection;
        }

        public BookService()
        {
            storage = new BookSetStorage();
            Collection = new SortedSet<Book>();
        }
  
        public void AddBook(Book newBook)
        {
            if (newBook != null)
                Collection.Add(newBook);
            else throw new ArgumentNullException();
        }

        public void RemoveBook(Book removingBook)
        {
            if(removingBook == null)throw new ArgumentNullException();
            if (Collection.Contains(removingBook))
                Collection.Remove(removingBook);
           
        }

        
        /*public Book FindBookByTag(Comparison<Book> comparison, Book book)
        {
            return Collection?.Single(o => comparison(o, book) == 0);// Test Collection null but we have a ctor
        }*/

        public Book FindBookByTag(EqualityComparer<Book> customEqualityComparer, Book book)
        {
            if(ReferenceEquals(book,null)) throw new ArgumentNullException();
            return  Collection.Single(o => customEqualityComparer.Equals(o, book));
        }

        public Book FindBookByTag(Func<Book, Book, bool> customEqualityComparer, Book book)
        {
            return FindBookByTag(new EquolityComparerAdapter(customEqualityComparer), book);
            /*return Collection.FirstOrDefault(item => customEqualityComparer(item, book));*/
        }

        public void SortBooksByTag(Comparer<Book> customComparer)
        {
            Collection = new SortedSet<Book>(Collection, customComparer);
        }
        public void SortBooksByTag(Comparison<Book> customComparer)
        {
            Collection = new SortedSet<Book>(Collection, new ComparerAdapter(customComparer));
        }

        public void ShowCollection()
        {
            Collection.ToList().ForEach(Console.WriteLine);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using BookNS;
using BookNS.Storage;
using NLog;
using Task1.CustomException;
using Task1.Service;

namespace Task1
{
    class Program
    {
        
        public class AutorComparer : Comparer<Book>
        {
            public override int Compare(Book x, Book y) => x.Author.Equals(y.Author) ? 0 : string.Compare(x.Author, y.Author);
        }
        public class TitleComparer : Comparer<Book>
        {
            public override int Compare(Book x, Book y) => x.Title.Equals(y.Title) ? 0 : string.Compare(x.Title, y.Title);
        }

        public static void Main()
        {
            NLog.Logger logger = LogManager.GetCurrentClassLogger();

            try
            {
                
                //var x = new BookService();
                //x.Load();
                //x.ShowCollection();

                Book book1 = new Book("Roman", "Ditle", "Ganre", "Publisher", 4);
                Book book2 = new Book("Aoman2", "Bitle", "Ganre", "Publisher", 3);
                Book book3 = new Book("Roman3", "Aitle", "Ganre", "Publisher", 2);
                Book book4 = new Book("Roman4", "Title", "Ganre", "Publisher", 1);
                BookService bookService = new BookService();

                Console.WriteLine(book1 > book2);
                Console.WriteLine(book1.CompareTo(book2));

                bookService.AddBook(book1);
                bookService.AddBook(book2);
                bookService.AddBook(book3);
                bookService.AddBook(book4);

                //var x = new BookService(new BookSetStorageBinarySerializer(),bookService.Collection);
                //x.Save();
                //BookService x = new BookService(new BookSetStorageBinarySerializer());
                //x.Load();

                //var x = new BookService(new BookSetStorageXmlSerializer(),bookService.Collection);
                //x.Save();
                //BookService z = new BookService(new BookSetStorageXmlSerializer());
                //z.Load();



                //bookService.ShowCollection();

                var found = bookService.FindBookByTag((a, b) => a.Author == b.Author, book2);
                Console.WriteLine($"found: {found}");

                found = bookService.FindBookByTag((a, b) => a.Title == b.Title, book2);
                Console.WriteLine($"found by title: {found}");

                Console.WriteLine("Standart Sort");
                bookService.Collection.ToList().Sort();
                bookService.ShowCollection();

                Console.WriteLine("new Sort: (a, b) => a.NumberOfPages - b.NumberOfPages)");
                bookService.SortBooksByTag((a, b) => a.NumberOfPages - b.NumberOfPages);
                bookService.ShowCollection();

                Console.WriteLine("new Sort: Custom comparer");
                AutorComparer zzz = null;//TODO: Use it to create error.log
                bookService.SortBooksByTag(new AutorComparer());///zzz);
                bookService.ShowCollection();


                Console.WriteLine("new Sort: Custom comparer");
                bookService.SortBooksByTag(new TitleComparer());
                bookService.ShowCollection();

                //bookService.Save();

                Console.ReadKey();

            }
            catch (StorageException e)
            {
                logger.Fatal(e.Message,e.StackTrace);
            }
            catch (ServiceException e)
            {
                logger.Error(e.Message);
            }
        }
    }
}
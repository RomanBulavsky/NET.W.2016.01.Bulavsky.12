using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Task1.Service;

namespace Task1
{
    class Program
    {
        
        public class AutorComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                if (x.Author.Equals(y.Author)) return 0;
                return string.Compare(x.Author, y.Author);
            }
        }

        public static void Main()
        {
            //var x = new BookService();
            //x.Load();
            //x.ShowCollection();
            NLog.Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                Book book1 = new Book("Roman", "Title", "Ganre", "Publisher", 4);
                Book book2 = new Book("Aoman2", "Title", "Ganre", "Publisher", 3);
                Book book3 = new Book("Roman3", "Title", "Ganre", "Publisher", 2);
                Book book4 = new Book("Roman4", "Title", "Ganre", "Publisher", 1);
                BookService bookService = new BookService();






                Console.WriteLine(book1 > book2);
                Console.WriteLine(book1.CompareTo(book2));


                bookService.AddBook(book1);
                bookService.AddBook(book2);
                bookService.AddBook(book3);
                bookService.AddBook(book4);
                bookService.ShowCollection();


                var found = bookService.FindBookByTag((a, b) => a.Author == b.Author, book2);
                Console.WriteLine($"found: {found}");


                Console.WriteLine("Standart Sort");
                bookService.Collection.ToList().Sort();
                bookService.ShowCollection();

                Console.WriteLine("new Sort: (a, b) => a.NumberOfPages - b.NumberOfPages)");
                bookService.SortBooksByTag((a, b) => a.NumberOfPages - b.NumberOfPages);
                bookService.ShowCollection();

                Console.ReadKey();

            }
            catch (Exception e)
            {
                logger.Fatal(e.StackTrace);
            }
            //bookService.Save();
        }
    }
}
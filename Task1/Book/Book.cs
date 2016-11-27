using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Разработать класс Book с 4-5 свойствами, переопределив для него
необходимые методы класса Object. Для объектов класса реализовать
отношения эквивалентности и порядка. Для выполнения основных операций со
списком книг, который ​можно ​загрузить и, ​если возникнет необходимость ​,
сохранить в некоторое хранилище BookSetStorage разработать класс
BookListService (как сервис для работы с коллекцией книг) с
функциональностью AddBook (добавить книгу, если такой книги нет, в
противном случае выбросить исключение); RemoveBook (удалить книгу, если
она есть, в противном случае выбросить исключение); FindBookByTag (найти
книгу по заданному критерию); SortBooksByTag (отсортировать список книг по
заданному критерию). Реализовать возможность логирования сообщений
различного уровня. Работу классов продемонстрировать на примере
консольного приложения.
В качестве хранилища использовать
- двоичный файл, для работы с которым использовать только классы
BinaryReader, BinaryWriter ​. ​Хранилище в дальнейшем может измениться
(добавиться)
 */
namespace Task1
{
    public class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        public string Author { get; }
        public string Title { get; }
        public string Genre { get; }
        public string Publisher { get; }
        public int NumberOfPages { get; }

        public Book()
        {
        }

        public override string ToString() => $"{this.Title} by {this.Author} in {this.Genre} genre, published by {this.Publisher} with {this.NumberOfPages} pages";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="author">Author name.</param>
        /// <param name="title">Title of the book.</param>
        /// <param name="genre">Ganre of the book.</param>
        /// <param name="publisher">Publisher.</param>
        /// <param name="numberOfPages">Number of pages.</param>
        public Book(string author, string title, string genre, string publisher, int numberOfPages)
        {
            Author = author;
            Title = title;
            Genre = genre;
            Publisher = publisher;
            NumberOfPages = numberOfPages;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Author, other.Author) && string.Equals(Title, other.Title) 
                && string.Equals(Genre, other.Genre) && string.Equals(Publisher, other.Publisher) 
                && NumberOfPages == other.NumberOfPages;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Author.GetHashCode();
                hashCode = (hashCode * 397) ^ Title.GetHashCode();
                hashCode = (hashCode * 397) ^ Genre.GetHashCode();
                hashCode = (hashCode * 397) ^ Publisher.GetHashCode();
                hashCode = (hashCode * 397) ^ NumberOfPages;
                return hashCode;
            }
        }

        public static bool operator ==(Book left, Book right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Book left, Book right)
        {
            return !Equals(left, right);
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var authorComparison = string.Compare(Author, other.Author, StringComparison.Ordinal);
            if (authorComparison != 0) return authorComparison;
            var titleComparison = string.Compare(Title, other.Title, StringComparison.Ordinal);
            if (titleComparison != 0) return titleComparison;
            var genreComparison = string.Compare(Genre, other.Genre, StringComparison.Ordinal);
            if (genreComparison != 0) return genreComparison;
            var publisherComparison = string.Compare(Publisher, other.Publisher, StringComparison.Ordinal);
            if (publisherComparison != 0) return publisherComparison;
            return NumberOfPages.CompareTo(other.NumberOfPages);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (!(obj is Book)) throw new ArgumentException($"Object must be of type {nameof(Book)}");
            return CompareTo((Book) obj);
        }
        
        public static bool operator <(Book left, Book right)
        {
            return Comparer<Book>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(Book left, Book right)
        {
            return Comparer<Book>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(Book left, Book right)
        {
            return Comparer<Book>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(Book left, Book right)
        {
            return Comparer<Book>.Default.Compare(left, right) >= 0;
        }
    }
}

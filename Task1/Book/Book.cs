using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BookNS
{
    [Serializable]
    public class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        //[XmlElement("Author")]
        public string Author { get; set; }
        //[XmlElement("Title")]
        public string Title { get; set; }
        //[XmlElement("Genre")]
        public string Genre { get; set; }
        //[XmlElement("Publisher")]
        public string Publisher { get; set; }
        //[XmlElement("NumberOfPages")]
        public int NumberOfPages { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Book():this("Smith", "Jhon", "Comedy", "JS", 1233){}
      

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="author">Author name.</param>
        /// <param name="title">Title of the book.</param>
        /// <param name="genre">Ganre of the book.</param>
        /// <param name="publisher">Publisher.</param>
        /// <param name="numberOfPages">Number of pages.</param>
        public Book(string author, string title, string genre, string publisher, int numberOfPages)
        {
            if (author == null || title == null || genre == null || publisher == null || numberOfPages < 1)
            {

                throw new ArgumentNullException();
            }
            Author = author;
            Title = title;
            Genre = genre;
            Publisher = publisher;
            NumberOfPages = numberOfPages;
        }

        /// <summary>
        /// Indicates equality between Book type objects.
        /// </summary>
        /// <param name="other"> Book type object for comparing. </param>
        /// <returns> Boolean value indicates equality of the parameters. </returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Author, other.Author) && string.Equals(Title, other.Title) 
                && string.Equals(Genre, other.Genre) && string.Equals(Publisher, other.Publisher) 
                && NumberOfPages == other.NumberOfPages;
        }

        /// <summary>
        /// Indicates equality between objects.
        /// </summary>
        /// <param name="obj"> Object for comparing. </param>
        /// <returns> Boolean value indicates equality of the parameters. </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book) obj);
        }

        /// <summary>
        /// Computes a hash code of the Book type object.
        /// </summary>
        /// <returns> Integer type, hash code.</returns>
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

        /// <summary>
        /// Works like Equals.
        /// </summary>
        /// <param name="left"> Book type object for comparing. </param>
        /// <param name="right"> Book type object for comparing. </param>
        /// <returns> Boolean value indicates equality of the parameters.</returns>
        public static bool operator ==(Book left, Book right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Works like inverse Equals Method.
        /// </summary>
        /// <param name="left"> Object for comparing.</param>
        /// <param name="right"> Object for comparing.</param>
        /// <returns> Boolean value indicates non-equality of the parameters.</returns>
        public static bool operator !=(Book left, Book right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type 
        /// and returns an integer that indicates whether the current instance precedes,
        /// follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj"> Object with the Book type. </param>
        /// <returns> Integer that indicates whether the current instance precedes,
        /// follows, or occurs in the same position in the sort order as the other object.</returns>
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

        /// <summary>
        /// Compares the current instance with another object of the same type 
        /// and returns an integer that indicates whether the current instance precedes,
        /// follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj"> Object with the object type.</param>
        /// <returns>Integer that indicates whether the current instance precedes,
        /// follows, or occurs in the same position in the sort order as the other object.</returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (!(obj is Book)) throw new ArgumentException($"Object must be of type {nameof(Book)}");
            return CompareTo((Book) obj);
        }

        /// <summary>
        /// Represents Book type like a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{this.Title} by {this.Author} in {this.Genre} genre, published by : {this.Publisher} that contains {this.NumberOfPages} pages";

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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Task1
{
    class BookSetStorage : IBookStorage<SortedSet<Book>>
    {
        public SortedSet<Book> Collection { get; private set; }

        /// <summary>
        /// Load Books from storage.
        /// </summary>
        /// <returns> Collection of the books. </returns>
        public SortedSet<Book> LoadBooks()
        {
            Collection = new SortedSet<Book>();
            try
            {
                using (var f = new BinaryReader(new BufferedStream(File.Open(ConfigurationManager.AppSettings["StoragePath"], FileMode.Open))))
                {
                    while (f.BaseStream.Position < f.BaseStream.Length)
                    {
                        var author = f.ReadString();
                        var title = f.ReadString();
                        var genre = f.ReadString();
                        var publisher = f.ReadString();
                        var numberOfPages = f.ReadInt32();
                        Collection.Add(new Book(author, title, genre, publisher, numberOfPages));
                    }
                }
            }
            catch (IOException e)
            {
                throw new Exception(); //TODO: Wrapper
            }
            return Collection;
        }

        /// <summary>
        /// Saves Book collection to the storage.
        /// </summary>
        /// <param name="collection"> Collection of the books.</param>
        public void SaveBooks(SortedSet<Book> collection)
        {
            if(collection == null) throw new ArgumentNullException();
            try
            {
                using (var f = new BinaryWriter(new BufferedStream(File.Open(ConfigurationManager.AppSettings["StoragePath"],FileMode.OpenOrCreate))))
                {
                    foreach (var item in collection)
                    {
                        f.Write(item.Author);
                        f.Write(item.Title);
                        f.Write(item.Genre);
                        f.Write(item.Publisher);
                        f.Write(item.NumberOfPages);
                    }
                }
            }
            catch (IOException e)
            {
                throw new Exception(); //TODO: Wrapper
            }
    }
}

}
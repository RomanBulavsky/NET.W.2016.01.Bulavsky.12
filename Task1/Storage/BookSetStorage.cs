using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Для выполнения основных операций со
списком книг, который ​можно ​загрузить и, ​если возникнет необходимость ​,
сохранить в некоторое хранилище BookSetStorage

 В качестве хранилища использовать
- двоичный файл, для работы с которым использовать только классы
BinaryReader, BinaryWriter ​. ​Хранилище в дальнейшем может измениться
(добавиться)*/

namespace Task1
{
    class BookSetStorage : IBookStorage<SortedSet<Book>>
    {
        public SortedSet<Book> Collection { get; set; }

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

        public void SaveBooks(SortedSet<Book> collection)
        {
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
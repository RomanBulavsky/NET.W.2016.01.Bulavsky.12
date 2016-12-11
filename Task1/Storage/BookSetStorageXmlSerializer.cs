using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Task1;
using Task1.CustomException;

namespace BookNS.Storage
{
    class BookSetStorageXmlSerializer : IBookStorage<SortedSet<Book>>
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
                using (var f = new FileStream(ConfigurationManager.AppSettings["XMLSerializationPath"], FileMode.OpenOrCreate))//new BinaryReader( new BufferedStream(File.Open(ConfigurationManager.AppSettings["BinSerializationPath"], FileMode.Open))))
                {

                    var formatter = new XmlSerializer(typeof(List<Book>));
                    var l = (List<Book>)formatter.Deserialize(f);
                    Collection = new SortedSet<Book>(l);
                }
            }
            catch (FormatException e)
            {
                throw new StorageException("Format Exception", e);
            }
            catch (IOException e)
            {
                throw new StorageException("Loading IO Exception", e);
            }
            if (Collection.Count < 1)
                throw new StorageException("Loading Exception");

            return Collection;
        }

        /// <summary>
        /// Saves Book collection to the storage.
        /// </summary>
        /// <param name="collection"> Collection of the books.</param>
        public void SaveBooks(SortedSet<Book> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            if (collection.Count < 1) throw new StorageException("Can't save empty collection.");
            try
            {
                using (var f = new FileStream(ConfigurationManager.AppSettings["XMLSerializationPath"],
                            FileMode.OpenOrCreate))
                {
                    List<Book> l = collection.ToList();
                    var formatter = new XmlSerializer(typeof(List<Book>));
                    formatter.Serialize(f, l);
                }
            }
            catch (FormatException e)
            {
                throw new StorageException("Format Exception", e);
            }
            catch (IOException e)
            {
                throw new StorageException("Saving Exception", e);
            }
        }
    }
}

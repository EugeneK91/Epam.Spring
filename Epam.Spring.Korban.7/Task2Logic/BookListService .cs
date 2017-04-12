using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Task2Logic
{
    public class BookListService : IBookListService
    {
        #region Fields
        /// <summary>
        /// path for repository
        /// </summary>
        private readonly string path;
        #endregion

        #region Constructors
        public BookListService()
        {
            path = Directory.GetCurrentDirectory() + "/Book.txt";
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// add book into repository
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            ValidatingBook(book);

            var list = GetBooks();

            if (list.Contains(book))
                throw new Exception(nameof(book));

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
            {
                writer.Write(book.Id);
                writer.Write(book.Title);
                writer.Write(book.Author);
                writer.Write(book.Size);
            }
        }

        /// <summary>
        /// find book by condition from repository
        /// </summary>
        /// <param name="books"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Book FindByTag(List<Book> books, Predicate<Book> predicate)
        {
            ValidatingBooks(books);

            return books.Find(predicate);
        }

        /// <summary>
        /// get all books from repository
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooks()
        {
            var list = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() >-1)
                {
                    list.Add(new Book
                    {
                        Id = reader.ReadInt32(),
                        Title = reader.ReadString(),
                        Author = reader.ReadString(),
                        Size = reader.ReadInt32()
                    });
                }
            };
            return list;
        }

        /// <summary>
        /// remove book from repository
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            ValidatingBook(book);
            var books = GetBooks();

            if (!books.Contains(book))
                throw new ArgumentException(nameof(book));

            books.Remove(book);
            File.Delete(path);
            AddBooks(books);
        }

        /// <summary>
        /// sort books by condition
        /// </summary>
        /// <param name="books"></param>
        /// <param name="predicate"></param>
        public void SortBooksByTag(List<Book> books, Comparison<Book> predicate =null)
        {
            ValidatingBooks(books);
            if (predicate == null) books.Sort();
            else books.Sort(predicate);
        }

        /// <summary>
        /// print all books
        /// </summary>
        /// <param name="books"></param>
        public void PrintBooks(List<Book> books)
        {
            ValidatingBooks(books);
            foreach (var book in books)
            {
                Console.WriteLine("{0} {1} {2} {3}", book.Id, book.Author, book.Title, book.Size);
            }
            Console.WriteLine();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// add list of books to repository
        /// </summary>
        /// <param name="books"></param>
        private void AddBooks(List<Book> books)
        {
            ValidatingBooks(books);
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Id);
                    writer.Write(book.Title);
                    writer.Write(book.Author);
                    writer.Write(book.Size);
                }
            }
        }

        /// <summary>
        /// validating books for null
        /// </summary>
        /// <param name="books"></param>
        private void ValidatingBooks(List<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException(nameof(books));
        }


        /// <summary>
        /// validating book for null
        /// </summary>
        /// <param name="book"></param>
        private void ValidatingBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
        }
        #endregion
    }
}

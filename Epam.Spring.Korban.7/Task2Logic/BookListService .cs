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
        private readonly string path;

        public BookListService()
        {
            path = Directory.GetCurrentDirectory() + "/Book.txt";
        }
        public void AddBook(Book book)
        {
            var list = GetBooks();
            if (list.Contains(book))
                throw new Exception(nameof(book));
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(book.Id);
                writer.Write(book.Title);
                writer.Write(book.Author);
                writer.Write(book.Size);
            }
        }

        public Book FindByTag(List<Book> books, Func<Book, bool> predicate)
        {
            return books.FirstOrDefault(predicate);
        }



        public List<Book> GetBooks()
        {
            var list = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
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

        public void RemoveBook(Book book)
        {
            var books = GetBooks();
            books.Remove(book);
            File.Delete(path);
            books.ForEach(b => AddBook(b));
        }

        public void SortBooksByTag(List<Book> books, Func<Book, bool> predicate)
        {
            books.OrderBy(;
        }

    }
}

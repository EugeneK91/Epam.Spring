using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    interface IBookListService
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        Book FindByTag(List<Book> books, Func<Book, bool> predicate);
        void SortBooksByTag(List<Book> books,Func<Book,bool> predicate);
        List<Book> GetBooks();
    }
}

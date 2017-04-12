using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookService = new BookListService();

            bookService.AddBook(new Book { Author="Michael Bulgacov",Id = 1,Title="Master",Size = 500} );
            bookService.AddBook(new Book { Author = "Jack London", Id = 2, Title = "Canine", Size = 750 });
            bookService.AddBook(new Book { Author = "Gogol", Id = 3, Title = "Dead souls", Size = 415 });
            bookService.AddBook(new Book { Author = "Pushkin", Id = 4, Title = "Nanny", Size = 600 });
            bookService.AddBook(new Book { Author = "Gerbert Frank", Id = 5, Title = "Dune", Size = 500 });
            bookService.AddBook(new Book { Author = "Strugackie", Id = 6, Title = "Monday starting in Saturday", Size = 500 });
            
            var list = bookService.GetBooks();
            list.Sort();
            var t = bookService.FindByTag(list, c => c.Id == 1);
           // bookService.SortBooksByTag(list, c => c.Id);
        }
    }
}

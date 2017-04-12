using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    public class Book:IEquatable<Book>,IComparable<Book>
    {
        public  int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Size { get; set; }


        public int CompareTo(Book obj)
        {
            if (this.Id > obj.Id)
                return 1;
            if (this.Id < obj.Id)
                return -1;
            else
                return 0;
        }

        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
                return false;

            return (this.Id == book.Id || ( this.Size == book.Size && this.Title == book.Title && this.Author == book.Author));
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Book book = obj as Book;
            if (book == null)
                return false;
            else
                return Equals(book);
        }
        public override int GetHashCode()
        {
            return (this.Id*this.Size).GetHashCode();
        }

        public static bool operator ==(Book book1, Book book2)
        {
            if (((object)book1) == null || ((object)book2) == null)
                return Object.Equals(book1, book2);

            return book1.Equals(book2);
        }

        public static bool operator !=(Book book1, Book book2)
        {
            if (((object)book1) == null || ((object)book2) == null)
                return !Object.Equals(book1, book2);

            return !(book1.Equals(book2));
        }


        public static bool operator <(Book book1, Book book2)
        {
            if (ReferenceEquals(book1, null))
                return false;

            else
                return (book1.CompareTo(book2) < 0) ? true : false;
        }

        public static bool operator >(Book book1, Book book2)
        {
            if (ReferenceEquals(book1, null))
                return false;

            else
                return (book1.CompareTo(book2) > 0) ? true : false;
        }

        public static bool operator <=(Book book1, Book book2)
        {
            return (book1 < book2) || (book1 == book2);
        }

        public static bool operator >=(Book book1, Book book2)
        {
            return (book1 > book2) || (book1 == book2);
        }
    }
}

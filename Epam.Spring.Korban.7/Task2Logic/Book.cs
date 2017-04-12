using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    public class Book:IEquatable<Book>,IComparable<Book>
    {

        #region Properties
        /// <summary>
        /// Id
        /// </summary>
        public  int Id { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Author
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Size
        /// </summary>
        public int Size { get; set; }
        #endregion

        #region Constructors
        public Book() { }
        #endregion

        #region Public Methods

        /// <summary>
        /// implementation CompareTo of IComparableInterface
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Book obj)
        {
            if (this.Id > obj.Id)
                return 1;
            if (this.Id < obj.Id)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// implementation equals of Iquatable
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
                return false;

            return (this.Id == book.Id || ( this.Size == book.Size && this.Title == book.Title && this.Author == book.Author));
        }

        /// <summary>
        /// override equals for object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            var book = obj as Book;
            if (book == null)
                return false;
            else
                return Equals(book);
        }
        public override int GetHashCode()
        {
            return (this.Id*this.Size).GetHashCode();
        }


        /// <summary>
        /// override == 
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator ==(Book book1, Book book2)
        {
            if (((object)book1) == null || ((object)book2) == null)
                return Equals(book1, book2);

            return book1.Equals(book2);
        }

        /// <summary>
        /// override !=
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator !=(Book book1, Book book2)
        {
            if (((object)book1) == null || ((object)book2) == null)
                return !Equals(book1, book2);

            return !(book1.Equals(book2));
        }

        /// <summary>
        /// override <
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator <(Book book1, Book book2)
        {
            if (ReferenceEquals(book1, null))
                return false;

            else
                return (book1.CompareTo(book2) < 0);
        }

        /// <summary>
        /// override >
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator >(Book book1, Book book2)
        {
            if (ReferenceEquals(book1, null))
                return false;

            else
                return (book1.CompareTo(book2) > 0);
        }

        /// <summary>
        /// override <=
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator <=(Book book1, Book book2)
        {
            return (book1 < book2) || (book1 == book2);
        }

        /// <summary>
        /// override >=
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator >=(Book book1, Book book2)
        {
            return (book1 > book2) || (book1 == book2);
        }
        #endregion
    }
}

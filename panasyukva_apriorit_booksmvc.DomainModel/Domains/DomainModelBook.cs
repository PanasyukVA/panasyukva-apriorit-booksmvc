using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using panasyukva_apriorit_booksmvc.DAL;
using panasyukva_apriorit_booksmvc.ViewModel;

namespace panasyukva_apriorit_booksmvc.DomainModel.Domains
{
    public class DomainModelBook
    {
        SelfEducationEntities context;

        public DomainModelBook() {
            context = new SelfEducationEntities();
        }

        public ViewModelBook GetBook(int bookId)
        {
            Book DALBook = context.Book.Where(book => book.ID == bookId).FirstOrDefault();
            List<ViewModelAuthor> vmBookAuthors = new List<ViewModelAuthor>();
            foreach (var author in DALBook.Author)
                vmBookAuthors.Add(new ViewModelAuthor() { AuthorID = author.ID, AuthorName = author.Name });
            return new ViewModelBook() { BookID = DALBook.ID, BookName = DALBook.Name, Authors = vmBookAuthors };
        }

        public ViewModelBook CreateBook(ViewModelBook vmBook)
        {
            List<Author> DALBookAuthors = new List<Author>();
            foreach (var author in vmBook.Authors)
                DALBookAuthors.Add(new Author() { ID = (int)author.AuthorID, Name = author.AuthorName });
            context.Book.Add(new Book() { Name = vmBook.BookName, Author = DALBookAuthors });
            context.SaveChanges();
            return vmBook;
        }

        public ViewModelBook EditBook(ViewModelBook vmBook)
        {
            Book DALBook = context.Book.Where(book => book.ID == vmBook.BookID).FirstOrDefault();
            DALBook.Name = vmBook.BookName;
            List<Author> DALBookAuthors = new List<Author>();
            foreach (var author in vmBook.Authors)
                DALBookAuthors.Add(new Author() { ID = (int)author.AuthorID, Name = author.AuthorName });
            DALBook.Author = DALBookAuthors;
            context.SaveChanges();
            return vmBook;
        }

        public void RemoveBook(ViewModelBook vmBook)
        {
            Book DALBook = context.Book.Where(book => book.ID == vmBook.BookID).FirstOrDefault();
            context.Book.Remove(DALBook);
            context.SaveChanges();
        }
    }
}

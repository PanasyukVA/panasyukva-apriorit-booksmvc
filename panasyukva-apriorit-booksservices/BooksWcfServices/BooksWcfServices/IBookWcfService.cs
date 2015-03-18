using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BooksMVC.DAL;

namespace BooksWcfServices
{
    [ServiceContract]
    public interface IBookWcfService
    {
        [OperationContract]
        ICollection<AuthorViewModel> GetAuthors();

        [OperationContract]
        ICollection<BookViewModel> GetBooks();

        [OperationContract]
        BookViewModel GetBook(int bookId);

        [OperationContract]
        BookViewModel CreateBook(BookViewModel vmBook);

        BookViewModel EditBook(BookViewModel vmBook);

        [OperationContract]
        void RemoveBook(BookViewModel vmBook);
    }

    [DataContract]
    public class BookViewModel
    {
        [DataMember]
        public int? BookID { get; set; }

        [DataMember]
        public string BookName { get; set; }

        [DataMember]
        public ICollection<AuthorViewModel> Authors { get; set; }

        [DataMember]
        public IEnumerable<string> SelectedAuthors { get; set; } 
    }
}

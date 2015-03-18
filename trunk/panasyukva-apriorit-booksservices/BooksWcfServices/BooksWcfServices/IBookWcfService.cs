using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BooksMVC.DAL;

namespace BooksWcfServices
{
    [ServiceContract(Namespace = "http://http://www.apriorit.com/PanasyukVA/Services")]
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

        [OperationContract]
        BookViewModel EditBook(BookViewModel vmBook);

        [OperationContract]
        void RemoveBook(BookViewModel vmBook);
    }

    [DataContract(Namespace="http://http://www.apriorit.com/PanasyukVA/Services")]
    public class BookViewModel
    {
        [DataMember]
        public int? BookID { get; set; }

        [DataMember(IsRequired = true)]
        public string BookName { get; set; }

        [DataMember(IsRequired = true)]
        public ICollection<AuthorViewModel> Authors { get; set; }

        [DataMember(IsRequired = true)]
        public IEnumerable<string> SelectedAuthors { get; set; } 
    }
}

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
        ICollection<AuthorServiceModel> GetAuthors();

        [OperationContract]
        ICollection<BookServiceModel> GetBooks();

        [OperationContract]
        BookServiceModel GetBook(int bookId);

        [OperationContract]
        BookServiceModel CreateBook(BookServiceModel vmBook);

        [OperationContract]
        BookServiceModel EditBook(BookServiceModel vmBook);

        [OperationContract]
        void RemoveBook(BookServiceModel vmBook);
    }

    [DataContract]
    public class BookServiceModel
    {
        [DataMember]
        public int? BookID { get; set; }

        [DataMember(IsRequired = true)]
        public string BookName { get; set; }

        [DataMember(IsRequired = true)]
        public ICollection<AuthorServiceModel> Authors { get; set; }

        [DataMember(IsRequired = true)]
        public IEnumerable<string> SelectedAuthors { get; set; } 
    }
}

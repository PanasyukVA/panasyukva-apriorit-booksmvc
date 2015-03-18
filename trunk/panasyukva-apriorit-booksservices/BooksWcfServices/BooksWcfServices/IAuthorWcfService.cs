using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BooksMVC.DAL;

namespace BooksWcfServices
{
    [ServiceContract]
    public interface IAuthorWcfService
    {
        [OperationContract]
        AuthorViewModel GetAuthor(int authorId);

        [OperationContract]
        AuthorViewModel CreateAuthor(AuthorViewModel vmAuthor);

        [OperationContract]
        AuthorViewModel EditAuthor(AuthorViewModel vmAuthor);
    }


    [DataContract]
    public class AuthorViewModel
    {
        [DataMember]
        public int? AuthorID { get; set; }
        
        [DataMember]
        public string AuthorName { get; set; }
        
        [DataMember]
        public string Books { get; set; }
    }
}

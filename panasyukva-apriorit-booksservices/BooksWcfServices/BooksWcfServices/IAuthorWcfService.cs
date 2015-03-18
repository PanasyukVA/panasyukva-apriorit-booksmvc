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
    [ServiceContract(Namespace = "http://http://www.apriorit.com/PanasyukVA/Services")]
    public interface IAuthorWcfService
    {
        [OperationContract]
        AuthorViewModel GetAuthor(int authorId);

        [OperationContract]
        AuthorViewModel CreateAuthor(AuthorViewModel vmAuthor);

        [OperationContract]
        AuthorViewModel EditAuthor(AuthorViewModel vmAuthor);
    }


    [DataContract(Namespace = "http://http://www.apriorit.com/PanasyukVA/Services")]
    public class AuthorViewModel
    {
        [DataMember]
        public int? AuthorID { get; set; }
        
        [DataMember(IsRequired = true)]
        public string AuthorName { get; set; }
        
        [DataMember]
        public string Books { get; set; }
    }
}

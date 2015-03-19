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
        AuthorServiceModel GetAuthor(int authorId);

        [OperationContract]
        AuthorServiceModel CreateAuthor(AuthorServiceModel vmAuthor);

        [OperationContract]
        AuthorServiceModel EditAuthor(AuthorServiceModel vmAuthor);
    }


    [DataContract]
    public class AuthorServiceModel
    {
        [DataMember]
        public int? AuthorID { get; set; }
        
        [DataMember(IsRequired = true)]
        public string AuthorName { get; set; }
        
        [DataMember]
        public string Books { get; set; }
    }
}

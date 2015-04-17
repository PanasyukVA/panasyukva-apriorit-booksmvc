namespace Books.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Books.ViewModel;
    using Books.DomainModel.Domains;

    public class AuthorsEditorFor
    {
        public AuthorsEditorFor(ICollection<string> selectedAuthors, ICollection<AuthorViewModel> allAuthors)
        {
            SelectedAuthors = selectedAuthors;
            AllAuthors = allAuthors;
        }

        public ICollection<string> SelectedAuthors { get; set; }
        public ICollection<AuthorViewModel> AllAuthors { get; set; }
    }
}
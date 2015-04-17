namespace Books.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Books.ViewModel;

    public class BookViewModelEditroFor : BookViewModel
    {
        public BookViewModelEditroFor(BookViewModel viewModel, ICollection<AuthorViewModel> authors)
        {
            this.BookId = viewModel.BookId;
            this.BookName = viewModel.BookName;
            this.Authors = new AuthorsEditorFor(viewModel.SelectedAuthors.ToArray(), authors);
        }

        public AuthorsEditorFor Authors { get; set; }
    }
}
// The Model namespace
var Model = Model || {};

// The book class
Model.book = function (id, name, authors, selectedAuthors) {
    this.bookId = id;
    this.bookName = name;
    this.bookAuthors = authors;
    this.bookSelectedAuthors = selectedAuthors;
}
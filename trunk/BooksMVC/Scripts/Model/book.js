// The Model namespace
var Model = Model || {};

// The book class
Model.book = function (id, name, auth, selectedAuth) {
    this.bookId = id;
    this.bookName = name;
    this.authors = auth;
    this.selectedAuthors = selectedAuth;
}
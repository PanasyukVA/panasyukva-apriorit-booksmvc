// The Entity namespace
var Entity = Entity || {};

// The book class
Entity.book = function (id, name, auth, selectedAuth) {
    this.bookId = id;
    this.bookName = name;
    this.authors = auth;
    this.selectedAuthors = selectedAuth;
}
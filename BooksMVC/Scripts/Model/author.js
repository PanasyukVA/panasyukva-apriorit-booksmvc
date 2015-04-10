// The Model namespace
var Model = Model || {};

// The author class
Model.author = function (id, name, books) {
    this.authorId = id;
    this.authorName = name;
    this.authorBooks = books;
}

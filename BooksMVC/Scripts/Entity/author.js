// The Entity namespace
var Entity = Entity || {};

// The author class
Entity.author = function (id, name, books) {
    this.authorId = id;
    this.authorName = name;
    this.authorBooks = books;
}

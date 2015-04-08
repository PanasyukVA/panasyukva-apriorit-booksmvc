/// <reference path="knockout-3.3.0.js" />

function bookViewModel(book) {
    this.bookId = ko.observable(book.bookId);
    this.bookName = ko.observable(book.bookName);
    this.authors = ko.observableArray(book.bookAuthors);
    this.selectedAuthors = ko.observableArray(book.bookSelectedAuthors);
}
/// <reference path="../knockout-3.3.0.js" />

// The ViewModel namespace
var ViewModel = ViewModel || {};

// The bookViewModel class
ViewModel.bookViewModel = function (book) {
    this.bookId = ko.observable(book.bookId);
    this.bookName = ko.observable(book.bookName);
    this.bookAuthors = ko.observableArray(book.bookAuthors);
    this.bookSelectedAuthors = ko.observableArray(book.bookSelectedAuthors);
}

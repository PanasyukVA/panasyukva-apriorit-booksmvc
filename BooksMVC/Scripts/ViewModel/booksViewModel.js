/// <reference path="../knockout-3.3.0.js" />

// The ViewModel namespace
var ViewModel = ViewModel || {};

// The booksViewModel class
ViewModel.booksViewModel = function() {
    this.books = ko.observableArray([]);
}
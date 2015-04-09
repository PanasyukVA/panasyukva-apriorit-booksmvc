/// <reference path="../knockout-3.3.0.js" />

// The ViewModel namespace
var ViewModel = ViewModel || {};

// The authorViewModel class
ViewModel.authorViewModel = function (author) {
    this.authorId = ko.observable(author.authorId);
    this.authorName = ko.observable(author.authorName);
    this.authorBooks = ko.observableArray(author.authorBooks);
}
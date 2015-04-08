/// <reference path="knockout-3.3.0.js" />

function authorViewModel(author) {
    this.authorId = ko.observable(author.authorId);
    this.authorName = ko.observable(author.authorName);
    this.authorBooks = ko.observableArray(author.authorBooks);
}
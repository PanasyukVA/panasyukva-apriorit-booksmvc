/// <reference path="../knockout-3.3.0.js" />

// The ViewModel namespace
var ViewModel = ViewModel || {};

// The masterViewModel class
ViewModel.masterViewModel = function () {
    this.bookViewModel = new ViewModel.bookViewModel(new Model.book());
    this.booksViewModel = new ViewModel.booksViewModel();
    this.authorViewModel = new ViewModel.authorViewModel(new Model.author());
}

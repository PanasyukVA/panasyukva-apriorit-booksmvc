/// <reference path="jquery-2.1.3.js" />
/// <reference path="jquery-2.1.3.intellisense.js" />

function initialize() {
    var tt = $("#aEditAuthor");
    $("[id=aEditAuthor]").on("click", showAuthor);
    $("[id=btnEditBook]").on("click", showBook);
}

function showAuthor() {
    var authorid = $(this).data("authorid");
    var path = "Author/Edit/" + authorid;
    getPartialView(path).done(displayAuthor).fail(authorErrorHandling);
    return false;
}

function showBook() {
    var bookId = $(this).data("bookid");
    var path = "Book/Edit/" + bookId;
    getPartialView(path).done(displayBook).fail(bookErrorHandling);
}

function getPartialView(path) {
    return $.ajax(path);
}

function displayAuthor(authorView) {
    $("#Author").html(authorView);
}

function displayBook(bookView) {
    $("#Book").html(bookView);
}

function authorErrorHandling(error){
    $("#Author").html(error.responseText);
}

function bookErrorHandling(error) {
    $("#Book").html(error.responseText);
}
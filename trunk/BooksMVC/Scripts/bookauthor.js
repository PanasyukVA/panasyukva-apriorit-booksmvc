/// <reference path="jquery-2.1.3.js" />
/// <reference path="jquery-2.1.3.intellisense.js" />

function initialize() {
    $("[id=aEditAuthor]").on("click", showEditAuthor);
    $("[id=btnEditBook]").on("click", showEditBook);
    $("#btnCreateAuthor").on("click", showCreateAuthor);
    $("#btnCreateBook").on("click", showCreateBook);
}

function initializeCreateEdit() {
    $("#btnCancelAuthor").on("click", function () {
        $("#Author").slideUp(1000);
    });
    $("#btnCancelBook").on("click", function () {
        $("#Book").slideUp(1000);
    });
}

function showCreateAuthor() {
    getPartialView("Author/Create/").done(displayAuthor).fail(authorErrorHandling);
}

function showCreateBook() {
    getPartialView("Book/Create/").done(displayBook).fail(bookErrorHandling);
}

function showEditAuthor() {
    var authorid = $(this).data("authorid");
    var path = "Author/Edit/" + authorid;
    getPartialView(path).done(displayAuthor).fail(authorErrorHandling);
    return false;
}

function showEditBook() {
    var bookId = $(this).data("bookid");
    var path = "Book/Edit/" + bookId;
    getPartialView(path).done(displayBook).fail(bookErrorHandling);
}

function getPartialView(path) {
    return $.ajax(path);
}

function displayAuthor(authorView) {
    $("#Author").html(authorView);
    $('#Author').slideDown(1000);
}

function displayBook(bookView) {
    $("#Book").html(bookView);
    $('#Book').slideDown(1000);
}

function authorErrorHandling(error){
    $("#Author").html(error.responseText);
}

function bookErrorHandling(error) {
    $("#Book").html(error.responseText);
}
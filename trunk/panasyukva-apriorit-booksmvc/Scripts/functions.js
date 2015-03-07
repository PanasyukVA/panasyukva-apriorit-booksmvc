/// <reference path="jquery-2.1.3.js" />
/// <reference path="jquery-2.1.3.intellisense.js" />

function initialize() {
    $("#btnEditBook").on("click", showAuthor);
}

function showAuthor() {
    var bookId = $(this).data("bookid");
    var path = "Author/Details/" + bookId;
    getPartialView(path).done(displayAuthor).fail(errorHandling);
}

function getPartialView(path) {
    return $.ajax(path);
}

function displayAuthor(authorView) {
    $("#Author").text(authorView);
}

function errorHandling(error){
    $("#Author").html(error.responseText);
}
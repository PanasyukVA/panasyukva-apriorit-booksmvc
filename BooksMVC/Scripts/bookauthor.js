﻿/// <reference path="jquery-2.1.3.js" />
/// <reference path="jquery-2.1.3.intellisense.js" />
/// <reference path="jquery.blockUI.js" />

function initializeGlobal() {
    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
}

// Initialize "Books" layer
function initializeBooks() {
    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

    $ajax({
        type: "GET",
        url: "Book/Index"
    }).done(function (data) {});

    $("[id=aEditAuthor]").on("click", showEditingAuthor);
    $("[id=btnEditBook]").on("click", showEditingBook);
    $("#btnCreateAuthor").on("click", showCreatingAuthor);
    $("#btnCreateBook").on("click", showCreatingBook);
}

// Show form of Author Editing 
function showEditingAuthor() {
    var authorid = $(this).data("authorid");
    var path = "Author/Edit/" + authorid;

    getPartialView(path)
        .done(function (authorView, state, result) { getAuthor(authorView, state, result, authorid); })
        .fail(authorErrorHandling);

    return false;
}

// Get Author by ID
function getAuthor(authorView, state, result, authorid) {
    $("#authorLayer").html(authorView);
    getPartialView(webAPIGetAuthorPath + authorid).done(fullAuthor).fail(authorErrorHandling);
    $('#authorLayer').slideDown(1000);
}

// Full Author form data
function fullAuthor(data) {
    $("#AuthorId").val(data.AuthorId);
    $("#AuthorName").val(data.AuthorName);
    $("#Books").val(data.Books);
}

// Show form of Book Editing
function showEditingBook() {
    var bookId = $(this).data("bookid");
    var path = "Book/Edit/" + bookId;
    getPartialView(path).done(displayBook).fail(bookErrorHandling);
}

// Show form of Author Creating 
function showCreatingAuthor() {
    getPartialView("Author/Create/").done(displayAuthor).fail(authorErrorHandling);
}

// Show form of Book Creating 
function showCreatingBook() {
    getPartialView("Book/Create/").done(displayBook).fail(bookErrorHandling);
}

// Initialize "Book" layer
function initializeBook() {
    $("#btnCancelBook").on("click", function () {
        $("#bookLayer").slideUp(1000);
    });
}

// Initialize "Author" layer
function initializeAuthor() {
    $("#btnCancelAuthor").on("click", function () {
        $("#authorLayer").slideUp(1000);
    });

    $("#btnSubmitAuthor").on("click", createEditAuthor);
}

// Create / Edit author
function createEditAuthor() {
    var authorId = $("#AuthorId").val();
    var url = authorId == "0" ? webAPICreateAuthorPath : webAPIEditAuthorPath;
    var authorName = $("#AuthorName").val();
    var books = $("#Books").val();
    var data = { "AuthorId": authorId, "AuthorName": authorName, "Books": books };
    $.ajax({
        url: url,
        data: data,
        type: "POST",
        cache: false,
        dataType: "json",
        success: function () {
            location.reload();
        },
        error: authorErrorHandling
    });
}

function getPartialView(path) {
    return $.ajax(path);
}

function displayAuthor(authorView) {
    $("#authorLayer").html(authorView);
    $('#authorLayer').slideDown(1000);
}

function displayBook(bookView) {
    $("#bookLayer").html(bookView);
    $("#bookLayer").slideDown(1000);
}

function authorErrorHandling(error){
    $("#authorLayer").html(error.responseText);
    $("#bookLayer").slideDown(1000);
}

function bookErrorHandling(error) {
    $("#bookLayer").html(error.responseText);
    $("#bookLayer").slideDown(1000);
}
﻿/// <reference path="../jquery-2.1.3.js" />
/// <reference path="../jquery-2.1.3.intellisense.js" />
/// <reference path="../jquery.blockUI.js" />
/// <reference path="../knockout-3.3.0.js" />

// The namespace BooksNS
var BooksNS = BooksNS || {};

// The books class
BooksNS.books = function () {
    // Initializes all layers
    this.initialize = function () {
        $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
        viewModel = new ViewModel.masterViewModel();
        ko.applyBindings(viewModel);

        // Initializes the "Author" layer
        initializeAuthor();

        // Initializes the "Book" layer
        initializeBook();

        // Initializes the "Books" layer
        initializeBooks();
    }

    // Initializes the "Books" layer
    function initializeBooks() {
        // Subscribes on events
        $("#btnCreateAuthor").click(showCreatingAuthor);
        $("#btnCreateBook").click(showCreatingBook);

        // Gets books
        getBooks();
    }

    // Initializes the "Book" layer
    function initializeBook() {
        $("#btnCancelBook").click(function () { $("#bookLayer").slideUp(1000); });
        $("#btnSubmitBook").click(createEditBook);
    }

    // Initializes the "Author" layer
    function initializeAuthor() {
        $("#btnCancelAuthor").click(function () { $("#authorLayer").slideUp(1000); });
        $("#btnSubmitAuthor").click(createEditAuthor);
    }

    // Gets books
    function getBooks() {
        $.getJSON("Book/GetIndex", function (data) {
            // Fills the view model
            $(data).each(function (index, element) {
                var book = new Model.book(element.BookId, element.BookName, element.Authors, element.SelectedAuthors);
                viewModel.booksViewModel.books.push(book);
            });

            // Subscribes on events
            $("[id=aEditAuthor]").click(showEditingAuthor);
            $("[id=btnEditBook]").click(showEditingBook);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            layerErrorHandling(jqXHR, "booksLayer");
        });
    }

    // Shows the form of author editing 
    function showEditingAuthor() {
        var authorId = $(this).data("authorid");
        $.ajax(webAPIGetAuthorPath + authorId)
            .done(function (data) {
                viewModel.authorViewModel.authorId(data.AuthorId);
                viewModel.authorViewModel.authorName(data.AuthorName);
                viewModel.authorViewModel.authorBooks(data.Books);
            })
            .fail(function (jqXHR, textStatus, errorThrown) { layerErrorHandling(jqXHR, "authorLayer"); })
            .always(function () { $('#authorLayer').slideDown(1000); });
        return false;
    }

    // Shows the form of book editing
    function showEditingBook() {
        var bookId = $(this).data("bookid");
        $.getJSON("Book/GetEdit/" + bookId)
            .done(function (data) {
                viewModel.bookViewModel.bookId(data.book.BookId);
                viewModel.bookViewModel.bookName(data.book.BookName);
                viewModel.bookViewModel.bookAuthors(data.allAuthors);
                viewModel.bookViewModel.bookSelectedAuthors(data.book.SelectedAuthors);
            })
            .fail(layerErrorHandling)
            .always(function () { $('#bookLayer').slideDown(1000); });
    }

    // Shows the form of author creating 
    function showCreatingAuthor() {
        viewModel.authorViewModel.authorId(0);
        viewModel.authorViewModel.authorName("");
        viewModel.authorViewModel.authorBooks("");
        $('#authorLayer').slideDown(1000); 
    }

    // Shows the form of book creating 
    function showCreatingBook() {
        $.getJSON("Book/GetCreate")
            .done(function (data) {
                viewModel.bookViewModel.bookId(0);
                viewModel.bookViewModel.bookName("");
                viewModel.bookViewModel.bookAuthors(data);
                viewModel.bookViewModel.bookSelectedAuthors([]);
            })
            .fail(layerErrorHandling)
            .always(function () { $('#bookLayer').slideDown(1000); });
    }

    // Creates / edits author
    function createEditAuthor() {
        var authorId = viewModel.authorViewModel.authorId();
        var url = authorId == "0" ? webAPICreateAuthorPath : webAPIEditAuthorPath;
        var authorName = viewModel.authorViewModel.authorName();
        var authorBooks = viewModel.authorViewModel.authorBooks();
        var data = { "AuthorId": authorId, "AuthorName": authorName, "Books": authorBooks };
        $.ajax({
            url: url,
            data: data,
            type: "POST",
            cache: false,
            dataType: "json",
            success: function () { location.reload(); },
            error: function (jqXHR, textStatus, errorThrown) { layerErrorHandling(jqXHR, "authorLayer"); }
        });
    }

    // Creates / edits book
    function createEditBook() {
        var bookId = viewModel.bookViewModel.bookId();
        var url = bookId == "0" ? "Book/Create" : "Book/Edit";
        var bookName = viewModel.bookViewModel.bookName();
        // var allAuthors = viewModel.bookViewModel.bookAuthors();
        var bookAuthors = [];
        $.each($('#SelectedAuthors').val(), function (element) { bookAuthors.push(element.toString()) })
        var data = { "BookId": bookId, "BookName": bookName, "SelectedAuthors": bookAuthors };
        $.ajax({
            url: url,
            data: data,
            type: "POST",
            cache: false,
            dataType: "json",
            success: function () { location.reload(); },
            error: function (jqXHR, textStatus, errorThrown) { layerErrorHandling(jqXHR, "bookLayer"); }
        });
    }

    // Handles an error of layer
    function layerErrorHandling(error, layerId) {
        $("#" + layerId + "Error").html(error.responseText);
        $("#" + layerId + "Error").show()
    }
}
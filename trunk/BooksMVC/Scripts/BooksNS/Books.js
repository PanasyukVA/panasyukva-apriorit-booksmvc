/// <reference path="../jquery-2.1.3.js" />
/// <reference path="../jquery-2.1.3.intellisense.js" />
/// <reference path="../jquery.blockUI.js" />
/// <reference path="../knockout-3.3.0.js" />

// The namespace BooksNS
var BooksNS = BooksNS || {};

// The books class
BooksNS.books = function () {
    // Initializes the "Global" layer
    function initializeGlobal() {
        // Enables the blocking UI durring ajax request
        $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
    }

    // Initializes the "Books" layer
    function initializeBooks() {
        // Gets books
        var booksViewModel = new ViewModel.booksViewModel();
        getBooks(booksViewModel);

        // Subscribes on events
        $("[id=aEditAuthor]").on("click", showEditingAuthor);
        $("[id=btnEditBook]").on("click", showEditingBook);
        $("#btnCreateAuthor").on("click", showCreatingAuthor);
        $("#btnCreateBook").on("click", showCreatingBook);
    }

    // Initializes the "Book" layer
    function initializeBook() {
        $("#btnCancelBook").on("click", function () {
            $("#bookLayer").slideUp(1000);
        });
    }

    // Initializes the "Author" layer
    function initializeAuthor() {
        $("#btnCancelAuthor").on("click", function () {
            $("#authorLayer").slideUp(1000);
        });

        $("#btnSubmitAuthor").on("click", createEditAuthor);
    }

    // Gets books
    function getBooks(viewModel) {
        $ajax({
            type: "GET",
            url: "BooksWcfServices/BookWcfService.svc/GetBooks",
            dataType: "json",
            success: function (data) {
                $(data).each(function (index, element) {
                    var book = new Entity.book(element.bookId, element.bookName, element.authors, element.selectedAuthors);
                    viewModel.books.push(book);
                });
                ko.applyBindings(viewModel);
            },
            error: function () {
                throw "The error handling durring getting books is not implemented!";
            }
        });
    }

    // Shows the form of author editing 
    function showEditingAuthor() {
        var authorid = $(this).data("authorid");
        var path = "Author/Edit/" + authorid;

        getPartialView(path)
            .done(function (authorView, state, result) { getAuthor(authorView, state, result, authorid); })
            .fail(authorErrorHandling);

        return false;
    }

    // Gets an author by id
    function getAuthor(authorView, state, result, authorid) {
        $("#authorLayer").html(authorView);
        getPartialView(webAPIGetAuthorPath + authorid).done(fullAuthor).fail(authorErrorHandling);
        $('#authorLayer').slideDown(1000);
    }

    // Fulls an author form data
    function fullAuthor(data) {
        $("#AuthorId").val(data.AuthorId);
        $("#AuthorName").val(data.AuthorName);
        $("#Books").val(data.Books);
    }

    // Shows the form of book editing
    function showEditingBook() {
        var bookId = $(this).data("bookid");
        var path = "Book/Edit/" + bookId;
        getPartialView(path).done(displayBook).fail(bookErrorHandling);
    }

    // Shows the form of author creating 
    function showCreatingAuthor() {
        getPartialView("Author/Create/").done(displayAuthor).fail(authorErrorHandling);
    }

    // Shows the form of book creating 
    function showCreatingBook() {
        getPartialView("Book/Create/").done(displayBook).fail(bookErrorHandling);
    }

    // Creates / edits author
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

    // Gets a partial view
    function getPartialView(path) {
        return $.ajax(path);
    }

    // Displays an author
    function displayAuthor(authorView) {
        $("#authorLayer").html(authorView);
        $('#authorLayer').slideDown(1000);
    }

    // Displays a book
    function displayBook(bookView) {
        $("#bookLayer").html(bookView);
        $("#bookLayer").slideDown(1000);
    }

    // Handles the error of author
    function authorErrorHandling(error) {
        $("#authorLayer").html(error.responseText);
        $("#bookLayer").slideDown(1000);
    }

    // Handles the error of book
    function bookErrorHandling(error) {
        $("#bookLayer").html(error.responseText);
        $("#bookLayer").slideDown(1000);
    }
}

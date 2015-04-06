//------------------------------------------------------
// <copyright file="BooksControllerBase.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------

namespace Books.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    /// <summary>
    /// Represents the books base controller
    /// </summary>
    public abstract class BooksControllerBase : Controller
    {
        /// <summary>
        /// Handles an error
        /// </summary>
        /// <param name="filterContext">A context to handle the error</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (IsAjax(filterContext))
            {
                filterContext.Result = new ContentResult
                {
                    Content = string.Format("<div style=\"color: red\"><h3>The error was occurred. Error: {0}</h3></div>", filterContext.Exception.Message),
                    ContentType = "text/html",
                    ContentEncoding = Encoding.UTF8 
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "_Error"
                };

                filterContext.ExceptionHandled = true;
            }
        }

        /// <summary>
        /// Checks whether to request is the Ajax request 
        /// </summary>
        /// <param name="filterContext">The filter context to check</param>
        /// <returns>The result of checking</returns>
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}

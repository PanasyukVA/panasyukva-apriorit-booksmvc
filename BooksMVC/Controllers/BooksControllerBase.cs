//------------------------------------------------------
// <copyright file="BooksControllerBase.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------

namespace Books.Controllers
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
            if (IsAjax(filterContext))
            {
                filterContext.Result = new JsonResult()
                {
                    Data = filterContext.Exception.Message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                base.OnException(filterContext);
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

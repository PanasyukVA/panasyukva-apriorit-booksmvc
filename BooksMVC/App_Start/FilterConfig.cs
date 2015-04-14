//------------------------------------------------------
// <copyright file="FilterConfig.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------
namespace Books
{
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Represents a registration global filters
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers global filters
        /// </summary>
        /// <param name="filters">A filter collection the register</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
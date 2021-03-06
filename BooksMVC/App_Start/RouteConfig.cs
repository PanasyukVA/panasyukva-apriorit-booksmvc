﻿//------------------------------------------------------
// <copyright file="RouteConfig.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------
namespace Books
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Represents a routing
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers routes
        /// </summary>
        /// <param name="routes">A routes collection to register</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "EditEditorFor", id = UrlParameter.Optional });
        }
    }
}
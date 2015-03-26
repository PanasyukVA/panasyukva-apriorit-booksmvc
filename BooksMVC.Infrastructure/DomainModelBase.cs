//------------------------------------------------------
// <copyright file="DomainModelBase.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------
namespace Books.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a base domain model
    /// </summary>
    public abstract class DomainModelBase : IDisposable
    {
        #region IDisposable Members

        /// <summary>
        /// Finalizes an instance of the <see cref="DomainModelBase" /> class 
        /// </summary>
        ~DomainModelBase()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Releases safe resources
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unsafe resources
        /// </summary>
        /// <param name="disposing">An flag to release</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            { 
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMVC.Infrastructure
{
    public abstract class DomainModelBase : IDisposable
    {
        #region IDisposable Members

		public void Dispose()
		{
            this.Dispose(true);
            GC.SuppressFinalize(this);
		}

        ~DomainModelBase()
		{
			this.Dispose(false);
		}

        protected void Dispose(bool disposing){}

		#endregion
    }
}

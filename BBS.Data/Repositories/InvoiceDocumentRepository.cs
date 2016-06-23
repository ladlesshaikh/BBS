using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class InvoiceDocumentRepository : RepositoryBase<InvoiceDocument>
    {
        #region Object construction
        /// <summary>
        /// 
        /// </summary>
        public InvoiceDocumentRepository()
            : base(Helper.GetDataContext())
        {

        }
        #endregion
    }
}

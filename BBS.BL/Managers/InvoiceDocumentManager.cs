using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class InvoiceDocumentManager : ManagerBase, IManager<InvoiceDocument>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<InvoiceDocument>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<bool> AddOrUpdateAsync(InvoiceDocument item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(InvoiceDocument item)
        {
            throw new NotImplementedException();
        }
    }
}

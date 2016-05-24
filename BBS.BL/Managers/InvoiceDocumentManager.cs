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
        public Task<List<InvoiceDocument>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddOrUpdateAsync(InvoiceDocument item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(InvoiceDocument item)
        {
            throw new NotImplementedException();
        }
    }
}

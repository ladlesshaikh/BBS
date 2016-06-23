using BBS.Data;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<String> GenerateInvoiceReferenceForDateAsync(DateTime dateTime)
        {
            var retVal = "00000";
            var invoiceOffset = 1;
            var formattedInputDate = dateTime.ToString("yyyyMM");
            using (var repository = new InvoiceDocumentRepository())
            {
                var invoicesForGivenDate = (await repository.GetAsync()).Where(i => i.DocDate.ToString("yyyyMM") == formattedInputDate);
                if (null != invoicesForGivenDate && invoicesForGivenDate.Count() > 0)
                {
                    invoiceOffset = invoicesForGivenDate.Count();
                }

                retVal = retVal + invoiceOffset.ToString();
                retVal = retVal.Substring(retVal.Length - 5);
                retVal = string.Format("{0}-{1}", formattedInputDate, retVal);
            }
            return retVal;
        }
    }
}

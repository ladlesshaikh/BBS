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
        public async Task<List<InvoiceDocument>> GetAllAsync()
        {
            List<InvoiceDocument> retVal = null;
            using (var repository = new InvoiceDocumentRepository())
            {
                retVal = await repository.GetAsync();
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> AddOrUpdateAsync(InvoiceDocument item)
        {
            var retVal = false;
            using (var repository = new InvoiceDocumentRepository())
            {
                retVal = item.Id > 0 ? await repository.UpdateAsync(item) : await repository.InsertAsync(item);
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(InvoiceDocument item)
        {
            var retVal = false;
            using (var repository = new InvoiceDocumentRepository())
            {
                retVal = await repository.DeleteAsync(item);
            }
            return retVal;
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
                    invoiceOffset = invoiceOffset + invoicesForGivenDate.Count();
                }

                retVal = retVal + invoiceOffset.ToString();
                retVal = retVal.Substring(retVal.Length - 5);
                retVal = string.Format("{0}-{1}", formattedInputDate, retVal);
            }
            return retVal;
        }
    }
}

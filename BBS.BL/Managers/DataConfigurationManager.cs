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
    public class DataConfigurationManager : ManagerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SetupDataAsync()
        {
            var retVal = true;
            retVal &= await SetupCreditTermsOrValidityAsync();
            retVal &= await SetupInvoiceTypesAsync();
            retVal &= await SetupPaymentTypesAsync();
            retVal &= await SetupBillingAsync();
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetDataConfigurationAsync<T>() where T : ModelBase
        {
            IEnumerable<T> retVal = null;
            using (var repository = new RepositoryBase<T>(Helper.GetDataContext()))
            {
                retVal = await repository.GetAsync();
            }
            return retVal;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SetupCreditTermsOrValidityAsync()
        {
            var retVal = false;
            IEnumerable<CreditTermsValidityType> values = new List<CreditTermsValidityType>() 
            { 
                new CreditTermsValidityType { Key = "cod", Value = "COD" }, 
                new CreditTermsValidityType { Key = "net7days", Value = "Net 7 Days" } 
            };
            using (var repository = new RepositoryBase<CreditTermsValidityType>(Helper.GetDataContext()))
            {
                retVal = true;
                foreach (var item in values)
                {
                    if (!await repository.IsExistsAsync(i => i.Key == item.Key))
                    {
                        retVal &= await repository.InsertAsync(item);
                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SetupPaymentTypesAsync()
        {
            var retVal = false;
            IEnumerable<PaymentType> values = new List<PaymentType>() 
            { 
                new PaymentType { Key = "cash", Value = "Cash" }, 
                new PaymentType { Key = "account", Value = "Account" } 
            };
            using (var repository = new RepositoryBase<PaymentType>(Helper.GetDataContext()))
            {
                retVal = true;
                foreach (var item in values)
                {
                    if (!await repository.IsExistsAsync(i => i.Key == item.Key))
                    {
                        retVal &= await repository.InsertAsync(item);
                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SetupBillingAsync()
        {
            var retVal = false;
            var values = new List<InvoiceBillingType>() 
            { 
                new InvoiceBillingType{ Key = "quantitybased", Value = "Quantity and Unit Cost" }, 
                new InvoiceBillingType{ Key = "hourlybased", Value = "Hours and Rate per hour" } 
            };
            using (var repository = new RepositoryBase<InvoiceBillingType>(Helper.GetDataContext()))
            {
                retVal = true;
                foreach (var item in values)
                {
                    if (!await repository.IsExistsAsync(i => i.Key == item.Key))
                    {
                        retVal &= await repository.InsertAsync(item);
                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SetupInvoiceTypesAsync()
        {
            var retVal = false;
            var values = new List<InvoiceDocumentType>() 
            { 
                new InvoiceDocumentType{ Key = "taxinvoice", Value = "Tax Invoice" }, 
                new InvoiceDocumentType{ Key = "quotation", Value = "Quotation" } ,
                new InvoiceDocumentType{ Key = "creditnote", Value = "Credit Note" } ,
                new InvoiceDocumentType{ Key = "proformainvoice", Value = "Proforma Invoice" } 
            };
            using (var repository = new RepositoryBase<InvoiceDocumentType>(Helper.GetDataContext()))
            {
                retVal = true;
                foreach (var item in values)
                {
                    if (!await repository.IsExistsAsync(i => i.Key == item.Key))
                    {
                        retVal &= await repository.InsertAsync(item);
                    }
                }
            }
            return retVal;
        }
    }
}

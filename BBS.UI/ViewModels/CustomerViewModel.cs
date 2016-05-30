using BBS.BL;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerViewModel : ExpanderBase<Customer>
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomerViewModel()
            : base(new CustomerManager())
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void InitializeNewItem()
        {
            if (null == NewItem)
            {
                NewItem = new Customer { AddressDetails = new Address(), InvoiceItems = new List<InvoiceItem>(), TaxDetails = new TaxDetail() };
            }
            else
            {
                NewItem.AddressDetails = null == SelectedItem.AddressDetails ? new Address() : SelectedItem.AddressDetails;
                NewItem.InvoiceItems = null == SelectedItem.InvoiceItems ? new List<InvoiceItem>() : SelectedItem.InvoiceItems;
                NewItem.TaxDetails = null == SelectedItem.TaxDetails ? new TaxDetail() : SelectedItem.TaxDetails;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void ItemBeginningEditCommandHandler(object param)
        {
            if (null == SelectedItem)
            {
                SelectedItem = new Customer { AddressDetails = new Address(), InvoiceItems = new List<InvoiceItem>(), TaxDetails = new TaxDetail() };
            }
            else
            {
                SelectedItem.AddressDetails = null == SelectedItem.AddressDetails ? new Address() : SelectedItem.AddressDetails;
                SelectedItem.InvoiceItems = null == SelectedItem.InvoiceItems ? new List<InvoiceItem>() : SelectedItem.InvoiceItems;
                SelectedItem.TaxDetails = null == SelectedItem.TaxDetails ? new TaxDetail() : SelectedItem.TaxDetails;
            }
        }
    }
}

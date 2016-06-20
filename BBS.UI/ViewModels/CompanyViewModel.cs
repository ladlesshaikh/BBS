using BBS.BL;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    public class CompanyViewModel : ExpanderBase<Company>
    {
        /// <summary>
        /// 
        /// </summary>
        public CompanyViewModel()
            : base(new CompanyManager())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitializeNewItem()
        {
            if (null == NewItem)
            {
                NewItem = new Company { Bank = new BankDetail(), AddressDetails = new Address(), Tax = new TaxDetail() };
            }
            else
            {
                NewItem.AddressDetails = null == SelectedItem.AddressDetails ? new Address() : SelectedItem.AddressDetails;
                NewItem.Bank = null == SelectedItem.Bank ? new BankDetail() : SelectedItem.Bank;
                NewItem.Tax = null == SelectedItem.Tax ? new TaxDetail() : SelectedItem.Tax;
            }
        }
    }
}

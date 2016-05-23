using BBS.BL.Managers;
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
    public class CustomerViewModel : ViewModelBase<Customer>
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomerViewModel()
            : base(new CustomerManager())
        {

        }
    }
}

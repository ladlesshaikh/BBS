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
    public class CustomerRepository : RepositoryBase<Customer>
    {
        #region Object construction
        /// <summary>
        /// 
        /// </summary>
        public CustomerRepository()
            : base(Helper.GetDataContext())
        {

        }
        #endregion
    }
}

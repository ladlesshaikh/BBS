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
    public class CompanyRepository : RepositoryBase<Company>
    {
        #region Object construction
        /// <summary>
        /// 
        /// </summary>
        public CompanyRepository()
            : base(new DataContext())
        {

        }
        #endregion
    }
}

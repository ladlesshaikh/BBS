using BBS.BL;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    public class CompanyViewModel : ViewModelBase<Company>
    {
        /// <summary>
        /// 
        /// </summary>
        public CompanyViewModel()
            : base(new CompanyManager())
        {
        }
    }
}

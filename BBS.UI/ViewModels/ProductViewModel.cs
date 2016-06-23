using BBS.BL;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    public class ProductViewModel : ExpanderBase<Product>
    {
        /// <summary>
        /// 
        /// </summary>
        public ProductViewModel()
            : base(new ProductManager())
        {
        }
    }
}

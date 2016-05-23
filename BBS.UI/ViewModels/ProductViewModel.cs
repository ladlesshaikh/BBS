﻿using BBS.BL;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    public class ProductViewModel : ViewModelBase<Product>
    {
        public ProductViewModel()
            : base(new ProductManager())
        {

        }
    }
}

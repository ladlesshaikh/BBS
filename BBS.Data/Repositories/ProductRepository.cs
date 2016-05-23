using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Data
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository()
            : base(Helper.GetDataContext())
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("TaxDetails")]
    public class TaxDetail : ModelBase
    {
        public string TaxNo { get; set; }
    }
}

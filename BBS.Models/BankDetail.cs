using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Models
{
    [Table("BankDetails")]
    public class BankDetail : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }
    }
}

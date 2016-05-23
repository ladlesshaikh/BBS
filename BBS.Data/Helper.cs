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
    public static class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        private static DataContext context = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataContext GetDataContext()
        {
            return context ?? (context = new DataContext());
        }
    }
}

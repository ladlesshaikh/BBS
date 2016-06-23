using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BBS.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class RequiredFieldValidator : ValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        public RequiredFieldValidator()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length > 0)
            {
                return new ValidationResult(true, "Valid");
            }
            else
            {
                return new ValidationResult(false, "Required");
            }
        }
    }
}

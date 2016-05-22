using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //basic ViewModelBase
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand AddItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand UpdateItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand DeleteItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand Canceltem { get; set; }

    }
}

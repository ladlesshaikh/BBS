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
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewModelBase<T> : INotifyPropertyChanged where T : ModelBase
    {
        #region Local resource declarations
        /// <summary>
        /// 
        /// </summary>
        IManager<T> manager = null;

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<T> items = null;

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Object constructions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetedManager"></param>
        public ViewModelBase(IManager<T> targetedManager)
        {
            manager = targetedManager;
            PopulateItems();
            SetupCommandHandlers();
        }
        #endregion

        //basic ViewModelBase
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<T> Items
        {
            get
            {
                return items;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public T SelectedItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand AddCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand UpdateCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand DeleteCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand CanceCommand { get; set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void PopulateItems()
        {
            var itemList = manager.GetAllAsync().Result;
            items = new ObservableCollection<T>(itemList);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetupCommandHandlers()
        {
            UpdateCommand = new UserActionOrCommand(UpdateCommandHandler);
            DeleteCommand = new UserActionOrCommand(DeleteCommandHandler);
        }
        #region Command handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void UpdateCommandHandler(object param)
        {
            var updateResult = manager.AddOrUpdateAsync(SelectedItem).Result;
            if (updateResult)
            {
                // RaisePropertyChanged("Name");
            }
        }

        public bool CanDeleted()
        {
            return null != SelectedItem;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void DeleteCommandHandler(object param)
        {
            var updateResult = manager.DeleteAsync(SelectedItem).Result;
            if (updateResult)
            {
                Items.Remove(SelectedItem);
            }
        }
        #endregion
    }
}

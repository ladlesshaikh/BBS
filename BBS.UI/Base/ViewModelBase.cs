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
        protected IManager<T> manager = null;

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<T> items = null;

        ///// <summary>
        ///// 
        ///// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        public int ErrorCount = 0;
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
        protected void NotifyPropertyChanged(string propertyName)
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
        public UserActionOrCommand CancelCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand ItemBeginningEditCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand ItemSelectionChangedCommand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void PopulateItems()
        {
            var itemList = manager.GetAllAsync().Result;
            items = new ObservableCollection<T>(itemList);
            NotifyPropertyChanged("Items");
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetupCommandHandlers()
        {
            UpdateCommand = new UserActionOrCommand(UpdateCommandHandler, CanSave);
            DeleteCommand = new UserActionOrCommand(DeleteCommandHandler, CanDeleted);
            CancelCommand = new UserActionOrCommand(CancelCommandHandler);
            ItemBeginningEditCommand = new UserActionOrCommand(ItemBeginningEditCommandHandler);
            ItemSelectionChangedCommand = new UserActionOrCommand(ItemSelectionChangedCommandHandler);
        }
        #region Command handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public virtual void ItemSelectionChangedCommandHandler(object param)
        {
            NotifyPropertyChanged("SelectedItem");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public virtual void UpdateCommandHandler(object param)
        {
            var updateResult = manager.AddOrUpdateAsync((T)param).Result;
            if (updateResult)
            {
                PopulateItems();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public virtual void CancelCommandHandler(object param)
        {
            PopulateItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanDeleted(object parameter)
        {
            return null != SelectedItem && SelectedItem.Id > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanSave(object parameter)
        {
            var retVal = false;
            retVal = ErrorCount == 0;
            return retVal;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public virtual void DeleteCommandHandler(object param)
        {
            var updateResult = manager.DeleteAsync((T)param).Result;
            if (updateResult)
            {
                Items.Remove(SelectedItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public virtual void ItemBeginningEditCommandHandler(object param)
        {
            if (null == SelectedItem)
            {
                SelectedItem = default(T);
            }
        }
        #endregion
    }
}

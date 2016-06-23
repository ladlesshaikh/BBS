using BBS.BL;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExpanderBase<T> : ViewModelBase<T> where T : ModelBase, new()
    {
        /// <summary>
        /// 
        /// </summary>
        private bool isExpanded = false;

        public ExpanderBase(IManager<T> targetedManager)
            : base(targetedManager)
        {
            ExpandedCommand = new UserActionOrCommand(ExpandedCommandhandler);
            CollapsedCommand = new UserActionOrCommand(CollapsedCommandHandler);
        }
        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand ExpandedCommand { get; set; }

        public UserActionOrCommand CollapsedCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }
            set
            {
                isExpanded = value;
                NotifyPropertyChanged("IsExpanded");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public T NewItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void InitializeNewItem()
        {
            NewItem = NewItem ?? new T();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void RaiseOnNewItemChanged()
        {
            NotifyPropertyChanged("NewItem");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void ExpandedCommandhandler(object param)
        {
            InitializeNewItem();
            RaiseOnNewItemChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void CollapsedCommandHandler(object param)
        {
            NewItem = null;
            RaiseOnNewItemChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void ItemSelectionChangedCommandHandler(object param)
        {
            NewItem = SelectedItem;
            RaiseOnNewItemChanged();
            OpenExpander();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void DeleteCommandHandler(object param)
        {
            base.DeleteCommandHandler(param);
            CollapseExpander();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void UpdateCommandHandler(object param)
        {
            base.UpdateCommandHandler(param);
            CollapseExpander();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void CancelCommandHandler(object param)
        {
            using (var dataConfigurationManger = new DataConfigurationManager())
            {
                var result = dataConfigurationManger.ReleaseDataContextAsync().Result;
            }
            CollapseExpander();
            base.CancelCommandHandler(param);
        }
        /// <summary>
        /// 
        /// </summary>
        private void OpenExpander()
        {
            IsExpanded = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CollapseExpander()
        {
            IsExpanded = false;
        }
    }
}

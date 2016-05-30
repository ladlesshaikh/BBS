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
                RaisePropertyChanged("IsExpanded");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public T NewProduct { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void ExpandedCommandhandler(object param)
        {
            NewProduct = NewProduct ?? new T();
            RaiseOnNewProductChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void CollapsedCommandHandler(object param)
        {
            NewProduct = null;
            RaiseOnNewProductChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void ItemSelectionChangedCommandHandler(object param)
        {
            NewProduct = SelectedItem;
            RaiseOnNewProductChanged();
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

        /// <summary>
        /// 
        /// </summary>
        private void RaiseOnNewProductChanged()
        {
            RaisePropertyChanged("NewProduct");
        }
    }
}

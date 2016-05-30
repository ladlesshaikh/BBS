using BBS.BL;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    public class ProductViewModel : ViewModelBase<Product>
    {
        /// <summary>
        /// 
        /// </summary>
        private bool isExpanded = false;

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
        public Product NewProduct { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProductViewModel()
            : base(new ProductManager())
        {
            ExpandedCommand = new UserActionOrCommand(ExpandedCommandhandler);
            CollapsedCommand = new UserActionOrCommand(CollapsedCommandHandler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void ExpandedCommandhandler(object param)
        {
            NewProduct = NewProduct ?? new Product();
            RaisePropertyChanged("NewProduct");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void CollapsedCommandHandler(object param)
        {
            NewProduct = null;
            RaisePropertyChanged("NewProduct");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void ItemSelectionChangedCommandHandler(object param)
        {
            NewProduct = SelectedItem;
            RaisePropertyChanged("NewProduct");
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

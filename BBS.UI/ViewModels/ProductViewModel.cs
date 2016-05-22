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
    public class ProductViewModel : ViewModelBase
    {
        private ObservableCollection<Product> products = null;

        /// <summary>
        /// 
        /// </summary>
        public ProductViewModel()
        {
            UpdateItem = new UserActionOrCommand(UpdateCommand);
            DeleteItem = new UserActionOrCommand(DeleteCommand);
            PopulateProducts();
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Product SelectedProduct { get; set; }

        #region Private helper methods
        /// <summary>
        /// 
        /// </summary>
        private void PopulateProducts()
        {
            using (var productManager = new ProductManager())
            {
                var productsList = productManager.GetAllAsync().Result;
                products = new ObservableCollection<Product>(productsList);
            }
        }
        #endregion

        #region Command handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void UpdateCommand(object param)
        {
            using (var productManager = new ProductManager())
            {
                var updateResult = productManager.UpdateAsync(SelectedProduct).Result;
                if (updateResult)
                {
                    // RaisePropertyChanged("Name");
                }
            }
        }

        public bool CanDeleted()
        {
            return null != SelectedProduct;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void DeleteCommand(object param)
        {
            using (var productManager = new ProductManager())
            {
                var updateResult = productManager.DeleteAsync(SelectedProduct).Result;
                if (updateResult)
                {
                    Products.Remove(SelectedProduct);
                }
            }
        }
        #endregion
    }
}

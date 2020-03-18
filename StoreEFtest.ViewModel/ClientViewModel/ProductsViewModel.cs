using StoreEFtest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StoreEFtest.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Products { get; set; }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get
            {
                return this.selectedProduct;
            }
            set
            {
                if (this.selectedProduct == value)
                    return;

                this.selectedProduct = value;
                this.OnPropertyChanged();
            }
        }
        public ProductsViewModel(ObservableCollection<Product> products)
        {
            this.Products = products;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StoreEFtest.Model;
using StoreEFtest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEFtest.ViewModel
{
    public class ClientViewModel
    {
        public ProductsViewModel ProductsViewModel { get; set; }
        public Product SelectedProduct { get; set; }

        public ClientViewModel()
        {
            Context StoreContext = new Context();

            this.ProductsViewModel = new ProductsViewModel(StoreContext.Products.Include(p=>p.Category).Include(p => p.Brand).ToObservableCollection());
        }
    }
}

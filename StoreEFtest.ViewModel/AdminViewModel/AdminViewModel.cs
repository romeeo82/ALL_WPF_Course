using Microsoft.EntityFrameworkCore;
using StoreEFtest.Model;
using StoreEFtest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEFtest.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        public CustomersViewModel CustomersViewModel { get; set; }

        public AdminViewModel()
        {
            Context StoreContext = new Context();

            this.CustomersViewModel = new CustomersViewModel(StoreContext.Customers.Include(c=>c.Orders).ThenInclude(o=>o.OrderItems).ToObservableCollection());
        }
    }
}

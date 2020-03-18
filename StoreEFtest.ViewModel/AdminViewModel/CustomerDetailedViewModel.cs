using StoreEFtest.Model;
using StoreEFtest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEFtest.ViewModel
{
    public class CustomerDetailedViewModel : ViewModelBase
    {
        private Customer customer;
        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                if (this.customer == value)
                    return;

                this.customer = value;
                this.OnPropertyChanged();
            }
        }

        public CustomerDetailedViewModel(Customer selectedCustomer)
        {
            this.Customer = selectedCustomer;
        }
    }
}

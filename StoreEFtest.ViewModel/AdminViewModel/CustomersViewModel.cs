using StoreEFtest.Model;
using StoreEFtest.Model.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StoreEFtest.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private CustomerDetailedViewModel customerDetailedViewModel;
        public CustomerDetailedViewModel CustomerDetailedViewModel
        {
            get
            {
                return this.customerDetailedViewModel;
            }
            set
            {
                if (this.customerDetailedViewModel == value)
                    return;

                this.customerDetailedViewModel = value;
                this.OnPropertyChanged();
            }
        }

        private OrdersViewModel ordersViewModel;
        public OrdersViewModel OrdersViewModel
        {
            get
            {
                return this.ordersViewModel;
            }
            set
            {
                if (this.ordersViewModel == value)
                    return;

                this.ordersViewModel = value;
                this.OnPropertyChanged();
            }
        }

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return this.customers; }
            set
            {
                if (this.customers == value)
                    return;

                this.customers = value;
                this.OnPropertyChanged();
            }
        }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                if (this.selectedCustomer == value)
                    return;

                this.selectedCustomer = value;
                this.CustomerDetailedViewModel = new CustomerDetailedViewModel(this.selectedCustomer);
                this.OrdersViewModel = new OrdersViewModel(this.selectedCustomer.Orders.ToObservableCollection());
                this.OnPropertyChanged();
            }
        }

        public CustomersViewModel(ObservableCollection<Customer> customers)
        {
            this.Customers = customers;
        }
    }
}

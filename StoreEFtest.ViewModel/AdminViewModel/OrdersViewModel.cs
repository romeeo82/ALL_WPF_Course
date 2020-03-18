using StoreEFtest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StoreEFtest.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        private OrderDetailedViewModel orderDetailedViewModel;
        public OrderDetailedViewModel OrderDetailedViewModel
        {
            get { return this.orderDetailedViewModel; }
            set
            {
                if (this.orderDetailedViewModel == value)
                    return;

                this.orderDetailedViewModel = value;
                this.OnPropertyChanged();
            }
        }

        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
        {
            get { return this.orders; }
            set
            {
                if (this.orders == value)
                    return;

                this.orders = value;
                this.OnPropertyChanged();
            }
        }

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return this.selectedOrder; }
            set
            {
                if (this.selectedOrder == value)
                    return;

                this.selectedOrder = value;
                this.OrderDetailedViewModel = new OrderDetailedViewModel(this.selectedOrder);
                this.OnPropertyChanged();
            }
        }

        public OrdersViewModel(ObservableCollection<Order> orders)
        {
            this.Orders = orders;
        }
    }
}

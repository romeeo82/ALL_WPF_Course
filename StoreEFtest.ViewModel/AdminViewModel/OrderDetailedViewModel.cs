using StoreEFtest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEFtest.ViewModel
{
    public class OrderDetailedViewModel : ViewModelBase
    {
        private Order order;
        public Order Order
        {
            get
            {
                return this.order;
            }
            set
            {
                if (this.order == value)
                    return;

                this.order = value;
                this.OnPropertyChanged();
            }
        }

        private OrderItem selectedOrderItem;
        public OrderItem SelectedOrderItem
        {
            get
            {
                return this.selectedOrderItem;
            }
            set
            {
                if (this.selectedOrderItem == value)
                    return;

                this.selectedOrderItem = value;
                this.OnPropertyChanged();
            }
        }

        public OrderDetailedViewModel(Order order)
        {
            this.Order = order;
        }
    }
}

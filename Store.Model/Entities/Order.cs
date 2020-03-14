﻿using System;
using System.Collections.ObjectModel;

namespace StoreEFtest.Model.Entities
{
    public enum OrderStatuses
    {
        Received,
        Shipped,
        Completed,
    }
    public class Order
    {
        public int Id { get; set; }
        public OrderStatuses OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public ObservableCollection<OrderItem> OrderItems { get; set; }
    }
}

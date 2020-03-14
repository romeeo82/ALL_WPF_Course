﻿using System.Collections.ObjectModel;

namespace StoreEFtest.Model.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public ObservableCollection<Staff> Staffs { get; set; }
        public ObservableCollection<Stock> Stocks { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
    }
}

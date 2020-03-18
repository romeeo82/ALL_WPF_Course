﻿using System.Collections.ObjectModel;

namespace StoreEFtest.Model.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int? ManagerId { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public ObservableCollection<Order> Orders { get; set; }

    }
}
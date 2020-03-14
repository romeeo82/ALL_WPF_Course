using System;
using System.Collections.ObjectModel;

namespace StoreEFtest.Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal ProductPrice { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ObservableCollection<OrderItem> OrderItems { get; set; }
        public ObservableCollection<Stock> Stocks { get; set; }
    }
}

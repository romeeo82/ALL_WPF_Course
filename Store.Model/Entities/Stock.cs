namespace StoreEFtest.Model.Entities
{
    public class Stock
    {
        public int Quantity { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

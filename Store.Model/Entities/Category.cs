using System.Collections.ObjectModel;

namespace StoreEFtest.Model.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ObservableCollection<Product> Products { get; set; }
    }
}

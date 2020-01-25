using January_25.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January_25.ViewModels
{
    class MainWindowViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }

        public MainWindowViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            Customers.Add(new Customer { FirstName = "vasya", LastName = "pupkin", City = "kharkov" });
            Customers.Add(new Customer { FirstName = "petya", LastName = "vaskin", City = "krakov" });
            Customers.Add(new Customer { FirstName = "kvasya", LastName = "kvaskin", City = "kiev" });
        }
    }
}

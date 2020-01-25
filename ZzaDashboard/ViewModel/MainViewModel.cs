using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get => this.customers;
            set
            {
                if (value != this.customers)
                {
                    this.customers = value;
                    this.OnPropertyChanged(nameof(this.Customers));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            this.Customers = GetAllCustomers();
        }

        private ObservableCollection<Customer> GetAllCustomers()
        {
            string hugeText = string.Empty;
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
            using (var reader = new StreamReader($@"{Directory.GetCurrentDirectory()}\ZzaPersons.txt"))
            {
                hugeText = reader.ReadToEnd();
            }
            foreach (var line in hugeText.Split(Environment.NewLine.ToCharArray()))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var customer = new Customer();
                    customer.FirstName = line.Split('~')[0];
                    customer.LastName = line.Split('~')[1];
                    customer.Phone = line.Split('~')[2];
                    customers.Add(customer);
                }
            }

            return customers;
        }
    }
}

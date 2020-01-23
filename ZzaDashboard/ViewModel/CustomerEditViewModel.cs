using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.ViewModel
{
    class CustomerEditViewModel : INotifyPropertyChanged
    {

        public Customer Customer { get; set; }
        //public ICustomersRepository CustomerRepository { get; set; }

        public ICommand SaveCommand { get; set; }

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



        public CustomerEditViewModel()
        {
            //this.CustomerRepository = new CustomersRepository();
            //this.Customer = this.CustomerRepository.GetCustomerAsync(new Guid("11DA4696-CEA3-4A6D-8E83-013F1C479618")).Result;

            this.Customer = new Customer();
            this.Customer.FirstName = "first name";
            this.Customer.LastName = "last name";
            this.Customer.Phone = "phone";

            this.Customers = AllCustomers();

            this.SaveCommand = new RelayCommand(SaveCommandExecuted, SaveCommandCanExecute);
        }

        private void SaveCommandExecuted(object obj)
        {
            File.AppendAllText($@"{Directory.GetCurrentDirectory()}\ZzaPersons.txt",$"{this.Customer.FirstName}~{this.Customer.LastName}~{this.Customer.Phone}{Environment.NewLine}");
        }

        private bool SaveCommandCanExecute(object obj)
        {
            if (!string.IsNullOrEmpty(this.Customer.FirstName) && !string.IsNullOrEmpty(this.Customer.LastName) && !string.IsNullOrEmpty(this.Customer.Phone))
                return true;
            else
                return false;
        }

        private ObservableCollection<Customer> AllCustomers()
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

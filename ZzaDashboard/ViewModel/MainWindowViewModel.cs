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

namespace ZzaDashboard.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get => this.selectedCustomer;
            set
            {
                if (value == this.selectedCustomer)
                    return;

                this.selectedCustomer = value;
                this.OnPropertyChanged(nameof(this.SelectedCustomer));
            }
        }

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get => this.customers;
            set
            {
                if (value == this.customers)
                    return;

                this.customers = value;
                this.OnPropertyChanged(nameof(this.Customers));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public ICommand SaveCommand { get; set; }


        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            this.Customers = GetAllCustomers();

            this.SaveCommand = new RelayCommand(SaveCommandExecuted, SaveCommandCanExecute);

        }

        private ObservableCollection<Customer> GetAllCustomers()
        {
            string hugeText = string.Empty;
            var customers = new ObservableCollection<Customer>();
            using (var reader = new StreamReader($@"{Directory.GetCurrentDirectory()}\ZzaPersons.txt"))
            {
                hugeText = reader.ReadToEnd();
            }
            foreach (var line in hugeText.Split(Environment.NewLine.ToCharArray()))
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] lineArr = line.Split('~');
                var customer = new Customer();
                customer.FirstName = lineArr[0];
                customer.LastName = lineArr[1];
                customer.Phone = lineArr[2];
                customers.Add(customer);
            }

            return customers;
        }

        private void SaveCommandExecuted(object obj)
        {
            this.Customers.Add(this.SelectedCustomer);
            //this.Customers = new ObservableCollection<Customer>(base.Customers);
            File.AppendAllText($@"{Directory.GetCurrentDirectory()}\ZzaPersons.txt",
                $"{this.SelectedCustomer.FirstName}~{this.SelectedCustomer.LastName}~{this.SelectedCustomer.Phone}{Environment.NewLine}");
        }

        private bool SaveCommandCanExecute(object obj)
        {
            if (!string.IsNullOrEmpty(this.SelectedCustomer?.FirstName) && !string.IsNullOrEmpty(this.SelectedCustomer?.LastName) && !string.IsNullOrEmpty(this.SelectedCustomer?.Phone))
                return true;
            else
                return false;
        }
    }
}

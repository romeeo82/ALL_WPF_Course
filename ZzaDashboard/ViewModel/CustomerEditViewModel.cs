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
    class CustomerEditViewModel : MainViewModel
    {

        public Customer Customer { get; set; }
        //public ICustomersRepository CustomerRepository { get; set; }

        public ICommand SaveCommand { get; set; }

        public CustomerEditViewModel()
        {
            //this.CustomerRepository = new CustomersRepository();
            //this.Customer = this.CustomerRepository.GetCustomerAsync(new Guid("11DA4696-CEA3-4A6D-8E83-013F1C479618")).Result;

            this.Customer = new Customer();
            this.Customer.FirstName = "firstName";
            this.Customer.LastName = "lastName";
            this.Customer.Phone = "phone";

            this.SaveCommand = new RelayCommand(SaveCommandExecuted, SaveCommandCanExecute);
        }

        private void SaveCommandExecuted(object obj)
        {
            base.Customers.Add(this.Customer);
            File.AppendAllText($@"{Directory.GetCurrentDirectory()}\ZzaPersons.txt", $"{this.Customer.FirstName}~{this.Customer.LastName}~{this.Customer.Phone}{Environment.NewLine}");
        }

        private bool SaveCommandCanExecute(object obj)
        {
            if (!string.IsNullOrEmpty(this.Customer.FirstName) && !string.IsNullOrEmpty(this.Customer.LastName) && !string.IsNullOrEmpty(this.Customer.Phone))
                return true;
            else
                return false;
        }
    }
}

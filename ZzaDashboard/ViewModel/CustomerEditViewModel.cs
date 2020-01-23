using System;
using System.Collections.Generic;
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
    class CustomerEditViewModel
    {
        public Customer Customer { get; set; }
        //public ICustomersRepository CustomerRepository { get; set; }
        public ICommand SaveCommand { get; set; }

        public CustomerEditViewModel()
        {
            //this.CustomerRepository = new CustomersRepository();
            //this.Customer = this.CustomerRepository.GetCustomerAsync(new Guid("11DA4696-CEA3-4A6D-8E83-013F1C479618")).Result;
            this.Customer = new Customer();
            this.Customer.FirstName = "Petro";
            this.Customer.LastName = "Ivanov";
            this.Customer.Phone = "0572";

            this.SaveCommand = new RelayCommand(CommandBinding_SaveExecuted, CommandBinding_SaveCanExecute);
        }

        private void CommandBinding_SaveExecuted(object obj)
        {
            File.AppendAllText($@"{Directory.GetCurrentDirectory()}\ZzaPersons.txt",$"{this.Customer.FirstName}~{this.Customer.LastName}~{this.Customer.Phone}{Environment.NewLine}");
        }

        private bool CommandBinding_SaveCanExecute(object obj)
        {
            if (!string.IsNullOrEmpty(Customer.FirstName) && !string.IsNullOrEmpty(Customer.LastName) && !string.IsNullOrEmpty(Customer.Phone))
                return true;
            else
                return false;
        }
    }
}

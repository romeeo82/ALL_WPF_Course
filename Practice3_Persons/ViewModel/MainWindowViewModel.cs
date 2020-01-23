using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFpractice3.Model;

namespace WPFpractice3.ViewModel
{
    class MainWindowViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }
        public Person SelectedPerson { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public MainWindowViewModel()
        {
            Persons = new ObservableCollection<Person>();
            this.ShowCommand = new RelayCommand(CommandBinding_ShowExecuted, CommandBinding_ShowCanExecute);
            this.DeleteCommand = new RelayCommand(CommandBinding_DeleteExecuted, CommandBinding_DeleteCanExecute);
            this.NewCommand = new RelayCommand(CommandBinding_NewExecuted, CommandBinding_NewCanExecute);
        }
        private void CommandBinding_ShowExecuted(object obj)
        {
            string hugeText = string.Empty;
            using (var reader = new StreamReader($@"{Directory.GetCurrentDirectory()}\Persons.txt"))
            {
                hugeText = reader.ReadToEnd();
            }
            foreach (var line in hugeText.Split(Environment.NewLine.ToCharArray()))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    Person person = new Person();
                    person.Id = int.Parse(line.Split('~')[0]);
                    person.Name = line.Split('~')[1];
                    person.Department = line.Split('~')[2];
                    person.HiredDate = DateTime.Parse(line.Split('~')[4]);
                    person.IsManager = bool.Parse(line.Split('~')[3]);
                    Persons.Add(person);
                }
            }
        }

        private bool CommandBinding_ShowCanExecute(object obj)
        {
            if (Persons.Any())
                return false;
            else
                return true;
        }

        private void CommandBinding_DeleteExecuted(object obj)
        {
            if (SelectedPerson != null)
            {
                this.Persons.Remove(this.SelectedPerson);
            }
        }

        private bool CommandBinding_DeleteCanExecute(object obj)
        {
            if (this.SelectedPerson == null)
                return false;
            else
                return true;
        }

        private void CommandBinding_NewExecuted(object obj)
        {
            Persons.Add(new Person() { Id = 0, Name = "empty", Department = "empty", HiredDate = DateTime.Today, IsManager = false });
        }

        private bool CommandBinding_NewCanExecute(object obj)
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFpractice3.Model;

namespace WPFpractice3.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> Persons { get; set; }
        public Person SelectedPerson { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand NewCommand { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            Persons = new ObservableCollection<Person>();
            this.ShowCommand = new RelayCommand(ShowCommandExecuted, ShowCommandCanExecute);
            this.DeleteCommand = new RelayCommand(DeleteCommandExecuted, DeleteCommandCanExecute);
            this.NewCommand = new RelayCommand(NewCommandExecuted, NewCommandCanExecute);
        }
        private void ShowCommandExecuted(object obj)
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
                    person.HiredDate = DateTime.Parse(line.Split('~')[3]);
                    person.IsManager = bool.Parse(line.Split('~')[4]);
                    Persons.Add(person);
                }
            }
        }

        private bool ShowCommandCanExecute(object obj)
        {
            if (Persons.Any())
                return false;
            else
                return true;
        }

        private void DeleteCommandExecuted(object obj)
        {
            if (SelectedPerson != null)
            {
                this.Persons.Remove(this.SelectedPerson);
            }
        }

        private bool DeleteCommandCanExecute(object obj)
        {
            if (this.SelectedPerson == null)
                return false;
            else
                return true;
        }

        private void NewCommandExecuted(object obj)
        {
            Persons.Add(new Person() { Id = 0, Name = "empty", Department = "empty", HiredDate = DateTime.Today, IsManager = false });
        }

        private bool NewCommandCanExecute(object obj)
        {
            return true;
        }
    }
}

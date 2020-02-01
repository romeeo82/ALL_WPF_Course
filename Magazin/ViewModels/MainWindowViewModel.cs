using Magazin.Models;
using Magazin.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Magazin.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        const string Default = "Default";

        private Car selectedCar;
        public Car SelectedCar
        {
            get => this.selectedCar;
            set
            {
                if (value == this.selectedCar)
                    return;

                this.selectedCar = value;
                this.OnPropertyChanged(nameof(this.SelectedCar));
            }
        }

        public ObservableCollection<Car> cars;
        public ObservableCollection<Car> Cars
        {
            get => this.cars;
            set
            {
                if (value == this.cars)
                    return;

                this.cars = value;
                this.OnPropertyChanged(nameof(this.Cars));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand DefaultCommand { get; set; }

        public MainWindowViewModel()
        {
            this.Cars = CarFactory.GetCars();
            this.DeleteCommand = new RelayCommand(DeleteCommandExecuted);
            this.DefaultCommand = new RelayCommand(DefaultCommandExecuted);
        }

        private void DeleteCommandExecuted(object obj)
        {
            if (SelectedCar != null)
                this.Cars.Remove(this.SelectedCar);
        }

        private void DefaultCommandExecuted(object obj)
        {
            this.SelectedCar.Brand = Default;
            this.SelectedCar.Model = string.Empty;
            this.SelectedCar.Price = 0;
            this.SelectedCar.Picture = string.Empty;
            this.SelectedCar.Country = Default;
            this.SelectedCar.Color = Default;
            this.SelectedCar.Type = Default;
        }
    }
}

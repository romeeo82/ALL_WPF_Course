using MagazinWPFcoreDAL.Models;
using MagazinWPFcoreDAL;
using MagazinWPFcore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MagazinWPFcoreDAL.Repositories;

namespace MagazinWPFcore.ViewModels
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
        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private IRepository<Car> CarRepository { get; }

        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.CarRepository = new GenericRepository<Car>();
            this.Cars = new ObservableCollection<Car>(this.CarRepository.Get());

            this.DeleteCommand = new RelayCommand(DeleteCommandExecuted);
            this.DefaultCommand = new RelayCommand(DefaultCommandExecuted);
            this.AddCommand = new RelayCommand(AddCommandExecuted);
            this.SaveCommand = new RelayCommand(SaveCommandExecuted);
        }

        private void DeleteCommandExecuted(object obj)
        {
            if (SelectedCar != null)
            {
                this.CarRepository.Delete(this.SelectedCar);
                this.Cars.Remove(this.SelectedCar);
                this.CarRepository.Save();
            }
        }

        private void DefaultCommandExecuted(object obj)
        {
            this.SelectedCar.Brand = Default;
            this.SelectedCar.Model = Default;
            this.SelectedCar.Price = 0;
            this.SelectedCar.Picture = Default;
            this.SelectedCar.Country = Default;
            this.SelectedCar.Color = Default;
            this.SelectedCar.Type = Default;

            this.CarRepository.Update(this.SelectedCar);
            this.CarRepository.Save();
        }

        private void AddCommandExecuted(object obj)
        {
            var car = new Car() { Brand = Default, Model = Default, Picture = Default, Price = 0, Country = Default, Color = Default, Type = Default };
            this.Cars.Add(car);
            this.CarRepository.Add(car);
            this.CarRepository.Save();
        }

        private void SaveCommandExecuted(object obj)
        {
            this.CarRepository.Save();
        }
    }
}

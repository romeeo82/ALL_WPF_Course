using Magazin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Tools
{
    internal class CarFactory
    {
        public static ObservableCollection<Car> GetCars()
        {
            var cars = new ObservableCollection<Car>();
            cars.Add(new Car() { Brand = "Nissan", Model = "P12", Picture = $"{Directory.GetCurrentDirectory()}/nissan_primera_p12_grey.png", Price = 7, Country = "Japan", Color = "Grey", Type = "Sedan" });
            cars.Add(new Car() { Brand = "Haval", Model = "H6", Picture = $"{Directory.GetCurrentDirectory()}/haval_h6_blue.png", Price = 25, Country = "China", Color = "Grey", Type = "Crossover" });
            cars.Add(new Car() { Brand = "Lexus", Model = "RX300", Picture = $"{Directory.GetCurrentDirectory()}/lexus_rx300_blue.png", Price = 13, Country = "Japan", Color = "Blue", Type = "Crossover" });
            return cars;
        }
    }
}

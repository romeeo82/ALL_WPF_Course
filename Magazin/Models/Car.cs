using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Models
{
    internal class Car : INotifyPropertyChanged
    {
        private string brand;
        public string Brand
        {
            get => this.brand;
            set
            {
                if (value == this.brand)
                    return;

                this.brand = value;
                this.OnPropertyChanged(nameof(this.Brand));
            }
        }

        private string model;
        public string Model
        {
            get => this.model;
            set
            {
                if (value == this.model)
                    return;

                this.model = value;
                this.OnPropertyChanged(nameof(this.Model));
            }
        }

        private string picture;
        public string Picture
        {
            get => this.picture;
            set
            {
                if (value == this.picture)
                    return;

                this.picture = value;
                this.OnPropertyChanged(nameof(this.Picture));
            }
        }

        private decimal price;
        public decimal Price
        {
            get => this.price;
            set
            {
                if (value == this.price)
                    return;

                this.price = value;
                this.OnPropertyChanged(nameof(this.Price));
            }
        }

        private string country;
        public string Country
        {
            get => this.country;
            set
            {
                if (value == this.country)
                    return;

                this.country = value;
                this.OnPropertyChanged(nameof(this.Country));
            }
        }

        private string color;
        public string Color
        {
            get => this.color;
            set
            {
                if (value == this.color)
                    return;

                this.color = value;
                this.OnPropertyChanged(nameof(this.Color));
            }
        }

        private string type;
        public string Type
        {
            get => this.type;
            set
            {
                if (value == this.type)
                    return;

                this.type = value;
                this.OnPropertyChanged(nameof(this.Type));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

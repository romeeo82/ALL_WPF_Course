using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BooksWPF.Models
{
    public class Author:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string PlaceOfBirth { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        public Author()
        {
            Books = new ObservableCollection<Book>();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

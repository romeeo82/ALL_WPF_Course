using System;

namespace BooksWPF.Models
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvvmExample.DAL.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EntranceDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey ("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ObservableCollection<Book> Books { get; set; }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFpractice3.Model
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime HiredDate { get; set; }
        public bool IsManager { get; set; }
    }
}

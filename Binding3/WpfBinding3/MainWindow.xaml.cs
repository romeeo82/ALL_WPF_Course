using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBinding3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var pupil2 = new Pupil2 { FirstName = "Grisha", LastName = "Grigoriev", Degree = true };
            this.stackPanelPupil2.DataContext = pupil2;

            var toDoes = new List<ToDo>
            {
                new ToDo { TaskName = "Grocery", Description = "Pick up grocery", Priority = 2 },
                new ToDo { TaskName = "Laundry", Description = "Do laundry", Priority = 1 },
                new ToDo { TaskName = "Email", Description = "Check mail", Priority = 3 }
            };
            this.stackPanelToDo.DataContext = toDoes;

            var persons = new List<Person>
            {
                new Person {Id=1, Name="Max", Department="GIS dev", HiredDate = DateTime.Today.Date,IsManager=true},
                new Person {Id=2, Name="Wax", Department="GIS", HiredDate = DateTime.Today.Date.Subtract(TimeSpan.FromDays(1)),IsManager=true},
                new Person {Id=3, Name="Cox", Department="GIS", HiredDate = DateTime.UtcNow.Date.Subtract(TimeSpan.FromDays(2)),IsManager=false}
            };
            this.stackPanelPersons.DataContext = persons;
        }

        private void OnBtn1Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click performed");
        }
    }

    public class Pupil
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Degree { get; set; }
    }
    public class Pupil2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Degree { get; set; }
    }
    public class ToDo
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime HiredDate { get; set; }
        public bool IsManager { get; set; }
    }
}


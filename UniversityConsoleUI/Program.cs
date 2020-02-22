using System;
using University.DAL.Repositories;
using University.DAL;
using University.DAL.Models;

namespace University.ConsoleUI
{
    class Program
    {
        private static UnitOfWork unitOfWork = new UnitOfWork();

        static void Main(string[] args)
        {
            //StudentRepository studentRepository = new StudentRepository(new UniversityDbContext());
            //studentRepository.InsertStudent(new Student { FirstName = "Vlad", LastName = "Radchenko" });
            //studentRepository.Save();

            //var course = new Course { Name = "CSharpDotNet" };
            //unitOfWork.CourseRepository.Insert(course);

            //var department = new Department {Name="GISdev" };
            //unitOfWork.DepartmentRepository.Insert(department);

            //unitOfWork.Save();

            //var students = unitOfWork.StudentRepository.Get();
            //var departments = unitOfWork.DepartmentRepository.Get();
            //var courses = unitOfWork.CourseRepository.Get();

            MainMenuLaunch();
        }

        private static void MainMenuLaunch()
        {
            Console.Clear();
            Console.WriteLine(@"Press 1 to work with Students
Press 2 to work with Courses
Press 3 to work with Departments
Press 4 to view a list of all entities and propperties
");
            switch (Console.ReadLine())
            {
                case "1":
                    WorkWithStudents();
                    break;
                case "2":
                    WorkWithCourses();
                    break;
                case "3":
                    WorkWithDepartments();
                    break;
                case "4":
                    ViewAll();
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadKey();
            MainMenuLaunch();
        }

        private static void ViewAll()
        {
            Console.Clear();
            Console.WriteLine("--------All View--------");
            Console.WriteLine(AllStudentsToString());
            Console.WriteLine(AllCoursesToString());
            Console.WriteLine(AllDepartmentsToString());
        }

        private static string AllDepartmentsToString()
        {
            string tempText = "Departments\n";
            foreach (var dep in unitOfWork.DepartmentRepository.Get())
            {
                tempText += $"{dep.Id} {dep.Name}\n";
            }
            return tempText;
        }

        private static string AllCoursesToString()
        {
            string tempText = "Courses\n";
            foreach (var course in unitOfWork.CourseRepository.Get())
            {
                tempText += $"{course.Id} {course.Name} {course.Department?.Name}\n";
            }
            return tempText;
        }

        private static string AllStudentsToString()
        {
            string tempText = "Students\n";
            foreach (var student in unitOfWork.StudentRepository.Get())
            {
                tempText += $"{student.Id} {student.FirstName} {student.LastName} {student.Course?.Name}\n";
            }
            return tempText;
        }

        private static void WorkWithDepartments()
        {
            Console.Clear();
            Console.WriteLine(AllDepartmentsToString());
            Console.WriteLine(@"Press 1 to add a department
Press 2 to update a department
Press 3 to delete a department
Press m to go to main menu");
            switch (Console.ReadLine())
            {
                case "1":
                    AddDepartment();
                    break;
                case "2":
                    UpdateDepartment();
                    break;
                case "3":
                    DeleteDepartment();
                    break;
                case "m":
                    MainMenuLaunch();
                    break;
            }
            Console.WriteLine(AllDepartmentsToString());
            Console.WriteLine("Press any key");
            Console.ReadKey();
            WorkWithDepartments();
        }

        private static void DeleteDepartment()
        {
            Console.Write("Type department Id to delete-->");
            var department = unitOfWork.DepartmentRepository.GetById(int.Parse(Console.ReadLine()));
            unitOfWork.DepartmentRepository.Delete(department);
            unitOfWork.Save();
            Console.WriteLine($"Department {department.Id} deleted");
        }

        private static void UpdateDepartment()
        {
            Console.Write("Type department Id to change-->");
            var department = unitOfWork.DepartmentRepository.GetById(int.Parse(Console.ReadLine()));
            Console.Write("Type department new Name-->");
            department.Name = Console.ReadLine();
            unitOfWork.Save();
            Console.WriteLine($"Department {department.Id} changed");
        }

        private static void AddDepartment()
        {
            Console.Write("Type department name-->");
            var department = new Department { Name = Console.ReadLine() };
            unitOfWork.DepartmentRepository.Insert(department);
            unitOfWork.Save();
            Console.WriteLine($"Department {department.Name} added");
        }

        private static void WorkWithCourses()
        {
            Console.Clear();
            Console.WriteLine(AllCoursesToString());
            Console.WriteLine(@"Press 1 to add a course
Press 2 to update a course
Press 3 to delete a course
Press m to go to main menu");
            switch (Console.ReadLine())
            {
                case "1":
                    AddCourse();
                    break;
                case "2":
                    UpdateCourse();
                    break;
                case "3":
                    DeleteCourse();
                    break;
                case "m":
                    MainMenuLaunch();
                    break;
            }
            Console.WriteLine(AllCoursesToString());
            Console.WriteLine("Press any key");
            Console.ReadKey();
            WorkWithCourses();
        }

        private static void DeleteCourse()
        {
            Console.Write("Type course Id to delete-->");
            var course = unitOfWork.CourseRepository.GetById(int.Parse(Console.ReadLine()));
            unitOfWork.CourseRepository.Delete(course);
            unitOfWork.Save();
            Console.WriteLine($"Course {course.Id} deleted");
        }

        private static void UpdateCourse()
        {
            Console.Write("Type course Id to change-->");
            var course = unitOfWork.CourseRepository.GetById(int.Parse(Console.ReadLine()));
            Console.Write("Wanna change course name? y/n-->");
            if (Console.ReadLine() == "y")
            {
                Console.Write("Type course new name-->");
                course.Name = Console.ReadLine();
            }
            Console.WriteLine("Wanna change department for the course? y/n");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine(AllDepartmentsToString());
                Console.Write("Type department Id to apply-->");
                course.Department = unitOfWork.DepartmentRepository.GetById(int.Parse(Console.ReadLine()));
            }
            unitOfWork.Save();
            Console.WriteLine($"Course {course.Id} changed");
        }

        private static void AddCourse()
        {
            Console.Write("Type course name-->");
            var course = new Course { Name = Console.ReadLine() };
            Console.WriteLine(AllDepartmentsToString());
            Console.Write("Type department id-->");
            course.Department = unitOfWork.DepartmentRepository.GetById(int.Parse(Console.ReadLine()));
            unitOfWork.CourseRepository.Insert(course);
            unitOfWork.Save();
            Console.WriteLine($"Course {course.Name} added to Department {course.Department.Name}");
        }

        private static void WorkWithStudents()
        {
            Console.Clear();
            Console.WriteLine(AllStudentsToString());
            Console.WriteLine(@"Press 1 to add a student
Press 2 to update a student
Press 3 to delete a student
Press m to go to main menu");
            switch (Console.ReadLine())
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    UpdateStudent();
                    break;
                case "3":
                    DeleteStudent();
                    break;
                case "m":
                    MainMenuLaunch();
                    break;
            }
            Console.WriteLine(AllStudentsToString());
            Console.WriteLine("Press any key");
            Console.ReadKey();
            WorkWithStudents();
        }

        private static void DeleteStudent()
        {
            Console.Write("Type student Id to delete-->");
            var student = unitOfWork.StudentRepository.GetById(int.Parse(Console.ReadLine()));
            unitOfWork.StudentRepository.Delete(student);
            unitOfWork.Save();
            Console.WriteLine($"Student {student.Id} deleted");
        }

        private static void UpdateStudent()
        {
            Console.Write("Type student Id to change-->");
            var student = unitOfWork.StudentRepository.GetById(int.Parse(Console.ReadLine()));
            Console.Write("Wanna change student name? y/n-->");
            if (Console.ReadLine() == "y")
            {
                Console.Write("Type student new first name-->");
                student.FirstName = Console.ReadLine();
                Console.Write("Type student new last name-->");
                student.LastName = Console.ReadLine();
            }
            Console.WriteLine("Wanna change course for the student? y/n");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine(AllCoursesToString());
                Console.Write("Type course Id to apply-->");
                student.Course = unitOfWork.CourseRepository.GetById(int.Parse(Console.ReadLine()));
            }
            unitOfWork.Save();
            Console.WriteLine($"Student {student.Id} changed");
        }

        private static void AddStudent()
        {
            var student = new Student();
            Console.Write("Type student first name-->");
            student.FirstName = Console.ReadLine();
            Console.Write("Type student new last name-->");
            student.LastName = Console.ReadLine();
            Console.WriteLine(AllCoursesToString());
            Console.Write("Type course Id to apply-->");
            student.Course = unitOfWork.CourseRepository.GetById(int.Parse(Console.ReadLine()));
            unitOfWork.StudentRepository.Insert(student);
            unitOfWork.Save();
            Console.WriteLine($"Student {student.FirstName} {student.LastName} added to Course {student.Course.Name}");
        }
    }
}

using System;
using System.Collections.ObjectModel;
using MvvmExample.DAL.Model;
using MvvmExample.DAL.Services;
using Presentation.Extensions;


namespace Presentation.ViewModel
{
    public class StudentViewModel : ViewModelBase.ViewModelBase
    {
        private ObservableCollection<Student> students;
        private Student selectedStudent;

        private Book selectedBook;

        private readonly IStudentService studentService;

        public StudentViewModel(IStudentService studentService)
        {
            if (studentService == null) throw new ArgumentNullException(nameof(studentService));

            this.studentService = studentService;
            this.Students = new ObservableCollection<Student>();

            this.GetStudentsCommmand = new DelegateCommand.DelegateCommand(this.ExecuteGetStudents);
            this.SaveStudentsCommand = new DelegateCommand.DelegateCommand(this.ExecuteSaveStudents, this.CanExecuteSaveStudents);
            this.DeleteStudentCommand = new DelegateCommand.DelegateCommand(this.ExecuteDeleteStudent, this.CanExecuteDeleteStudent);
            this.DeleteBookCommand = new DelegateCommand.DelegateCommand(this.ExecuteDeleteBook, this.CanExecuteDeleteBook);
        }

        private bool CanExecuteDeleteBook()
        {
            return this.selectedBook != null;
        }

        private void ExecuteDeleteBook()
        {
            this.studentService.DeleteBook(this.SelectedStudent.Id,this.SelectedBook);
            this.selectedStudent.Books.Remove(this.SelectedBook);
            this.studentService.SaveStudents();
        }

        private bool CanExecuteDeleteStudent()
        {
            return this.selectedStudent != null;
        }

        private void ExecuteDeleteStudent()
        {
            this.studentService.DeleteStudent(this.SelectedStudent);
            this.Students.Remove(this.SelectedStudent);
            this.studentService.SaveStudents();
        }

        private bool CanExecuteSaveStudents()
        {
            return this.selectedStudent != null;
        }

        private void ExecuteSaveStudents()
        {
            this.studentService.SaveStudents();
        }

        private void ExecuteGetStudents()
        {
            this.Students = this.studentService.GetStudents().ToObservableCollection();
        }

        public ObservableCollection<Student> Students
        {
            get { return this.students; }
            set
            {
                this.students = value;
                this.OnPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get { return this.selectedStudent; }
            set
            {
                this.selectedStudent = value;
                this.OnPropertyChanged();
            }
        }

        public Book SelectedBook
        {
            get { return this.selectedBook; }
            set
            {
                this.selectedBook = value;
                this.OnPropertyChanged();
            }
        }

        public DelegateCommand.DelegateCommand GetStudentsCommmand { get; }

        public DelegateCommand.DelegateCommand SaveStudentsCommand { get; }

        public DelegateCommand.DelegateCommand DeleteStudentCommand { get; }

        public DelegateCommand.DelegateCommand DeleteBookCommand { get; }

    }
}
using BooksWPF.Models;
using BooksWPF.Tools;
using BooksWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;



namespace BooksWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Author> AuthorCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.AuthorCollection = new ObservableCollection<Author>
            {
                new Author {Id=1, FirstName="Mark",LastName="Twain",
                    BirthDate = new DateTime(1835,11,30), Country = Countries.USA.ToString(),
                    Language = Languages.English.ToString(), PlaceOfBirth = "Florida, Missouri",
                Books = new ObservableCollection<Book>{ new Book() {Title = "Tom Soyer advantures", Cost=2.50M, Date = DateTime.Today } } },
                new Author {Id=1, FirstName="Taras",LastName="Shevchenko",
                    BirthDate = new DateTime(1814,03,09), Country = Countries.Ukraine.ToString(),
                    Language = Languages.Ukrainian.ToString(), PlaceOfBirth = "Morintsy, Cherkasskaya obl",
                Books = new ObservableCollection<Book>{ new Book() {Title = "Kobzar", Cost=3.50M,Date = DateTime.Today.Subtract(TimeSpan.FromDays(1)) } } }
            };

            this.DataContext = AuthorCollection;

            this.dgComboboxLanguage.ItemsSource = Enum.GetValues(typeof(Languages)).Cast<Languages>();

        }

        private void CommandBinding_NewAuthorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Author auth = new Author();
            var authWindow = new NewAuthor(auth);
            if ((bool)authWindow.ShowDialog())
                this.AuthorCollection.Add(auth);
        }

        private void CommandBinding_NewAuthorCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_RemoveAuthorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.AuthorCollection.Remove((Author)authorsListView.SelectedItem);
        }

        private void CommandBinding_RemoveAuthorCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.authorsListView.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CommandBinding_ChangeAuthorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Author auth = this.authorsListView.SelectedItem as Author;
            auth.IsNew = false;
            var authWindow = new NewAuthor(auth);
            authWindow.ShowDialog();
            this.authorsListView.Items.Refresh();

        }

        private void CommandBinding_ChangeAuthorCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.authorsListView.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
            this.authorsListView.Items.Refresh();
        }

        private void CommandBinding_NewBookExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var curAuth = (Author)this.authorsListView.SelectedItem;
            var book = new Book();
            var bookWindow = new NewBook(book);
            if ((bool)bookWindow.ShowDialog())
                curAuth.Books.Add(book);
        }

        private void CommandBinding_NewBookCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.authorsListView.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        private void CommandBinding_RemoveBookExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var curAuth = (Author)this.authorsListView.SelectedItem;
            curAuth.Books.Remove((Book)this.booksDataGrid.SelectedItem);
        }

        private void CommandBinding_RemoveBookCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.booksDataGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CommandBinding_ChangeBookExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Book book = this.booksDataGrid.SelectedItem as Book;
            book.IsNew = false;
            var bookWindow = new NewBook(book);
            bookWindow.ShowDialog();
            this.booksDataGrid.Items.Refresh();
        }

        private void CommandBinding_ChangeBookCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.booksDataGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }
}

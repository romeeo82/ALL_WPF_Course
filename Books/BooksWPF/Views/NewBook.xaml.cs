using BooksWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace BooksWPF.Views
{
    /// <summary>
    /// Interaction logic for NewBook.xaml
    /// </summary>
    public partial class NewBook : Window
    {
        private Book bookCached;
        private Book bookOld;
        public NewBook(Book book)
        {
            InitializeComponent();

            this.bookCached = new Book();
            this.DataContext = this.bookCached;
            this.bookOld = book;

            this.bookCached.Title = book.Title;
            this.bookCached.Cost = book.Cost;
            this.bookCached.Date = book.Date;
            this.bookCached.IsNew = book.IsNew;
        }

        private void CommandBinding_OkExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.bookOld.Title = bookCached.Title;
            this.bookOld.Cost = bookCached.Cost;
            this.bookOld.Date = bookCached.Date;        

            this.DialogResult = true;
            this.Close();
        }

        private void CommandBinding_OkCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_CancelExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void CommandBinding_CancelCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}

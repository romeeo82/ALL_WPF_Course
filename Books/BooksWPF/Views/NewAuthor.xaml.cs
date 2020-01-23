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
using BooksWPF.Models;
using BooksWPF.Tools;


namespace BooksWPF.Views
{
    /// <summary>
    /// Interaction logic for NewAuthor.xaml
    /// </summary>
    public partial class NewAuthor : Window
    {
        private Author authorCached;
        private Author authorOld;
        public NewAuthor(Author author)
        {
            InitializeComponent();


            this.authorCached = new Author();
            this.DataContext = this.authorCached;
            this.authorOld = author;

            this.authorCached.FirstName = author.FirstName;
            this.authorCached.LastName = author.LastName;
            this.authorCached.BirthDate = author.BirthDate;
            this.authorCached.Country = author.Country;
            this.authorCached.Language = author.Language;
            this.authorCached.PlaceOfBirth = author.PlaceOfBirth;
            this.authorCached.IsNew = author.IsNew;

            this.cmbCountry.ItemsSource = Enum.GetValues(typeof(Countries)).Cast<Countries>();
            this.cmbLanguage.ItemsSource = Enum.GetValues(typeof(Languages)).Cast<Languages>();
        }


        private void CommandBinding_OkExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.authorOld.FirstName = this.authorCached.FirstName;
            this.authorOld.LastName = this.authorCached.LastName;
            this.authorOld.BirthDate = this.authorCached.BirthDate;
            this.authorOld.Country = this.authorCached.Country;
            this.authorOld.Language = this.authorCached.Language;
            this.authorOld.PlaceOfBirth = this.authorCached.PlaceOfBirth;

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

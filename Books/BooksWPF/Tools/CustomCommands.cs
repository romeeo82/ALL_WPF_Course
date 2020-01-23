using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksWPF.Tools
{
    public class CustomCommands
    {
        public static RoutedUICommand NewAuthor { get; set; }
        public static RoutedUICommand ChangeAuthor { get; set; }
        public static RoutedUICommand RemoveAuthor { get; set; }
        public static RoutedUICommand NewBook { get; set; }
        public static RoutedUICommand ChangeBook { get; set; }
        public static RoutedUICommand RemoveBook { get; set; }
        public static RoutedUICommand Ok { get; set; }
        public static RoutedUICommand Cancel { get; set; }
        static CustomCommands()
        {
            CustomCommands.NewAuthor = new RoutedUICommand(nameof(NewAuthor), nameof(NewAuthor), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.ChangeAuthor = new RoutedUICommand(nameof(ChangeAuthor), nameof(ChangeAuthor), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.RemoveAuthor = new RoutedUICommand(nameof(RemoveAuthor), nameof(RemoveAuthor), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.NewBook = new RoutedUICommand(nameof(NewBook), nameof(NewBook), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.ChangeBook = new RoutedUICommand(nameof(ChangeBook), nameof(ChangeBook), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.RemoveBook = new RoutedUICommand(nameof(RemoveBook), nameof(RemoveBook), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.Ok = new RoutedUICommand(nameof(Ok), nameof(Ok), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.Cancel = new RoutedUICommand(nameof(Cancel), nameof(Cancel), typeof(MainWindow), new InputGestureCollection());
        }
    }
}

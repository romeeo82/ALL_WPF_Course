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

namespace WpfCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var bind = new CommandBinding(ApplicationCommands.Open);
            bind.Executed += Bind_Executed;
            bind.CanExecute += Bind_CanExecute;
            this.CommandBindings.Add(bind);

            var bindBtn = new CommandBinding(ApplicationCommands.New);
            bindBtn.Executed += BindBtn_Executed;
            bindBtn.CanExecute += BindBtn_CanExecute;
            this.CommandBindings.Add(bindBtn);
        }

        private void BindBtn_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void BindBtn_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Grid_Click(sender, e);
        }

        private void Bind_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.chbox.IsChecked.Value;
        }
        private void Bind_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("command exe");
        }


        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            if (feSource is Button)
            {
                string option = (feSource as Button).Content.ToString();
                switch (option)
                {
                    case "←": EraseOneChar(tbMain); break;

                    case "CE": ClearTbText(tbMain); break;

                    case "C": ClearTbText(tbMain); break;

                    case "+-": SetMinusOffOn(option, tbMain); break;

                    case "=": Calculate(tbMain); break;

                    case "/": AddTextToTb(option, tbMain); break;

                    case "*": AddTextToTb(option, tbMain); break;

                    case "-": AddTextToTb(option, tbMain); break;

                    case "+": AddTextToTb(option, tbMain); break;

                    case ".": AddTextToTb(option, tbMain); break;

                    case "0": AddTextToTb(option, tbMain); break;

                    case "1": AddTextToTb(option, tbMain); break;

                    case "2": AddTextToTb(option, tbMain); break;

                    case "3": AddTextToTb(option, tbMain); break;

                    case "4": AddTextToTb(option, tbMain); break;

                    case "5": AddTextToTb(option, tbMain); break;

                    case "6": AddTextToTb(option, tbMain); break;

                    case "7": AddTextToTb(option, tbMain); break;

                    case "8": AddTextToTb(option, tbMain); break;

                    case "9": AddTextToTb(option, tbMain); break;

                    default: break;
                }
            }
        }

        private void Calculate(TextBlock tbMain)
        {
            try
            {
                char div = '\0';

                if (tbMain.Text.Contains('/')) div = '/';
                else if (tbMain.Text.Contains('*')) div = '*';
                else if (tbMain.Text.Contains('+')) div = '+';
                else if (tbMain.Text.Contains('-')) div = '-';

                double num1 = double.Parse(tbMain.Text.Split(div)[0]);
                double num2 = double.Parse(tbMain.Text.Split(div)[1]);

                tbMain.Text = Calc(num1, num2, div);
            }
            catch
            {
                MessageBox.Show("Parsing failed!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Cancel, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private string Calc(double num1, double num2, char div)
        {
            double result = 0;

            if (div == '/') result = num1 / num2;
            else if (div == '*') result = num1 * num2;
            else if (div == '+') result = num1 + num2;
            else if (div == '-') result = num1 - num2;

            return result.ToString();
        }

        private void SetMinusOffOn(string option, TextBlock tbMain)
        {
            option = "-";
            if (string.IsNullOrEmpty(tbMain.Text) || tbMain.Text[0].ToString() != option)
                tbMain.Text = tbMain.Text.Insert(0, option);
            else
                tbMain.Text = tbMain.Text.Remove(0, 1);
        }

        private void AddTextToTb(string option, TextBlock tbMain)
        {
            tbMain.Text += option;
        }

        private void ClearTbText(TextBlock tbMain)
        {
            tbMain.Text = string.Empty;
        }

        private void EraseOneChar(TextBlock tbMain)
        {
            if (!string.IsNullOrEmpty(tbMain.Text))
                tbMain.Text = tbMain.Text.Remove(tbMain.Text.Length - 1, 1);
        }

        private void btnTest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Button btn = sender as Button;
            btn.Tag = 1;
        }

        private void tbTest_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Panel.SetZIndex(sender as TextBox, 0);
            }
        }
    }


    public static class MyCommands
    {
        public static RoutedCommand ChangeButtonStatus { get; set; }
        public static RoutedCommand PressButtonConmmand { get; set; }

        static MyCommands()
        {
            ChangeButtonStatus = new RoutedCommand(nameof(ChangeButtonStatus), typeof(MainWindow));
            PressButtonConmmand = new RoutedCommand(nameof(PressButtonConmmand), typeof(MainWindow));
        }
    }
}

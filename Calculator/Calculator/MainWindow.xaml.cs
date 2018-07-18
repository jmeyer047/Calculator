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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNum = 0, result = 0, negative = -1;
        Operator op;

        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += acButton_Click;
            negButton.Click += NegButton_Click;
            percentButton.Click += percentButton_Click;
            equalButton.Click += equalButton_Click;
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NegButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNum)){
                lastNum *= negative;
                resultLabel.Content = lastNum.ToString();
            }
        }

        private void percentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNum)){
                lastNum = lastNum / 100;
                resultLabel.Content = lastNum.ToString();
            }
        }

        private void operation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNum))
            {
                resultLabel.Content = "0";
            }

            if(sender == plusButton)
            {
                op = Operator.Addition;
            }
            if(sender == minusButton)
            {
                op = Operator.Subtraction;
            }
            if(sender == divButton)
            {
                op = Operator.Division;
            }
            if(sender == multButton)
            {
                op = Operator.Multiplication;
            }
        }

        private void numButton_Click(object sender, RoutedEventArgs e)
        {
            int pressedNum = 0;

            if(sender == zero)
            {
                pressedNum = 0;
            }
            if (sender == one)
            {
                pressedNum = 1;
            }
            if (sender == two)
            {
                pressedNum = 2;
            }
            if (sender == three)
            {
                pressedNum = 3;
            }
            if (sender == four)
            {
                pressedNum = 4;
            }
            if (sender == five)
            {
                pressedNum = 5;
            }
            if (sender == six)
            {
                pressedNum = 6;
            }
            if (sender == seven)
            {
                pressedNum = 7;
            }
            if (sender == eight)
            {
                pressedNum = 8;
            }
            if (sender == nine)
            {
                pressedNum = 9;
            }

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{pressedNum}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{pressedNum}";
            }
        }

        private void decimal_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {

            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            double secNum = 0;

            if (double.TryParse(resultLabel.Content.ToString(), out secNum))
            {
                switch (op)
                {
                    case Operator.Addition:
                        {
                            result = Arithmetic.Add(lastNum, secNum);
                            break;
                        }
                    case Operator.Division:
                        {
                            result = Arithmetic.Div(lastNum, secNum);
                            break;
                        }
                    case Operator.Multiplication:
                        {
                            result = Arithmetic.Mult(lastNum, secNum);
                            break;
                        }
                    case Operator.Subtraction:
                        {
                            result = Arithmetic.Sub(lastNum, secNum);
                            break;
                        }
                }
                resultLabel.Content = result.ToString();
            }
        }
    }

    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class Arithmetic
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Div(double n1, double n2)
        {
            return n1 / n2;
        }
        public static double Mult(double n1, double n2)
        {
            return n1 * n2;
        }
    }
}

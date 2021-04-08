using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public class MainLogic
    {
        StringBuilder buildRoman = new StringBuilder();
    SortedDictionary<int, int> digits;

    public string BuildRomanNumber(string wert)
    {
        int eingabe = Convert.ToInt32(wert);
        digits = GetDigits(eingabe);

        if (digits.Count == 4)
        {
            buildRoman = ProcessThousands(digits);
            digits.Remove(digits.ElementAt(3).Key);
        }

        if (digits.Count == 3)
        {
            buildRoman = ProcessHundreds(digits, buildRoman);
            digits.Remove(digits.ElementAt(2).Key);
        }

        if (digits.Count == 2)
        {
            buildRoman = ProcessTens(digits, buildRoman);
            digits.Remove(digits.ElementAt(1).Key);
        }

        if (digits.Count == 1)
        {
            buildRoman = ProcessOnes(digits, buildRoman);
        }
        string str = buildRoman.ToString();

        return str;
    }
    public static StringBuilder ProcessThousands(SortedDictionary<int, int> dict)
    {
        StringBuilder sb = new StringBuilder();
        int multipleOfThousand;

        // Fourth digit:
        int i = 3;

        multipleOfThousand = dict.ElementAt(i).Value / 1000;
        switch (multipleOfThousand)
        {
            case 1:
                sb.Append("M");
                break;
            case 2:
                sb.Append("MM");
                break;
            case 3:
                sb.Append("MMM");
                break;
            default:
                sb.Append("");
                break;
        }

        return sb;
    }
    public static StringBuilder ProcessHundreds(SortedDictionary<int, int> dict, StringBuilder sb)
    {
        // Third digit:
        int i = 2;

        int digitExtracted = dict.ElementAt(i).Value;
        if (digitExtracted >= 100 && digitExtracted <= 400)
            sb.Append("C");
        if (digitExtracted >= 200 && digitExtracted <= 300)
            sb.Append("C");
        if (digitExtracted == 300)
            sb.Append("C");
        if (digitExtracted == 400)
            sb.Append("D");
        if (digitExtracted >= 500 && digitExtracted <= 800)
            sb.Append("D");
        if (digitExtracted >= 600 && digitExtracted <= 800)
            sb.Append("C");
        if (digitExtracted >= 700 && digitExtracted <= 800)
            sb.Append("C");
        if (digitExtracted == 800)
            sb.Append("C");
        if (digitExtracted == 900)
            sb.Append("CM");

        return sb;
    }
    public static StringBuilder ProcessTens(SortedDictionary<int, int> dict, StringBuilder sb)
    {
        // Second digit:
        int i = 1;

        int digitExtracted = dict.ElementAt(i).Value;
        if (digitExtracted >= 10 && digitExtracted <= 40)
            sb.Append("X");
        if (digitExtracted >= 20 && digitExtracted <= 30)
            sb.Append("X");
        if (digitExtracted == 30)
            sb.Append("X");
        if (digitExtracted == 40)
            sb.Append("L");
        if (digitExtracted >= 50 && digitExtracted <= 80)
            sb.Append("L");
        if (digitExtracted >= 60 && digitExtracted <= 80)
            sb.Append("X");
        if (digitExtracted >= 70 && digitExtracted <= 80)
            sb.Append("X");
        if (digitExtracted == 80)
            sb.Append("X");
        if (digitExtracted == 90)
            sb.Append("XC");

        return sb;
    }
    public static StringBuilder ProcessOnes(SortedDictionary<int, int> dict, StringBuilder sb)
    {
        int i = 0;
        int digitExtracted = dict.ElementAt(i).Value;
        if (digitExtracted >= 1 && digitExtracted <= 4)
            sb.Append("I");
        if (digitExtracted >= 2 && digitExtracted <= 3)
            sb.Append("I");
        if (digitExtracted == 3)
            sb.Append("I");
        if (digitExtracted == 4)
            sb.Append("V");
        if (digitExtracted >= 5 && digitExtracted <= 8)
            sb.Append("V");
        if (digitExtracted >= 6 && digitExtracted <= 8)
            sb.Append("I");
        if (digitExtracted >= 7 && digitExtracted <= 8)
            sb.Append("I");
        if (digitExtracted == 8)
            sb.Append("I");
        if (digitExtracted == 9)
            sb.Append("IX");

        return sb;
    }

    // Extract a sorted dictionary for the decomposition of number in the format:
    // (0: x1), where x1: x1 * 10^0
    // (1: x2), where x2: x2 * 10^1
    // (2: x3), where x3: x3 * 10^2
    // (3: x4), where x4: x4 * 10^3
    public static SortedDictionary<int, int> GetDigits(int number)
    {
        int originalNumber = number;
        string currentNumberAsString = number.ToString();
        SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

        int length = currentNumberAsString.Length;
        for (int i = 1; i < length; i++)
        {
            // Divide and cut decimals:
            number = (int)(number / Math.Pow(10, length - i));
            // Revert back to original with no digits to the right:
            number = (int)(number * Math.Pow(10, length - i));
            digits.Add(length - i, (int)(number));

            // Reduce:
            number = originalNumber - number;
            originalNumber = number;
        }
        // For x1: x1 * 10^0 omit the manipulation:
        digits.Add(0, (int)(number));

        return digits;
    }
}
public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtInputRoman.Focus();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            MainLogic ml = new MainLogic();
            string inputString = txtInputRoman.Text;
            string outputString;
            int numberParsed;
            bool resultOfParsing = int.TryParse(inputString, out numberParsed);
            if (resultOfParsing == false)
            {
                lblMessage.Content = "Sorry, your input was not an integer.";
                lblMessage.Content += "Please try again.";
            }
            else if (numberParsed < 0 || numberParsed > 3999)
            {
                lblMessage.Content = "Sorry, your input was an integer outside the range [0, 3999].";
                lblMessage.Content += "Please try again.";
            }
            else
            {
                // When input was valid instantiate an object for the conversion logic:
                outputString = ml.BuildRomanNumber(inputString);
                txtOutputArabic.Text = outputString;
            }
        }

        private void txtInputRoman_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtOutputArabic.Text = "";
            lblMessage.Content = "";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace WpfApp1
{
    // Author: Dirk Mueller
    // Date: 09.04.2021
    //
    // Algorithm:
    // 1. Check the validity of the inout 
    // 2. If correct traverse the roman number from left to right. Distinguish between
    //    the case where a subtraction is necessary, and where not
    // 3. Successively add the number until the cummulative value is the final


    public class MainLogic1
    {
        readonly SortedDictionary<int, char> numberLetter = new SortedDictionary<int, char>
        {
            {1000, 'M'}, {500, 'D'}, {100, 'C'}, {50, 'L'}, {10, 'X' }, {5, 'V'}, {1, 'I'}
        };
        readonly SortedDictionary<char, int> letterNumber = new SortedDictionary<char, int>
        {
            {'M', 1000}, {'D', 500}, {'C', 100}, {'L', 50}, {'X', 10 }, {'V', 5}, {'I', 1}
        };

        public int? GetValueForKey(char letter)

        {
            int result;
            if (letterNumber.TryGetValue(letter, out result))
            {
                return result;
            }
            return null;
        }

        // When a smaller roman number precedes a larger number return true:
        public bool CanSubtractConsecutiveValues(char left, char right)
        {
            if (letterNumber[right] > letterNumber[left])
            {
                return true;
            }
            else
                return false;
        }

        // Calculate arabic number. If not possible return null:
        public int? CalculateArabicNumber(string romanNumber)
        {
            int? cummulativeValue = 0;
            int i = 0;
            string messageText;

            StringBuilder sb = new StringBuilder();
            romanNumber = romanNumber.TrimEnd(' ');
            string romanToUpper = romanNumber.ToUpper();
            sb.Append(romanToUpper);

            // Check if the input does not represent an existing roman number:
            if (ForbiddenCombinationOrMaximumNumberOfSameLetterExceeded(romanToUpper))
            {
                return null;
            }

            // Special case if only one roman letter:
            if (sb.Length == 1)
            {
                cummulativeValue = GetValueForKey(sb[0]);
            }

            Boolean t = false;
            // Traverse the roman number from left to right. Distinguish between
            // the case where a subtraction is necessary, and where not:
            while (i < sb.Length - 1)
            {
                if (CanSubtractConsecutiveValues(sb[i], sb[i + 1]))
                {
                    cummulativeValue += GetValueForKey(sb[i + 1]) - GetValueForKey(sb[i]);
                    i++;
                    if (i == sb.Length - 2)
                        t = true;
                }
                else
                {
                    cummulativeValue += GetValueForKey(sb[i]);
                    if (i == sb.Length - 2)
                        cummulativeValue += GetValueForKey(sb[i + 1]);
                }
                i++;
            }
            if (i == sb.Length - 1 && t)
            {
                cummulativeValue += GetValueForKey(sb[i]);
            }

            return cummulativeValue;
        }

        // Return true if the input did not obey the rules (not a roman number):
        public Boolean ForbiddenCombinationOrMaximumNumberOfSameLetterExceeded(string str)
        {
            // Define array with characters M, C, X, I from sorted dictionary:
            char[] chMCXI = new char[4] { numberLetter[1000], numberLetter[100],
                                          numberLetter[10], numberLetter[1] };

            // Define array with characters V, L, D from sorted dictionary:
            char[] chVLD = new char[3] { numberLetter[5], numberLetter[50],
                                         numberLetter[500] };

            int countRepititions = 0;
            // For each of the characters M, C, X, I calculate amount of repititions:
            foreach (var item in chMCXI)
            {
                for (int m = 0; m < str.Length - 1; m++)
                {
                    // Check if the running character is any of ('M', 'C', 'X', 'I') AND 
                    // if it repeats with the next character:
                    if ((str[m] == item) && str[m] == str[m + 1])
                        countRepititions++;
                }
                if (countRepititions > 2)
                {
                    return true;
                }
                countRepititions = 0;
            }

            countRepititions = 0;
            // For each of the characters V, L, D calculate amount of repititions:
            foreach (var item in chVLD)
            {
                for (int m = 0; m < str.Length - 1; m++)
                {
                    // Check if the running character is any of ('V', 'L', 'D') 
                    // AND if it repeats with the next character:
                    if ((str[m] == item) && str[m] == str[m + 1])
                        countRepititions++;
                }
                if (countRepititions > 0)
                {
                    return true;
                }
                countRepititions = 0;
            }

            for (int h = 1; h < str.Length - 1; h++)
            {
                // Check if the running character is of ('M', 'C', 'X', 'I') AND 
                // if it repeats with the next character:
                if (CanSubtractConsecutiveValues(str[h], str[h + 1]) && str[h - 1] == str[h])
                {
                    return true;
                }
            }

            for (int j = 0; j < str.Length - 1; j++)
            {
                // Check if for V any bigger number comes after it:
                if (str[j] == 'V' && str[j + 1] == 'X' && str[j + 1] == 'L'
                                  && str[j + 1] == 'C' && str[j + 1] == 'D'
                                  && str[j + 1] == 'M')
                {
                    return true;
                }
            }

            for (int j = 0; j < str.Length - 1; j++)
            {
                // Check if for L any bigger number comes after it:
                if (str[j] == 'L' && str[j + 1] == 'C' && str[j + 1] == 'D'
                                  && str[j + 1] == 'M')
                {
                    return true;
                }
            }

            for (int j = 0; j < str.Length - 1; j++)
            {
                // Check if for M any bigger number comes after it:
                if (str[j] == 'D' && str[j + 1] == 'M')
                {
                    return true;
                }
            }

            // In all other cases it is a valid input and return false:
            return false;
        }

        // Return false if any input character does not represent a roman number:
        public Boolean AllCharactersPresentedAreUsedInRomaNumbers(string str)
        {
            foreach (var item in str.ToUpper())
            {
                if (!letterNumber.ContainsKey(item))
                    return false;
            }
            return true;
        }
    }


    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtInputRoman.Focus();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            int? value;
            MainLogic1 ml1 = new MainLogic1();
            string messageText;
            string strInput = txtInputRoman.Text;

            if (ml1.AllCharactersPresentedAreUsedInRomaNumbers(strInput))
            {
                value = ml1.CalculateArabicNumber(strInput);

                if (value != null)
                {
                    txtOutputArabic.Text = value.ToString();
                }
                else
                {
                    messageText = "Sorry, there was a problem in your input.\n";
                    messageText += "Check the following rules:\n";
                    messageText += "1.) The symbols V, L and D are never repeated.\n";
                    messageText += "2.) The symbols V, L and D are never written \n     ";
                    messageText += "to the left of a symbol of greater value\n";
                    messageText += "3.) Any symbol may not occur more than three times.\n";
                    messageText += "\nPlease try again";
                    lblMessage.Content = messageText;
                }
            }
            else
            {
                messageText = "At least one character does not represent a roman number.\n";
                messageText += "\nPlease try again";
                lblMessage.Content = messageText;
            }
        }

        private void txtInputRoman_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtOutputArabic.Text = "";
            lblMessage.Content = "";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
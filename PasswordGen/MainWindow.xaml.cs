using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PasswordGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string GeneratedPassword;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GeneratePassword(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordLength.Text))
            {
                OutputLabel.Text = "ERROR: Please choose a password length";
            }
            else
            {
                int passwordLengthValue = Int32.Parse(PasswordLength.Text);
                List<string> allCharacters = SetCharacters();
                
                int totalListSize = allCharacters.Count;
                if (totalListSize == 0)
                {
                    OutputLabel.Text = "ERROR: You must check at least one of the boxes";
                }
                else
                {
                    var random = new Random();
                    List<string> passwordOutput = new List<string>();
                    for (int i = 0; i < passwordLengthValue; i++)
                    {
                        var character = random.Next(totalListSize);
                        passwordOutput.Add(allCharacters[character]);
                    }
                    string combindedString = string.Join(",", passwordOutput);
                    string x = combindedString.Replace(",", "");
                    GeneratedPassword = x;
                    OutputLabel.Text = x;
                }
            }
        }

        private List<string> SetCharacters()
        {
            List<string> allCharacters = new List<string>();
            if (LowerCase.IsChecked ?? false)
            {
                string[] lowerCaseValues = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                allCharacters.AddRange(lowerCaseValues);
            }

            if (UpperCase.IsChecked ?? false)
            {
                string[] upperCaseValues = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                allCharacters.AddRange(upperCaseValues);
            }

            if (Symbols.IsChecked ?? false)
            {
                string[] symbols = { "!", "£", "$", "%", "^", "&", "*", "(", ")", "_", "-", "[", "]", "{", "}", "#", "~", "@", ";", ":", "<", ">", ".", "/", "?", "\\", "|", "\"" };
                allCharacters.AddRange(symbols);
            }

            if (Numbers.IsChecked ?? false)
            {
                string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                allCharacters.AddRange(numbers);
            }

            return allCharacters;
        }

        private void CopyPassword(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(GeneratedPassword);
        }
    }
}

using System;
using System.Windows;
using System.Windows.Input;

namespace Cesar
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void codeButton_Click(object sender, RoutedEventArgs e)
        {
            if (codeRadioBtn.IsChecked.HasValue && codeRadioBtn.IsChecked.Value)
            {
                if (KeyCheck())
                    outputTextBox.Text = Decoder.CodeAndDecodeTheText(inputTextBox.Text, keyTextBox.Text, true) ;
            }
            else
            {
                outputTextBox.Text = Decoder.CodeAndDecodeTheText(inputTextBox.Text, keyTextBox.Text, false);
            }
        }

        private bool KeyCheck()
        {
            bool succces = false;
            try
            {
                int key = int.Parse(keyTextBox.Text);
                succces = true;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Wartość nie mieści się w zakresie.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Wprowadź tylko liczby.");
            }
            return succces;
        }

        private void ClearTextBox(object sender, MouseButtonEventArgs e)
        {
            keyTextBox.Text = "";
        }

        private void ClearTextToCodeText(object sender, MouseButtonEventArgs e)
        {
            inputTextBox.Text = "";
        }
    }
}

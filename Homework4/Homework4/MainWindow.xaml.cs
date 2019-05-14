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
using System.Text.RegularExpressions;

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String txtValue = null;
      

        public MainWindow()
        {
            InitializeComponent();
            //submit button starts off as hidden
            uxSubmit.Visibility = Visibility.Hidden;


        }

        private void UxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            //submit button starts off as hidden
            uxSubmit.Visibility = Visibility.Hidden;


            //define regex
            var usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
            var canZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

            //store user input.  gets re-evaluated with each keystroke
            txtValue = ((TextBox)sender).Text.ToString();

            if ((Regex.Match(txtValue, usZipRegEx).Success) || (Regex.Match(txtValue, canZipRegEx).Success))
            {
                //pattern match means button is visible
                uxSubmit.Visibility = Visibility.Visible;
            }

          
        }
    }
}

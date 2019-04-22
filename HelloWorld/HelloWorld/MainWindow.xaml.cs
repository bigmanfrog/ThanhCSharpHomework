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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool nameLenghthPositive = false;
        bool passwordLengthPositive = false;
        bool enableSubmitButton = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UxSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Submitting password:" + uxPassword.Text);
        }

        private void UxName_TextChanged(object sender, TextChangedEventArgs e)
        {
           if (uxName.Text.Length > 0)
            {
                
                nameLenghthPositive = true;
                

                if (passwordLengthPositive == true)
                {
                    
                    enableSubmitButton = true;
                    uxSubmit.IsEnabled = enableSubmitButton;
               
                }
               
            }
            else
            {
                nameLenghthPositive = false;

                enableSubmitButton = false;
                uxSubmit.IsEnabled = enableSubmitButton;


            }
        }

        private void UxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxPassword.Text.Length > 0)
            {
                passwordLengthPositive = true;

                if (nameLenghthPositive == true)
                {
                    enableSubmitButton = true;
                    uxSubmit.IsEnabled = enableSubmitButton;

                }
            }
            else
            {
                passwordLengthPositive = false;
                enableSubmitButton = false;
                uxSubmit.IsEnabled = enableSubmitButton;

            }
        }
    }
}

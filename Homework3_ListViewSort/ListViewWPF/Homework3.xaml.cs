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
using System.Windows.Shapes;
using System.ComponentModel;


namespace ListViewWPF
{
    /// <summary>
    /// Interaction logic for Homework3.xaml
    /// </summary>
    public partial class Homework3 : Window
    {


        private GridViewColumnHeader listViewSortCol = null;
        public Homework3()
        {
            InitializeComponent();


            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "2DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "1StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
        }

        private void uxListColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //clear any sort criteria
            uxList.Items.SortDescriptions.Clear();

            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();


            
            uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
        }
    }
}

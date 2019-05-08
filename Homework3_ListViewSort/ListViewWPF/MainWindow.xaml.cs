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
using System.ComponentModel;
using ListViewWPF;



namespace ListViewWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                    (
                        AdornedElement.RenderSize.Width - 15,
                        (AdornedElement.RenderSize.Height - 5) / 2
                    );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }
        //private GridViewColumnHeader listViewSortCol = null;
        private GridViewColumnHeader listViewSortCol = null;
        //private SortAdorner listViewSortAdorner = null;
        private SortAdorner listViewSortAdorner = null;
        public MainWindow()
        {
            InitializeComponent();
            List<myUser> items = new List<myUser>();
            items.Add(new myUser() { Name = "John Doe", Age = 42, Email = "JohnDoe@gamajamamail.com"});
            items.Add(new myUser() { Name = "Jane Doe", Age = 42, Email = "JaneDoe@hotmail.com"});
            items.Add(new myUser() { Name = "Sammy Doe", Age = 13, Email = "SammyDoe@gmail.com" });
            
            lvUsers.ItemsSource = items; //lvUsers is the name of the list view
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource); //instanctiate a CollectionView called view
            //view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
            //view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
            //view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));//multiple sort criterias can be done by .adding a new SortDescription instance


        }

        public class myUser
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Email { get; set; }

            public override string ToString()
            {
                return this.Name + " " + this.Age + " " + this.Email;
            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader); //type sets from XAML representation to C# representation
            string sortBy = column.Tag.ToString(); //grabs the tag of column
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lvUsers.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lvUsers.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));

        }

     
    }
}

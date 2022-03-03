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

namespace OOD_Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Create a new database connection
        private Model1Container db = new Model1Container();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Triggered when the main window is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //Query the db for all authors
            var query = from a in db.Authors
                                    select a;

            //Assign the resulting list of authors as data source for 
            //The authors listbox
            LSTBX_Authors.ItemsSource = query.ToList();
        }

        /// <summary>
        /// Triggered when an author in the listbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LSTBX_Authors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //Get reference to the listbox that sent this event
            ListBox box = (ListBox) sender;
            //Get reference to the selected author
            Author author = (Author)box.SelectedItem;

            //If the author selected is not null
            if (author != null)
            {
                //Query the database for the boos matching the selected author
                var query = 
                                            from b in db.Books
                                            where b.Author.Id == author.Id
                                            select b.Title;

                //Assign the query's result set as the data source for the books listbox
                LSTBXBooks.ItemsSource = query.ToList();
            }
        }
    }

    public partial class Author
    {
        /// <summary>
        /// Overrides the ToString Method of the parent class. 
        /// </summary>
        /// <returns>Returns the name property value as a string</returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

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

namespace Lab13_WPF_ToDo_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Global Variables
        List<string> items = new List<string>();
        List<Task> tasksItems = new List<Task>();
        Dictionary<int,string> getCategoryID = new Dictionary<int,string>();
        BrushConverter brush = new BrushConverter();
        Task taskToAdd = new Task();
        List<Category> categories = new List<Category>();
        #endregion

        #region MainWindow Constructor
        public MainWindow()
        {
            InitializeComponent();
            //InitialiseListBoxOFStrings();
            Initialise();
            InitialiseGetCategoriesID();
        }
        #endregion

        #region InitialiseListBoxOFStrings
        void InitialiseListBoxOFStrings()
        {
            /*
            items.Add("This is a listbox");
            items.Add("This is a listbox 1");
            items.Add("This is a listbox 2");
            */
            ListBoxTasks.ItemsSource = items;
            using (var db = new TasksDBEntities())
            {
                tasksItems = db.Tasks.ToList();
            }
            // Listbox only uses strings, so we have to use the descriptions
            items.Add($"{"ID",-30} {"Description",-30}{"Done?",-30}{"Date Completed"}");
            foreach (Task t in tasksItems)
            {
                items.Add($"{t.TasksID} {")",-29} { t.Description,-29} {t.Done,-29} {t.DateDone}");
            }
        }
        #endregion

        #region Initialise
        void Initialise()
        {
            using (var db = new TasksDBEntities())
            {
                tasksItems = db.Tasks.ToList();
                categories = db.Categories.ToList();
            }
            ListBoxTasks.ItemsSource = tasksItems;
            ListBoxTasks.DisplayMemberPath = "Description";
            ComboBoxCategory.ItemsSource = categories;
            ComboBoxCategory.DisplayMemberPath = "CategoryName";
        }
        #endregion

        #region InitialiseGetCategoriesID
        void InitialiseGetCategoriesID()
        {
            using (var db = new TasksDBEntities())
            {
                var getCategory = db.Categories.ToList();
                foreach (Category item in getCategory)
                {
                    getCategoryID.Add(item.CategoriesID, item.CategoryName);
                }
            }
        }
        #endregion

        #region List TaskBoxes
        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxCategory.IsReadOnly = true;
            TextBoxCategory.Background = (Brush)brush.ConvertFrom("#D1ADFF");
            TextBoxDescription.IsReadOnly = true;
            TextBoxDescription.Background = (Brush)brush.ConvertFrom("#D1ADFF");
            taskToAdd = (Task)ListBoxTasks.SelectedItem;
            if (taskToAdd != null)
            {
                // Print out details of a selected Item
                // instance = (convert to Task) the item selected by the user
                TextBoxID.Text = taskToAdd.TasksID.ToString();
                TextBoxDescription.Text = taskToAdd.Description.ToString();
                TextBoxCategory.Text = taskToAdd.CategoriesID.ToString();
                TextBoxID.IsReadOnly = true;
                TextBoxCategory.IsReadOnly = true;
                TextBoxDescription.IsReadOnly = true;
                ButtonEdit.IsEnabled = true;
                ButtonEdit.Content = "Edit";
                ButtonDelete.IsEnabled = true;
                ButtonDelete.Content = "Delete";
                ButtonAdd.Content = "Add";
                if (taskToAdd.CategoriesID != null)
                {
                    ComboBoxCategory.IsEnabled = true;
                    ComboBoxCategory.SelectedIndex = (int)taskToAdd.CategoriesID - 1;
                    ComboBoxCategory.IsEnabled = false;
                }
                else
                {
                    ComboBoxCategory.IsEnabled = true;
                    ComboBoxCategory.SelectedItem = null;
                    ComboBoxCategory.IsEnabled = false;
                }
            }
        }
        #endregion

        #region Edit
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                TextBoxCategory.IsReadOnly = false; // Can edit
                TextBoxCategory.Background = Brushes.White;
                TextBoxDescription.IsReadOnly = false;
                TextBoxDescription.Background = Brushes.White;
                ButtonEdit.IsEnabled = true;
                ButtonEdit.Content = "Save";
                ComboBoxCategory.IsEnabled = true;
            }
            else if (ButtonEdit.Content.ToString() == "Save")
            {
                using (var db = new TasksDBEntities())
                {
                    var taskToEdit = db.Tasks.Find(taskToAdd.TasksID);
                    // Update description and CategoryID
                    taskToEdit.Description = TextBoxDescription.Text;
                    // Converting category id to integeer from textbox (string)
                    // Safe way of doing a conversion: null
                    int.TryParse(TextBoxCategory.Text, out int categoryid);
                    taskToEdit.CategoriesID = categoryid;
                    // Save changes to the database
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null; // reset listbox
                    tasksItems = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasksItems;
                    ComboBoxCategory.IsEnabled = true;
                    ComboBoxCategory.SelectedIndex = (int)taskToEdit.CategoriesID - 1;
                    ComboBoxCategory.IsEnabled = false;
                }

                
                TextBoxCategory.IsReadOnly = true;
                TextBoxCategory.Background = (Brush)brush.ConvertFrom("#D1ADFF");
                TextBoxDescription.IsReadOnly = true;
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#D1ADFF");
                ButtonEdit.IsEnabled = false;
                ButtonEdit.Content = "Edit";
                ButtonDelete.IsEnabled = false;

            }
        }
        #endregion

        #region Add
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonAdd.Content.ToString() == "Add")
            {
                ButtonAdd.Content = "Confirm?";
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategory.Background = Brushes.White;
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategory.IsReadOnly = false;
                // Clear out boxes
                TextBoxID.Text = "";
                TextBoxDescription.Text = "";
                TextBoxCategory.Text = "";
            }
            else if (ButtonAdd.Content.ToString() == "Confirm?")
            {
                int.TryParse(TextBoxCategory.Text, out int categoryid);
                taskToAdd = new Task()
                {
                    Description = TextBoxDescription.Text,
                    CategoriesID = categoryid
                };

                using (var db = new TasksDBEntities())
                {
                    db.Tasks.Add(this.taskToAdd);
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null; // reset listbox
                    tasksItems = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasksItems;
                }
                TextBoxCategory.IsReadOnly = true;
                TextBoxCategory.Background = (Brush)brush.ConvertFrom("#D1ADFF");
                TextBoxDescription.IsReadOnly = true;
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#D1ADFF");
                ButtonAdd.Content = "Add";
                TextBoxID.Text = "";
                TextBoxDescription.Text = "";
                TextBoxCategory.Text = "";
                ComboBoxCategory.Text = "";
            }
        }

        #endregion

        #region Delete
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.ToString() == "Delete")
            {
                ButtonDelete.Content = "You Sure?";
                TextBoxID.Background = Brushes.Red;
                TextBoxDescription.Background = Brushes.Red;
                TextBoxCategory.Background = Brushes.Red;
            }
            else if (ButtonDelete.Content.ToString() == "You Sure?")
            {
                
                using (var db = new TasksDBEntities())
                {
                    var removeItemID = db.Tasks.Find(taskToAdd.TasksID);
                    db.Tasks.Remove(removeItemID);
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null; // reset listbox
                    tasksItems = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasksItems;
                }
                ButtonDelete.Content = "Delete";
                ButtonDelete.IsEnabled = false;
                ButtonEdit.IsEnabled = false;
                TextBoxID.Background = (Brush)brush.ConvertFrom("#D1ADFF");
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#D1ADFF");
                TextBoxCategory.Background = (Brush)brush.ConvertFrom("#D1ADFF");
                TextBoxID.Text = "";
                TextBoxDescription.Text = "";
                TextBoxCategory.Text = "";
                ComboBoxCategory.Text = "";
            }
        }
        #endregion

        #region ComboBoxCategory_SelectionChanged
        private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string category = ComboBoxCategory.Text;
            if (ComboBoxCategory.Text != "")
            {
                using (var db = new TasksDBEntities())
                {
                    if (getCategoryID.ContainsValue(category))
                    {
                        TextBoxCategory.Text = getCategoryID.FirstOrDefault(x => x.Value == category).Key.ToString();
                    }
                    
                    //var id = db.Entry(new Category).
                    //TextBoxCategory.Text = id.CategoriesID.ToString();
                }
            }
        }
        #endregion
    }
}

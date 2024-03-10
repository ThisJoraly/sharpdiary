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

namespace asswecan
{

    public partial class MainWindow : Window
    {
        public static int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            datepicker.SelectedDate = DateTime.Today;

        }


        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox.SelectedItem != null)
                this.Title = (listbox.SelectedItem as Note).NoteName;
        }

        private void datepicker_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (datepicker.SelectedDate.HasValue)
            {
                loadNotes(datepicker.SelectedDate.Value);
            }
        }
        private void loadNotes(DateTime date) {
            var notes = Notes.GetNotesForDate(date);
            listbox.ItemsSource = notes;
        }


        private void button_create_Click(object sender, RoutedEventArgs e)
        {
            note_name.Text = null;
            note_description.Text = null;
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            /*Создать*/
            DateTime? date = datepicker.SelectedDate;
            string name = note_name.Text;
            string description = note_description.Text;
            Note n = new Note(name, description, date);
            Notes.notes.Add(n);
            listbox.ItemsSource = null;
            Json<List<Note>> json = new Json<List<Note>>();
            /*            json.Serialize(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\notes.json", Notes.notes);
                       *//* JsonUtil<Note>.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\notes.json", n ,Notes.notes);*//*
                        listbox.ItemsSource = json.Deserialize(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\notes.json");*/
            listbox.ItemsSource = Notes.notes;
            listbox.Items.Refresh();
            counter++;

        }
        
        private void button_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void note_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

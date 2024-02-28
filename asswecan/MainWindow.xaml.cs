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

        public MainWindow()
        {
            InitializeComponent();
            datepicker.SelectedDate = DateTime.Today;

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            /*Создать*/
            DateTime? date = datepicker.SelectedDate;
            string name = name_for_note.Text;
            string description = discript_for_note.Text;
            Note n = new Note(name, description, date);
            Note.notes.Add(n);
            zalupa.Text = name;
            listbox.ItemsSource = Note.notes;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void name_for_note_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox.SelectedItem != null)
                this.Title = (listbox.SelectedItem as Note).getNoteName();
        }

        private void datepicker_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}

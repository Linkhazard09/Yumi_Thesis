using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace Yumi_Thesis
{
    /// <summary>
    /// Interaction logic for ParticipantEntry.xaml
    /// </summary>
    public partial class ParticipantEntry : Window
    {
        public ParticipantEntry()
        {
            InitializeComponent();
           
        }

        private void ResponseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(LastNameTextBox.Text =="" || LastNameTextBox.Text == "Last Name")
            {
                MessageBox.Show("Please enter your name before proceeding","Name Entry");
                return;
            }
            else if(ResponseTextBox.Text=="" || ResponseTextBox.Text == "Given Name")
            {
                MessageBox.Show("Please enter your name before proceeding", "Name Entry");
                return;
            }

            string name = ResponseTextBox.Text + " " + LastNameTextBox.Text;
            var MainWindow = new MainWindow(name);
            MainWindow.Show();
            this.Close();





        }

        private void ResponseTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ResponseTextBox.Text = "";
            ResponseTextBox.Foreground = Brushes.Black;
           


        }

        private void LastNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            LastNameTextBox.Text = "";
            LastNameTextBox.Foreground = Brushes.Black;
           
           
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Begin_Label.Foreground = Brushes.LightGray;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Begin_Label.Foreground = Brushes.Black;
        }
    }
}

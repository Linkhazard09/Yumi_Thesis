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
            AcceptInput.IsEnabled = false;
        }

        private void ResponseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ResponseTextBox.Text != "")
            {
                AcceptInput.IsEnabled = true;
            }
            else
                AcceptInput.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow(ResponseTextBox.Text);
            MainWindow.Show();
            this.Close();





        }
    }
}

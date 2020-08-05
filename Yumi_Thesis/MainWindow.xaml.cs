using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Yumi_Thesis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] FN = { "01", "02", "03","04","05","06","07","08","09","10","11","12","13","14","15","16","17","18","19","20","21" };
        int upperLim=104;
        public string[] IF = {"A","B","C","D","E" };
     
        List<string> Function = new List<string>();
        public string ParticipantName;
        public string[] Answers = { "", "", "", "", "", "", "" };
        public int AnswerCounter = -1;
        public string PreviousFN;



        public MainWindow(string ParticipantName)
        {
            InitializeComponent();
            this.ParticipantName = ParticipantName;
            int x = 0;
            foreach(string i in FN)
            {
                for (int z = 0; z != 5; z++)
                Function.Add( i + IF[z] +".png");
                x++;
            }
            
            Random R1 = new Random();
            int Index = R1.Next(0,upperLim);
            string imgSource = Function[Index];
            PreviousFN = Function[Index].Substring(0, 2);
            Function.RemoveAt(Index);
            upperLim = Function.Count();
            MessageBox.Show(imgSource);
           

        }

        private void F_Button_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BlurEffect blur = new BlurEffect() { Radius = 35 };
            Start_Image.Effect = blur;

            Random R1 = new Random();
            int Index = R1.Next(0,upperLim);
            string imgSource = Function[Index];
           

            while (PreviousFN == Function[Index])
            {
                 R1 = new Random();
                Index = R1.Next(0, upperLim);
                imgSource = Function[Index];

            }
            PreviousFN = Function[Index].Substring(0, 2);
            Function.RemoveAt(Index);
            upperLim = Function.Count();
            MessageBox.Show(imgSource);
        }

        private void Start_Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BlurEffect blur = new BlurEffect() { Radius = 0 };
            Start_Image.Effect = blur;
        }

        private void AVPFS_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SB_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CC_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DB_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ACA_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DEH_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WFM_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CFCS_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CDSMH_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GITS_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WH_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void USH_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DD_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ATYF_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WCP_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ATPKC_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SHHQ_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SD_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ASPLSG_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DTFMWC_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

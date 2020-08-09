using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;


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
        public string currentAnswer;
        List<string> Function = new List<string>();
        public string ParticipantName;
        public string[] Answers = { "", "", "", "", "", "", "" };
        public int AnswerCounter = 0;
        public string PreviousFN;
        public string CurrentImage;
        public string FirstAnswer ="";
        Stopwatch StpWatch = new Stopwatch();
        
     


        public MainWindow(string ParticipantName)
        {
            InitializeComponent();
            this.ParticipantName = ParticipantName;
            int x = 0;
            foreach(string i in FN)
            {
                for (int z = 0; z != 5; z++)
                Function.Add(IF[z]+i  +".jpg");
                x++;
            }

            Next_Button.IsEnabled = false;
           

        }

        private void F_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "01";


            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = "01";


        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            bool isCorrect = CurrentImage.Contains(currentAnswer) ;
            StpWatch.Stop();
            string ms = StpWatch.Elapsed.ToString(@"ms");
            int Secs = Convert.ToInt32(StpWatch.Elapsed.TotalSeconds);
            string TotalTime = Secs + ":" + ms;
            





            if (isCorrect)
                MessageBox.Show("Correct");
            else
                MessageBox.Show("Incorrect");

           



            currentAnswer = "" ;
            Start_Label.IsEnabled = true;
            Start_Label.Content = "Start";
            Start_Image.Source = new BitmapImage(new Uri("", UriKind.Relative));
            int ctr = 0;
          foreach (string i in Answers)
            {
                Answers[ctr] = "";
                ctr++;
            }



        }

        private void Start_Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void AVPFS_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "08";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void SB_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "02";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void CC_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "03";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void DB_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "04";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;


        }

        private void ACA_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "10";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void DEH_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "06";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void WFM_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "12";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void CFCS_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "09";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void CDSMH_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "07";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void GITS_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "11";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void WH_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "05";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void USH_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "15";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void DD_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "19";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void ATYF_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "17";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void WCP_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "18";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void ATPKC_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "16";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void SHHQ_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "20";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void SD_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "21";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void ASPLSG_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "13";
            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;

        }

        private void DTFMWC_Button_Click(object sender, RoutedEventArgs e)
        {
            Next_Button.IsEnabled = true;
            currentAnswer = "14";

            if (AnswerCounter > 6)
                AnswerCounter = 6;

            Answers[AnswerCounter] = currentAnswer;
            AnswerCounter++;

            if (FirstAnswer == "")
                FirstAnswer = currentAnswer;


        }

        private void Start_Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Random R1 = new Random();
            int Index = R1.Next(0, upperLim);
            string imgSource = "/Images/"+Function[Index];
            PreviousFN = Function[Index].Substring(0, 3);
            Function.RemoveAt(Index);
            upperLim = Function.Count();
            CurrentImage = Function[Index];
           
            Start_Image.Source = new BitmapImage(new Uri(imgSource,UriKind.Relative));
            Start_Label.Content = "";
            Start_Label.IsEnabled = false;
            StpWatch.Start();
            
            









        }
    }
}

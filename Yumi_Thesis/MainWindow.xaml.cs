﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using System.Windows.Markup;
using System.Globalization;
using MatchingTestExperiment;

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
        public string PreviousFN="none";
        public string CurrentImage;
        public string FirstAnswer ="";
        public string[] Sequence = new string[105];
        public List<string> SequenceCompleted = new List<string>();
        int SequenceCounter = 0;
        Stopwatch StpWatch = new Stopwatch();
        
     


        public MainWindow(string ParticipantName)
        {
            InitializeComponent();
            this.ParticipantName = ParticipantName;
            int x = 0;
            foreach(string i in FN)
            {
                for (int z = 0; z < 5; z++)
                Function.Add(IF[z] + i  +".jpg");
                x++;
            }

            Next_Button.IsEnabled = false;
           

            ExcelIntegration excel = new ExcelIntegration();

            excel.CreateExcel();
            SequenceCompleted = excel.LoadfromExcel(ParticipantName);

            if(SequenceCompleted.Count == Function.Count)
            {
                MessageBox.Show("You have already completed the Matching Test Experiment","Completion");
             
                this.Close();
            }



            Function = Function.Except(SequenceCompleted).ToList();
            upperLim = Function.Count();
            ImagesCounter.Content = upperLim.ToString();

            F_Button.IsEnabled = false;
            AVPFS_Button.IsEnabled = false;
            SB_Button.IsEnabled = false;
            CC_Button.IsEnabled = false;
            DB_Button.IsEnabled = false;
            ACA_Button.IsEnabled = false;
            DEH_Button.IsEnabled = false;
            WFM_Button.IsEnabled = false;
            CFCS_Button.IsEnabled = false;
            CDSMH_Button.IsEnabled = false;
            GITS_Button.IsEnabled = false;
            WH_Button.IsEnabled = false;
            USH_Button.IsEnabled = false;
            DD_Button.IsEnabled = false;
            ATYF_Button.IsEnabled = false;
            WCP_Button.IsEnabled = false;
            ATPKC_Button.IsEnabled = false;
            SHHQ_Button.IsEnabled = false;
            SD_Button.IsEnabled = false;
            ASPLSG_Button.IsEnabled = false;
            DTFMWC_Button.IsEnabled = false;


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

            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;


        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ExcelIntegration excel = new ExcelIntegration();
            bool isCorrect = CurrentImage.Contains(currentAnswer);
            StpWatch.Stop();
            string ms = StpWatch.Elapsed.ToString(@"ff");
            int Secs = Convert.ToInt32(StpWatch.Elapsed.TotalSeconds);
            string TotalTime = Secs + ":" + ms;
            string accuracy="0";


            if (isCorrect)
                accuracy = "1";

           
            

            string Current = CurrentImage.Substring(0, 3);
            excel.WriteToExcel(ParticipantName,Current,accuracy,TotalTime,Answers);



            if (upperLim == 0)
            {
                MessageBox.Show("The matching test experiment has been completed. Thank you for participating!", "Preference Test Experiment");
                this.Close();
                
            }

            int x = upperLim;
            ImagesCounter.Content = x.ToString();




            //Code below is for reset of controls
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
            AnswerCounter =0;
            StpWatch.Reset();

            ResetButtons();
            Next_Button.IsEnabled = false ;
            F_Button.IsEnabled = false;
            AVPFS_Button.IsEnabled = false;
            SB_Button.IsEnabled = false;
            CC_Button.IsEnabled = false;
            DB_Button.IsEnabled = false;
            ACA_Button.IsEnabled = false;
            DEH_Button.IsEnabled = false;
            WFM_Button.IsEnabled = false;
            CFCS_Button.IsEnabled = false;
            CDSMH_Button.IsEnabled = false;
            GITS_Button.IsEnabled = false;
            WH_Button.IsEnabled = false;
            USH_Button.IsEnabled = false;
            DD_Button.IsEnabled = false;
            ATYF_Button.IsEnabled = false;
            WCP_Button.IsEnabled = false;
            ATPKC_Button.IsEnabled = false;
            SHHQ_Button.IsEnabled = false;
            SD_Button.IsEnabled = false;
            ASPLSG_Button.IsEnabled = false;
            DTFMWC_Button.IsEnabled = false;

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

            F_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;


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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;

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

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
          


        }

        private void Start_Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            Random R1 = new Random();
            int Index = R1.Next(0, upperLim);
            string imgSource = "/Images/"+ Function[Index];

           while(imgSource.Contains(PreviousFN) & upperLim >10)
            {
                R1 = new Random();
                Index = R1.Next(0, upperLim);
                imgSource = "/Images/" + Function[Index];
            }

            PreviousFN = Function[Index].Substring(1, 2);
            CurrentImage = Function[Index];
            Sequence[SequenceCounter] = imgSource;
            SequenceCounter++;
            Function.RemoveAt(Index);
            upperLim = Function.Count();
           
           
            Start_Image.Source = new BitmapImage(new Uri(imgSource,UriKind.Relative));
            Start_Label.Content = "";
            Start_Label.IsEnabled = false;
            StpWatch.Start();

            F_Button.IsEnabled = true;
            AVPFS_Button.IsEnabled = true;
            SB_Button.IsEnabled = true;
            CC_Button.IsEnabled = true;
            DB_Button.IsEnabled = true;
            ACA_Button.IsEnabled = true;
            DEH_Button.IsEnabled = true;
            WFM_Button.IsEnabled = true;
            CFCS_Button.IsEnabled = true;
            CDSMH_Button.IsEnabled = true;
            GITS_Button.IsEnabled = true;
            WH_Button.IsEnabled = true;
            USH_Button.IsEnabled = true;
            DD_Button.IsEnabled = true;
            ATYF_Button.IsEnabled = true;
            WCP_Button.IsEnabled = true;
            ATPKC_Button.IsEnabled = true;
            SHHQ_Button.IsEnabled = true;
            SD_Button.IsEnabled = true;
            ASPLSG_Button.IsEnabled = true;
            DTFMWC_Button.IsEnabled = true;









        }

        private void ResetButtons()
        {

            F_Button.IsChecked = false;
            AVPFS_Button.IsChecked = false;
            SB_Button.IsChecked = false;
            CC_Button.IsChecked = false;
            DB_Button.IsChecked = false;
            ACA_Button.IsChecked = false;
            DEH_Button.IsChecked = false;
            WFM_Button.IsChecked = false;
            CFCS_Button.IsChecked = false;
            CDSMH_Button.IsChecked = false;
            GITS_Button.IsChecked = false;
            WH_Button.IsChecked = false;
            USH_Button.IsChecked = false;
            DD_Button.IsChecked = false;
            ATYF_Button.IsChecked = false;
            WCP_Button.IsChecked = false;
            ATPKC_Button.IsChecked = false;
            SHHQ_Button.IsChecked = false;
            SD_Button.IsChecked = false;
            ASPLSG_Button.IsChecked = false;
            DTFMWC_Button.IsChecked = false;



        }



    }


   

   




}


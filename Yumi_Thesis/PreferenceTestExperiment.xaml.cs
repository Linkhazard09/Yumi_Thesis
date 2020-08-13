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
using Yumi_Thesis;

namespace MatchingTestExperiment
{
    /// <summary>
    /// Interaction logic for PreferenceTestExperiment.xaml
    /// </summary>
    public partial class PreferenceTestExperiment : Window
    {
        public string ParticipantName;
        public int SequenceCtr = 0;
        public List<string> Sequence = new List<string>();
        private List<string> Completed = new List<string>();
       

      // Like, Look, Effective, Clarity, Strength, Familiar, Complex, Organize, Clutter, Recognize, Abstract, Compatible
        public int[] Scores = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };




        public PreferenceTestExperiment(string ParticipantName)//Declare Sequence here
        {
            InitializeComponent();
            this.ParticipantName = ParticipantName;
            ExcelIntegration excel = new ExcelIntegration();
            excel.CreatePart2();
            Sequence = excel.LoadfromExcel(ParticipantName);
            Completed = excel.LoadfromExcel2(ParticipantName);
            Sequence = Sequence.Except(Completed).ToList();
            string ImgSource = "/Images/" + Sequence[SequenceCtr];
            FunctionImage.Source = new BitmapImage(new Uri(ImgSource, UriKind.Relative));
            SequenceCtr++;
            Function_Name.Text = Labeltest(ImgSource);


        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           if(SequenceCtr > Sequence.Count())
            {
                MessageBox.Show("You have evaluated all of the images. Thank you for participating in the experiment. Please forward the Experiment Test Results excel file to yumibalatbat@gmail.com", "Completion");
                this.Close();
            }
            
            foreach(int i in Scores)
            {
                if(i == 0)
                {
                    MessageBox.Show("Please make sure all fields are filled up before proceeding", "Value Missing");
                    return;
                }
             }
            ExcelIntegration excel = new ExcelIntegration();
            excel.WriteToExcel2(ParticipantName, Sequence[SequenceCtr-1].Substring(0,3), Scores);





            string ImgSource = "/Images/" + Sequence[SequenceCtr];
            FunctionImage.Source = new BitmapImage(new Uri(ImgSource, UriKind.Relative));
            SequenceCtr++;
            Function_Name.Text = Labeltest(ImgSource);
            ClearRadioButton();


        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            NextLabel.Foreground = Brushes.LightGray;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
           NextLabel.Foreground = Brushes.Black;
        }

        private string Labeltest(string ImgSource)
        {
            //Tried using switch but apparently cant be used that way :/
            if (ImgSource.Contains("01"))
                return "Fever";
            else if (ImgSource.Contains("02"))
                return "Shortness In Breath";
            else if (ImgSource.Contains("03"))
                return "Cough or Cold";
            else if (ImgSource.Contains("04"))
                return "Cough or Cold";
            else if (ImgSource.Contains("05"))
                return "Wash hands";
            else if (ImgSource.Contains("06"))
                return "Drink and Eat Healthy";
            else if (ImgSource.Contains("07"))
                return "Consult Doctor/ Seek Medical Help";
            else if (ImgSource.Contains("08"))
                return "Avoid People With Flu-Like Symptoms";
            else if (ImgSource.Contains("09"))
                return "Cover when Coughing or Sneezing";
            else if (ImgSource.Contains("10"))
                return "Avoid Contact with Animals";
            else if (ImgSource.Contains("11"))
                return "Get Information from Trusted Sources";
            else if (ImgSource.Contains("12"))
                return "Wear Face Masks";
            else if (ImgSource.Contains("13"))
                return "Avoid Crowded Places Limit Social Gatherings";
            else if (ImgSource.Contains("14"))
                return "Dispose Tissue and Face Masks on Waste Cans";
            else if (ImgSource.Contains("15"))
                return "Use Hand Sanitizers";
            else if (ImgSource.Contains("16"))
                return "Avoid Travelling to Places with Known Cases";
            else if (ImgSource.Contains("17"))
                return "Avoid Touching Your Face";
            else if (ImgSource.Contains("18"))
                return "Wash Clothes Properly";
            else if (ImgSource.Contains("19"))
                return "Decontaminate or Disinfect";
            else if (ImgSource.Contains("20"))
                return "Home Quarantine/ Stay at Home";
            else if (ImgSource.Contains("21"))
                return "Social Distancing";
            else
                return "";


        }

        private void Like_Checked(object sender, RoutedEventArgs e)
        {
            if(Like1.IsChecked==true)
            {
                Scores[0] = 1;
            }
            else if (Like2.IsChecked==true)
            {
                Scores[0] = 2;
            }
            else if (Like3.IsChecked == true)
            {
                Scores[0] = 3;
            }
            else if (Like4.IsChecked == true)
            {
                Scores[0] = 4;
            }
            else if (Like5.IsChecked == true)
            {
                Scores[0] = 5;
            }
            else if (Like6.IsChecked == true)
            {
                Scores[0] = 6;
            }
            else if (Like7.IsChecked == true)
            {
                Scores[0] = 7;
            }







        }

        private void Look_Checked(object sender, RoutedEventArgs e)
        {
            if (Look1.IsChecked == true)
            {
                Scores[1] = 1;
            }
            else if (Look2.IsChecked == true)
            {
                Scores[1] = 2;
            }
            else if (Look3.IsChecked == true)
            {
                Scores[1] = 3;
            }
            else if (Look4.IsChecked == true)
            {
                Scores[1] = 4;
            }
            else if (Look5.IsChecked == true)
            {
                Scores[1] = 5;
            }
            else if (Look6.IsChecked == true)
            {
                Scores[1] = 6;
            }
            else if (Look7.IsChecked == true)
            {
                Scores[1] = 7;
            }
        }

        private void Effect_Checked(object sender, RoutedEventArgs e)
        {
            if (Effect1.IsChecked == true)
            {
                Scores[2] = 1;
            }
            else if (Effect2.IsChecked == true)
            {
                Scores[2] = 2;
            }
            else if (Effect3.IsChecked == true)
            {
                Scores[2] = 3;
            }
            else if (Effect4.IsChecked == true)
            {
                Scores[2] = 4;
            }
            else if (Effect5.IsChecked == true)
            {
                Scores[2] = 5;
            }
            else if (Effect6.IsChecked == true)
            {
                Scores[2] = 6;
            }
            else if (Effect7.IsChecked == true)
            {
                Scores[2] = 7;
            }
        }

        private void Clear_Checked(object sender, RoutedEventArgs e)
        {
            if (Clear1.IsChecked == true)
            {
                Scores[3] = 1;
            }
            else if (Clear2.IsChecked == true)
            {
                Scores[3] = 2;
            }
            else if (Clear3.IsChecked == true)
            {
                Scores[3] = 3;
            }
            else if (Clear4.IsChecked == true)
            {
                Scores[3] = 4;
            }
            else if (Clear5.IsChecked == true)
            {
                Scores[3] = 5;
            }
            else if (Clear6.IsChecked == true)
            {
                Scores[3] = 6;
            }
            else if (Clear7.IsChecked == true)
            {
                Scores[3] = 7;
            }
        }

        private void Strong_Checked(object sender, RoutedEventArgs e)
        {
            if (Strong1.IsChecked == true)
            {
                Scores[4] = 1;
            }
            else if (Strong2.IsChecked == true)
            {
                Scores[4] = 2;
            }
            else if (Strong3.IsChecked == true)
            {
                Scores[4] = 3;
            }
            else if (Strong4.IsChecked == true)
            {
                Scores[4] = 4;
            }
            else if (Strong5.IsChecked == true)
            {
                Scores[4] = 5;
            }
            else if (Strong6.IsChecked == true)
            {
                Scores[4] = 6;
            }
            else if (Strong7.IsChecked == true)
            {
                Scores[4] = 7;
            }
        }

        private void Familiar_Checked(object sender, RoutedEventArgs e)
        {
            if (Familiar1.IsChecked == true)
            {
                Scores[5] = 1;
            }
            else if (Familiar2.IsChecked == true)
            {
                Scores[5] = 2;
            }
            else if (Familiar3.IsChecked == true)
            {
                Scores[5] = 3;
            }
            else if (Familiar4.IsChecked == true)
            {
                Scores[5] = 4;
            }
            else if (Familiar5.IsChecked == true)
            {
                Scores[5] = 5;
            }
            else if (Familiar6.IsChecked == true)
            {
                Scores[5] = 6;
            }
            else if (Familiar7.IsChecked == true)
            {
                Scores[5] = 7;
            }
        }

        private void Complex_Checked(object sender, RoutedEventArgs e)
        {
            if (Complex1.IsChecked == true)
            {
                Scores[6] = 1;
            }
            else if (Complex2.IsChecked == true)
            {
                Scores[6] = 2;
            }
            else if (Complex3.IsChecked == true)
            {
                Scores[6] = 3;
            }
            else if (Complex4.IsChecked == true)
            {
                Scores[6] = 4;
            }
            else if (Complex5.IsChecked == true)
            {
                Scores[6] = 5;
            }
            else if (Complex6.IsChecked == true)
            {
                Scores[6] = 6;
            }
            else if (Complex7.IsChecked == true)
            {
                Scores[6] = 7;
            }
        }

        private void Organize_Checked(object sender, RoutedEventArgs e)
        {
            if (Organize1.IsChecked == true)
            {
                Scores[7] = 1;
            }
            else if (Organize2.IsChecked == true)
            {
                Scores[7] = 2;
            }
            else if (Organize3.IsChecked == true)
            {
                Scores[7] = 3;
            }
            else if (Organize4.IsChecked == true)
            {
                Scores[7] = 4;
            }
            else if (Organize5.IsChecked == true)
            {
                Scores[7] = 5;
            }
            else if (Organize6.IsChecked == true)
            {
                Scores[7] = 6;
            }
            else if (Organize7.IsChecked == true)
            {
                Scores[7] = 7;
            }
        }

        private void Clutter_Checked(object sender, RoutedEventArgs e)
        {
            if (Clutter1.IsChecked == true)
            {
                Scores[8] = 1;
            }
            else if (Clutter2.IsChecked == true)
            {
                Scores[8] = 2;
            }
            else if (Clutter3.IsChecked == true)
            {
                Scores[8] = 3;
            }
            else if (Clutter4.IsChecked == true)
            {
                Scores[8] = 4;
            }
            else if (Clutter5.IsChecked == true)
            {
                Scores[8] = 5;
            }
            else if (Clutter6.IsChecked == true)
            {
                Scores[8] = 6;
            }
            else if (Clutter7.IsChecked == true)
            {
                Scores[8] = 7;
            }
        }

        private void Recognize_Checked(object sender, RoutedEventArgs e)
        {
            if (Recognize1.IsChecked == true)
            {
                Scores[9] = 1;
            }
            else if (Recognize2.IsChecked == true)
            {
                Scores[9] = 2;
            }
            else if (Recognize3.IsChecked == true)
            {
                Scores[9] = 3;
            }
            else if (Recognize4.IsChecked == true)
            {
                Scores[9] = 4;
            }
            else if (Recognize5.IsChecked == true)
            {
                Scores[9] = 5;
            }
            else if (Recognize6.IsChecked == true)
            {
                Scores[9] = 6;
            }
            else if (Recognize7.IsChecked == true)
            {
                Scores[9] = 7;
            }
        }

        private void Abstract_Checked(object sender, RoutedEventArgs e)
        {
            if (Abstract1.IsChecked == true)
            {
                Scores[10] = 1;
            }
            else if (Abstract2.IsChecked == true)
            {
                Scores[10] = 2;
            }
            else if (Abstract3.IsChecked == true)
            {
                Scores[10] = 3;
            }
            else if (Abstract4.IsChecked == true)
            {
                Scores[10] = 4;
            }
            else if (Abstract5.IsChecked == true)
            {
                Scores[10] = 5;
            }
            else if (Abstract6.IsChecked == true)
            {
                Scores[10] = 6;
            }
            else if (Abstract7.IsChecked == true)
            {
                Scores[10] = 7;
            }
        }

        private void Compatible_Checked(object sender, RoutedEventArgs e)
        {
            if (Compatible1.IsChecked == true)
            {
                Scores[11] = 1;
            }
            else if (Compatible2.IsChecked == true)
            {
                Scores[11] = 2;
            }
            else if (Compatible3.IsChecked == true)
            {
                Scores[11] = 3;
            }
            else if (Compatible4.IsChecked == true)
            {
                Scores[11] = 4;
            }
            else if (Compatible5.IsChecked == true)
            {
                Scores[11] = 5;
            }
            else if (Compatible6.IsChecked == true)
            {
                Scores[11] = 6;
            }
            else if (Compatible7.IsChecked == true)
            {
                Scores[11] = 7;
            }
        }

        private void ClearRadioButton()
        {
            Like1.IsChecked = false;
            Like2.IsChecked = false;
            Like3.IsChecked = false;
            Like4.IsChecked = false;
            Like5.IsChecked = false;
            Like6.IsChecked = false;
            Like7.IsChecked = false;
            Look1.IsChecked = false;
            Look2.IsChecked = false;
            Look3.IsChecked = false;
            Look4.IsChecked = false;
            Look5.IsChecked = false;
            Look6.IsChecked = false;
            Look7.IsChecked = false;
            Effect1.IsChecked = false;
            Effect2.IsChecked = false;
            Effect3.IsChecked = false;
            Effect4.IsChecked = false;
            Effect5.IsChecked = false;
            Effect6.IsChecked = false;
            Effect7.IsChecked = false;
            Clear1.IsChecked = false;
            Clear2.IsChecked = false;
            Clear3.IsChecked = false;
            Clear4.IsChecked = false;
            Clear5.IsChecked = false;
            Clear6.IsChecked = false;
            Clear7.IsChecked = false;
            Strong1.IsChecked = false;
            Strong2.IsChecked = false;
            Strong3.IsChecked = false;
            Strong4.IsChecked = false;
            Strong5.IsChecked = false;
            Strong6.IsChecked = false;
            Strong7.IsChecked = false;
            Familiar1.IsChecked = false;
            Familiar2.IsChecked = false;
            Familiar3.IsChecked = false;
            Familiar4.IsChecked = false;
            Familiar5.IsChecked = false;
            Familiar6.IsChecked = false;
            Familiar7.IsChecked = false;
            Complex1.IsChecked = false;
            Complex2.IsChecked = false;
            Complex3.IsChecked = false;
            Complex4.IsChecked = false;
            Complex5.IsChecked = false;
            Complex6.IsChecked = false;
            Complex7.IsChecked = false;
            Organize1.IsChecked = false;
            Organize2.IsChecked = false;
            Organize3.IsChecked = false;
            Organize4.IsChecked = false;
            Organize5.IsChecked = false;
            Organize6.IsChecked = false;
            Organize7.IsChecked = false;
            Clutter1.IsChecked = false;
            Clutter2.IsChecked = false;
            Clutter3.IsChecked = false;
            Clutter4.IsChecked = false;
            Clutter5.IsChecked = false;
            Clutter6.IsChecked = false;
            Clutter7.IsChecked = false;
            Recognize1.IsChecked = false;
            Recognize2.IsChecked = false;
            Recognize3.IsChecked = false;
            Recognize4.IsChecked = false;
            Recognize5.IsChecked = false;
            Recognize6.IsChecked = false;
            Recognize7.IsChecked = false;
            Abstract1.IsChecked = false;
            Abstract2.IsChecked = false;
            Abstract3.IsChecked = false;
            Abstract4.IsChecked = false;
            Abstract5.IsChecked = false;
            Abstract6.IsChecked = false;
            Abstract7.IsChecked = false;
            Compatible1.IsChecked = false;
            Compatible2.IsChecked = false;
            Compatible3.IsChecked = false;
            Compatible4.IsChecked = false;
            Compatible5.IsChecked = false;
            Compatible6.IsChecked = false;
            Compatible7.IsChecked = false;





        }
          

    }
}

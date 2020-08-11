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

namespace MatchingTestExperiment
{
    /// <summary>
    /// Interaction logic for PreferenceTestExperiment.xaml
    /// </summary>
    public partial class PreferenceTestExperiment : Window
    {
        public string ParticipantName ="Matthew Paladine Rivera";
        //public string[] Sequence = new string[105];
        public  int SequenceCtr = 0;
        public string[] Sequence = { "/Images/A01.jpg", "/Images/D21.jpg" , "/Images/C17.jpg", "/Images/B09.jpg", "/Images/E15.jpg" };
        public int Like=0, Look = 0, Effective = 0, Clarity = 0, Strength = 0, Familiar = 0, Complex = 0, Organize = 0, Clutter = 0, Recognize = 0, Abstract = 0, Compatible = 0;




        public PreferenceTestExperiment()//Declare Sequence here
        {
            InitializeComponent();
            FunctionImage.Source = new BitmapImage(new Uri(Sequence[SequenceCtr], UriKind.Relative));
            SequenceCtr++;
            string ImgSource = Sequence[SequenceCtr];

            Function_Name.Text = Labeltest(ImgSource);


        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SequenceCtr > 4)
                SequenceCtr = 0;


            FunctionImage.Source = new BitmapImage(new Uri(Sequence[SequenceCtr], UriKind.Relative));
            string ImgSource = Sequence[SequenceCtr];
            SequenceCtr++;
            Function_Name.Text = Labeltest(ImgSource);



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





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf.Exporting.XPS.Schema;
using Spire.Xls;

namespace Yumi_Thesis
{
    class ExcelIntegration
    {
        Workbook workbook = new Workbook();
        public void CreateExcel()
        {
            
            

            try
            {
                workbook.LoadFromFile("Experiment Test Results.xls");
            }
            catch
            {
                Workbook workbook2 = new Workbook();
                Worksheet sheet2 = workbook2.Worksheets[0];
                sheet2.Name = "Matching Test Results";
                sheet2.Range["A1"].Text = "Participant (First & Last Name)";
                sheet2.Range["B1"].Text = "Sequence";
                sheet2.Range["C1"].Text = "Accuracy(1/0)";
                sheet2.Range["D1"].Text = "Matching Time(in secs)";
                sheet2.Range["E1"].Text = "Final Answer";
                sheet2.Range["F1"].Text = "First Answer";
                sheet2.Range["G1"].Text = "Confusion 1";
                sheet2.Range["H1"].Text = "Confusion 2";
                sheet2.Range["I1"].Text = "Confusion 3";
                sheet2.Range["J1"].Text = "Confusion 4";
                sheet2.Range["K1"].Text = "Confusion 5";
               

                Worksheet sheet = workbook2.Worksheets[2];
                sheet.Name = "Masterlist";
                sheet.Range["A1"].Text = "Participant (First & Last Name)";
                sheet.Range["B1"].Text = "Sequence";
                sheet.Range["C1"].Text = "Accuracy(1/0)";
                sheet.Range["D1"].Text = "Matching Time(in secs)";
                sheet.Range["E1"].Text = "Final Answer";
                sheet.Range["F1"].Text = "First Answer";
                sheet.Range["G1"].Text = "Confusion 1";
                sheet.Range["H1"].Text = "Confusion 2";
                sheet.Range["I1"].Text = "Confusion 3";
                sheet.Range["J1"].Text = "Confusion 4";
                sheet.Range["K1"].Text = "Confusion 5";
                workbook2.SaveToFile("Experiment Test Results.xls");
                workbook.LoadFromFile("Experiment Test Results.xls");
                return;
            }
        }

        public void CreatePart2()
        {
            workbook.LoadFromFile("Experiment Test Results.xls");
            Worksheet sheet2 = workbook.Worksheets[1];
            sheet2.Name = "Preference Test Results";
            sheet2.Range["A1"].Text = "Participant (First & Last Name)";
            sheet2.Range["B1"].Text = "Sequence";
            sheet2.Range["C1"].Text = "Unlikeable-Likeable";
            sheet2.Range["D1"].Text = "Ugly-Beautiful";
            sheet2.Range["E1"].Text = "Ineffective-Effective";
            sheet2.Range["F1"].Text = "Vague-Clear";
            sheet2.Range["G1"].Text = "Weak-Strong";
            sheet2.Range["H1"].Text = "Unfamiliar-Familiar";
            sheet2.Range["I1"].Text = "Complex-Simple";
            sheet2.Range["J1"].Text = "Disorganized-Organized";
            sheet2.Range["K1"].Text = "Cluttered-Uncluttered";
            sheet2.Range["L1"].Text = "Unrecognizable-Recognizable";
            sheet2.Range["M1"].Text = "Abstract-Concrete";
            sheet2.Range["N1"].Text = "Incompatible-Compatible";

            sheet2 = workbook.Worksheets[2];
            sheet2.Range["L1"].Text = "Unlikeable-Likeable";
            sheet2.Range["M1"].Text = "Ugly-Beautiful";
            sheet2.Range["N1"].Text = "Ineffective-Effective";
            sheet2.Range["O1"].Text = "Vague-Clear";
            sheet2.Range["P1"].Text = "Weak-Strong";
            sheet2.Range["Q1"].Text = "Unfamiliar-Familiar";
            sheet2.Range["R1"].Text = "Complex-Simple";
            sheet2.Range["S1"].Text = "Disorganized-Organized";
            sheet2.Range["T1"].Text = "Cluttered-Uncluttered";
            sheet2.Range["U1"].Text = "Unrecognizable-Recognizable";
            sheet2.Range["V1"].Text = "Abstract-Concrete";
            sheet2.Range["W1"].Text = "Incompatible-Compatible";
            workbook.SaveToFile("Experiment Test Results.xls");


        }

        public void WriteToExcel2(string ParticipantName, string Sequence, int [] Scores)
        {
            Workbook wb = new Workbook();
            wb.LoadFromFile("Experiment Test Results.xls");
            Worksheet sheet = wb.Worksheets[1];
            int lastFilledRow = 0;

            for (int i = sheet.LastRow; i >= 0; i--)
            {
                CellRange cr = sheet.Rows[i - 1].Columns[0];
                if (!cr.IsBlank)
                {
                    lastFilledRow = i + 1;
                    break;
                }
            }

            sheet.Range["A" + lastFilledRow.ToString()].Text = ParticipantName;
            sheet.Range["B" + lastFilledRow.ToString()].Text = Sequence;
            sheet.Range["C" + lastFilledRow.ToString()].NumberValue = Scores[0];
            sheet.Range["D" + lastFilledRow.ToString()].NumberValue = Scores[1];
            sheet.Range["E" + lastFilledRow.ToString()].NumberValue = Scores[2];
            sheet.Range["F" + lastFilledRow.ToString()].NumberValue = Scores[3];
            sheet.Range["G" + lastFilledRow.ToString()].NumberValue = Scores[4];
            sheet.Range["H" + lastFilledRow.ToString()].NumberValue = Scores[5];
            sheet.Range["I" + lastFilledRow.ToString()].NumberValue = Scores[6];
            sheet.Range["J" + lastFilledRow.ToString()].NumberValue = Scores[7];
            sheet.Range["K" + lastFilledRow.ToString()].NumberValue = Scores[8];
            sheet.Range["L" + lastFilledRow.ToString()].NumberValue = Scores[9];
            sheet.Range["M" + lastFilledRow.ToString()].NumberValue = Scores[10];
            sheet.Range["N" + lastFilledRow.ToString()].NumberValue = Scores[11];

            sheet = wb.Worksheets[2];
            sheet.Range["L" + lastFilledRow.ToString()].NumberValue = Scores[0];
            sheet.Range["M" + lastFilledRow.ToString()].NumberValue = Scores[1];
            sheet.Range["N" + lastFilledRow.ToString()].NumberValue = Scores[2];
            sheet.Range["O" + lastFilledRow.ToString()].NumberValue = Scores[3];
            sheet.Range["P" + lastFilledRow.ToString()].NumberValue = Scores[4];
            sheet.Range["Q" + lastFilledRow.ToString()].NumberValue = Scores[5];
            sheet.Range["R" + lastFilledRow.ToString()].NumberValue = Scores[6];
            sheet.Range["S" + lastFilledRow.ToString()].NumberValue = Scores[7];
            sheet.Range["T" + lastFilledRow.ToString()].NumberValue = Scores[8];
            sheet.Range["U" + lastFilledRow.ToString()].NumberValue = Scores[9];
            sheet.Range["V" + lastFilledRow.ToString()].NumberValue = Scores[10];
            sheet.Range["W" + lastFilledRow.ToString()].NumberValue = Scores[11];


            wb.SaveToFile("Experiment Test Results.xls");



        }




        public List<string> LoadfromExcel(string ParticipantName)
        {
            List<string> SeqenceCompleted = new List<string>();

            int lastFilledRow = 0;


            Worksheet sheet = workbook.Worksheets[0];
            for (int i = sheet.LastRow; i >= 0; i--)
            {
                CellRange cr = sheet.Rows[i - 1].Columns[0];
                if (!cr.IsBlank)
                {
                    lastFilledRow = i + 1 ;
                    break;
                }
            }

            for(int i = 2; i<lastFilledRow; i++)
            {
               
                 if (sheet.Range["A" + i.ToString()].Text==ParticipantName)
                {
                   SeqenceCompleted.Add(sheet.Range["B" + i].Text+".jpg");
                }
                else if(sheet.Range["A" + i.ToString()].Text != ParticipantName)
                {
                    SeqenceCompleted.Add("");
                }
            }


            return SeqenceCompleted;





        }

        public List<string> LoadfromExcel2(string ParticipantName)
        {
            List<string> SeqenceCompleted = new List<string>();
            int lastFilledRow = 0;

            Worksheet sheet = workbook.Worksheets[1];
            for (int i = sheet.LastRow; i >= 0; i--)
            {
                CellRange cr = sheet.Rows[i - 1].Columns[0];
                if (!cr.IsBlank)
                {
                    lastFilledRow = i + 1;
                    break;
                }
            }

            for (int i = 2; i < lastFilledRow; i++)
            {
                 if (sheet.Range["A" + i.ToString()].Text == ParticipantName)
                {
                    SeqenceCompleted.Add(sheet.Range["B" + i].Text + ".jpg");
                }
                else if (sheet.Range["A" + i.ToString()].Text != ParticipantName)
                {
                    SeqenceCompleted.Add("");
                }
            }



            return SeqenceCompleted;




        }

        public void WriteToExcel(string ParticipantName,string CurrentSequence, string Accuracy,string MatchingTime, string [] Answers)
        {

            Workbook wb = new Workbook();
            wb.LoadFromFile("Experiment Test Results.xls");
            Worksheet sheet = wb.Worksheets[0];
            int lastFilledRow = 0;

            for (int i = sheet.LastRow; i >= 0; i--)
            {
                CellRange cr = sheet.Rows[i - 1].Columns[0];
                if (!cr.IsBlank)
                {
                    lastFilledRow = i + 1;
                    break;
                }
            }

            int ctr = 0;
            //to find the last filled row of this column

            sheet.Range["A" + lastFilledRow.ToString()].Text = ParticipantName;
            sheet.Range["B" + lastFilledRow.ToString()].Text = CurrentSequence;
            sheet.Range["C" + lastFilledRow.ToString()].Text = Accuracy;
            sheet.Range["D" + lastFilledRow.ToString()].Text = MatchingTime;

            foreach (string i in Answers)
            {
                if (i == "")
                {
                    sheet.Range["E" + lastFilledRow.ToString()].Text = Answers[ctr - 1];
                    break;
                }
                else if (ctr > 6)
                {
                    sheet.Range["E" + lastFilledRow.ToString()].Text = Answers[6];
                    break;
                }
                ctr++;
            }

            sheet.Range["F" + lastFilledRow.ToString()].Text = Answers[0];
            sheet.Range["G" + lastFilledRow.ToString()].Text = Answers[1];
            sheet.Range["H" + lastFilledRow.ToString()].Text = Answers[2];
            sheet.Range["I" + lastFilledRow.ToString()].Text = Answers[3];
            sheet.Range["J" + lastFilledRow.ToString()].Text = Answers[4];
            sheet.Range["K" + lastFilledRow.ToString()].Text = Answers[5];



            sheet = wb.Worksheets[2];
            ctr = 0;

            sheet.Range["A" + lastFilledRow.ToString()].Text = ParticipantName;
            sheet.Range["B" + lastFilledRow.ToString()].Text = CurrentSequence;
            sheet.Range["C" + lastFilledRow.ToString()].Text = Accuracy;
            sheet.Range["D" + lastFilledRow.ToString()].Text = MatchingTime;

            foreach (string i in Answers)
            {
                if (i == "")
                {
                    sheet.Range["E" + lastFilledRow.ToString()].Text = Answers[ctr - 1];
                    break;
                }
                else if (ctr > 6)
                {
                    sheet.Range["E" + lastFilledRow.ToString()].Text = Answers[6];
                    break;
                }

                ctr++;
            }

            sheet.Range["F" + lastFilledRow.ToString()].Text = Answers[0];
            sheet.Range["G" + lastFilledRow.ToString()].Text = Answers[1];
            sheet.Range["H" + lastFilledRow.ToString()].Text = Answers[2];
            sheet.Range["I" + lastFilledRow.ToString()].Text = Answers[3];
            sheet.Range["J" + lastFilledRow.ToString()].Text = Answers[4];
            sheet.Range["K" + lastFilledRow.ToString()].Text = Answers[5];








            wb.SaveToFile("Experiment Test Results.xls");







        }













    }
}

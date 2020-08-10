using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Xls;

namespace Yumi_Thesis
{
    class ExcelIntegration
    {
        public void CreateExcel()
        {
            Workbook workbook = new Workbook();
            

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
                return;
            }
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

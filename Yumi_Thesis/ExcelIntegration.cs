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
            Worksheet sheet = workbook.Worksheets[0];

            try
            {
                workbook.LoadFromFile("Test results.xls");
            }
            catch
            {
                Workbook workbook2 = new Workbook();
                Worksheet sheet2 = workbook2.Worksheets[0];
                sheet2.Name = "Matching Test Results";
                sheet2.Range["A1"].Text = "Participant";
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
                workbook2.SaveToFile("Test results.xls");
                return;
            }
        }

        public void WriteToExcel(string ParticipantName,string CurrentSequence, string Accuracy,string MatchingTime,string FinalAnswer, string FirstAnswer,string [] Answers)
        {

            Workbook wb = new Workbook();
            wb.LoadFromFile("Test results.xls");
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
            //to find the last filled row of this column



            sheet.Range["A" + lastFilledRow.ToString()].Text = "";
            wb.SaveToFile("Test results.xls");







        }













    }
}

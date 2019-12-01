using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Microsoft.Office.Core;
using Microsoft.CSharp;
using Excel = Microsoft.Office.Interop.Excel;

namespace 排赛程
{
    static class Arrange
    {
        static public List<string> readName(string input)
        {
            List<string> nameList = new List<string>();
            string str = "";
            foreach (char c in input)
            {
                if (c != '\n' && c != '\t' && c != '\r')
                {
                    str += c;
                }
                else if (str.Length > 0) 
                {
                    nameList.Add(str);
                    str = "";
                }
            }
            if(str.Length > 0)
            {
                nameList.Add(str);
            }
            return nameList;
        }

        static public List<List<string>> arrangeGroup(List<string> seed, List<string> notSeed, int groupNumber)
        {
            List<List<string>> result = new List<List<string>>();
            for(int i = 0; i < groupNumber; i++)
            {
                result.Add(new List<string>());
            }
            Random random = new Random(DateTime.Now.Millisecond);
            int n, seedNumPerGroup = seed.Count / groupNumber + (seed.Count % groupNumber > 0 ? 1 : 0), totalPerGroup = (seed.Count + notSeed.Count) / groupNumber + ((seed.Count + notSeed.Count) % groupNumber > 0 ? 1 : 0);
            List<int> arrangedSeed = new List<int>(groupNumber);
            foreach (string seedPlayer in seed)
            {
                while (result[(n = random.Next(0, groupNumber))].Count >= seedNumPerGroup) ;
                result[n].Add(seedPlayer);
            }
            int index, firstCycleLimit = (seed.Count + notSeed.Count) / groupNumber * groupNumber - seed.Count;
            for (index = 0; index < firstCycleLimit; index++)
            {
                while (result[(n = random.Next(0, groupNumber))].Count >= (seed.Count + notSeed.Count) / groupNumber) ;
                result[n].Add(notSeed[index]);
            }  //  拆成2个循环是为了在不能保证每组人数相同的时候，不会出现有一些组少2人的情况
            for(; index < notSeed.Count; index++)
            {
                while (result[(n = random.Next(0, groupNumber))].Count >= totalPerGroup) ;
                result[n].Add(notSeed[index]);
            }
            for(int i = 0; i < result.Count; i++)
            {
                while(result[i].Count < totalPerGroup)
                {
                    result[i].Add("NULL");
                }
            }
            return result;
        }

        static public void writeGroupExcel(string path, List<List<string>> groups, int blockPerRow = 2)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = workbook.ActiveSheet as Excel.Worksheet;
            worksheet.Cells.WrapText = true;
            /*输出*/
            int col = 1, row = 1;
            for(int i = 0; i < groups.Count; i++)
            {
                if(i > 0 && i % blockPerRow == 0)
                {
                    row += groups[0].Count + 2;
                    col = 1;
                }
                else if(i % blockPerRow > 0)
                {
                    col += groups[i].Count + 5;
                }
                worksheet.Cells[col][row] = "Group " + (groups.Count <= 16 ? Convert.ToString((char)(i + 'A')) : Convert.ToString(i + 1));
                Excel.Range groupNameBlock = worksheet.Range[worksheet.Cells[col][row], worksheet.Cells[col + 1][row]];
                groupNameBlock.MergeCells = true;
                groupNameBlock.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                int right, down;
                for (right = 1; right <= groups[i].Count; right++)
                {
                    worksheet.Cells[col + right + 1][row] = "=CHAR(32)&CHAR(32)&" + Convert.ToString(right);
                }
                worksheet.Cells[col + (right++) + 1][row] = "积分";
                worksheet.Cells[col + (right++) + 1][row] = "名次";
                worksheet.Cells[col + right + 1][row].ColumnWidth = 3;
                for (down = 1; down <= groups[i].Count; down++)
                {
                    worksheet.Cells[col][row + down] = "=CHAR(32)&CHAR(32)&" + Convert.ToString(down);
                    worksheet.Cells[col + 1][row + down] = groups[i][down - 1];
                }
                Excel.Range border = worksheet.Range[worksheet.Cells[col][row], worksheet.Cells[col + right][row + down - 1]];
                  //  加粗边线
                border.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                border.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                for(int change = 0; change < groups[i].Count; change++)  //  画斜线
                {
                    worksheet.Cells[col + 2 + change][row + 1 + change].Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlContinuous;
                    worksheet.Cells[col + 2 + change][row + 1 + change].Borders[Excel.XlBordersIndex.xlDiagonalDown].Weight = Excel.XlBorderWeight.xlMedium;
                }
            }
            worksheet.Cells.EntireColumn.AutoFit();
            /*输出完成*/
            workbook.SaveAs(path, Convert.ToDouble(application.Version) < 12 ? -4143 : 56);
            workbook.Close(false, Type.Missing, Type.Missing);
            workbook = null;
            application.Quit();
            GC.Collect();
        }
        static private List<List<string>> versusBlocks(List<List<string>> groups)
        {
            List<List<string>> result = new List<List<string>>(groups.Count);
            for(int i = 0; i < groups.Count; i++)
            {
                result.Add(new List<string>());
                if(groups.Count <= 16)
                {
                    result[i].Add("Group " + (char)(i + 'A'));
                }
                else
                {
                    result[i].Add("Group " + Convert.ToString(i + 1));
                }
                for(int j = 0; j < groups[i].Count; j++)
                {
                    for(int k = j + 1; k < groups[i].Count; k++)
                    {
                        if(groups[i][j] != "NULL" && groups[i][k] != "NULL")
                        {
                            result[i].Add("=\"" + groups[i][j] + "\"&CHAR(10)&\"vs\"&CHAR(10)&\"" + groups[i][k] + "\"");
                        }
                    }
                }
                while(result[i].Count < groups[i].Count * (groups[i].Count - 1) / 2)
                {
                    result[i].Add("");
                }
            }
            return result;
        }

        static public void writeVersusExcel(string path, List<List<string>> groups, int width = 8)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = workbook.ActiveSheet as Excel.Worksheet;
            worksheet.Cells.WrapText = true;
            /*输出*/
            List<List<string>> blocks = versusBlocks(groups);
            int groupNameIndex = 1;
            for (int i = 1; i <= blocks.Count; i++)
            {
                if(i > 1 && i % 8 == 1)
                {
                    groupNameIndex += blocks[i - 1].Count + 1;
                }
                worksheet.Cells[(i - 1) % width + 1][groupNameIndex] = blocks[i - 1][0];
                for (int j = 1; j <= blocks[i - 1].Count - 1; j++)
                {
                    worksheet.Cells[(i - 1) % width + 1][groupNameIndex + j] = blocks[i - 1][j];
                }
            }
            worksheet.Cells.EntireColumn.AutoFit();
            /*输出完成*/
            workbook.SaveAs(path, Convert.ToDouble(application.Version) < 12 ? -4143 : 56);
            workbook.Close(false, Type.Missing, Type.Missing);
            workbook = null;
            application.Quit();
            GC.Collect();
        }

        static public List<string> notSeed;
        static public List<string> seed;
    }
}

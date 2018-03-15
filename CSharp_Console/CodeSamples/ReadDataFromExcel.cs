using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel; // Need to add Microsoft.Office.Interop.Excel in refernces

namespace CSharp_Console.CodeSamples
{
    /* Made by Jesper Ahasverusen Kielsgaard
     * Date: 14-03-2018
     * 
     * A quick way to show how to read data from a excel file and how to easy put it in custom made list
     */

    // source code link - https://coderwall.com/p/app3ya/read-excel-file-in-c

    public class ReadDataFromExcel
    {
        public void ReadData()
        {
            // Setting the excel application to call it
            Excel.Application xlApp = new Excel.Application();

            // Which excel the code shell read
            Excel.Workbook xlWb = xlApp.Workbooks.Open(@"C:\Users\kiels00j\Desktop\test.xlsx");

            // Which sheets the code shall read from (in excel 1 is the first one and not 0 as in coding)
            Excel._Worksheet xlWs = xlWb.Sheets[1];

            // Getting all the data contain in the predefine setting above
            Excel.Range xlR = xlWs.UsedRange;

            // Getting how many Rows and Cloumns the excel file contain to the for loop
            int rowCount = xlR.Rows.Count;
            int colCount = xlR.Columns.Count;

            // Making a list to contain all the data from the excel file
            List<Data_Used_list> dul = new List<Data_Used_list>();

            // Going / loop through every row there is, if there is headers or the data is 
            // not starting on line 1 set it to the line nr where it is
            for (int i = 1; i <= rowCount; i++)
            {
                // Use this if just want to read every single colums and combine them in string row
                //for (int j = 1; j <= colCount; j++)
                //{
                //    Console.Write(xlR.Cells[i, j].Value2.ToString() + "\t");
                //}
                //Console.WriteLine();


                // Here I add data to the list and know which space the headers are in 
                // notice that it start with 1 and not 0, this is because in excel 1 is the first and not
                // 0 as in coding
                dul.Add(new Data_Used_list
                {
                    Phone_nr = Convert.ToString(xlR.Cells[i, 1].Value2),
                    Abo = Convert.ToString(xlR.Cells[i, 2].Value2),
                    GID = Convert.ToString(xlR.Cells[i, 3].Value2),
                    DataUsed = Convert.ToString(xlR.Cells[i, 4].Value2)
                });
            }

            // This is only to confirm and write out the list that 
            foreach (Data_Used_list item in dul)
            {
                Console.WriteLine("Nr: " + item.Phone_nr + " - GID: " + item.GID + " - Data: " + item.DataUsed);
            }

            // Closing down the use off the excel file so the code/software do not lock it
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlR);
            Marshal.ReleaseComObject(xlWs);
            xlWb.Close();
            Marshal.ReleaseComObject(xlWb);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }

    // This is made out from the colums header in the excel file so when reading the file it easyer to make a list
    // with the data and easyer to work with after
    public class Data_Used_list 
    {
        public string Phone_nr;
        public string Abo;
        public string GID;
        public string DataUsed;
    }
}


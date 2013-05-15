using System;
using System.Collections.Generic;
using System.Linq;
using ForwarderDAL.Entity;
using Microsoft.Office.Interop.Excel;


namespace Forwarder.Helper
{
    public class ExcelImporter 
    {
        public List<Shipment> Import(string fileName)
        {
            Application objExcel = new Application();
            //Открываем книгу.                                                                                                                                                        
            Workbook objWorkBook = objExcel.Workbooks.Open(fileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Выбираем таблицу(лист).
            Worksheet objWorkSheet = (Worksheet)objWorkBook.Sheets[1];

            int startRowIndex = 2;
            List<String> excelString = new List<string>();
            List<Shipment> shipments = new List<Shipment>();
            bool isEmptyRow;
            do
            {
                for (int i = 0; i < 7; i++)
                {
                    string column = ((char)(65 + i)).ToString();
                    Range rg = objWorkSheet.Range[column + startRowIndex, column + startRowIndex];
                    excelString.Add(rg.Text.ToString());
                }

                isEmptyRow = excelString.All(string.IsNullOrEmpty);

                if (!isEmptyRow)
                {
                    Shipment shipment = new Shipment
                    {
                        WagonNumber = excelString[1],
                        BillNumber = excelString[2],
                        Weight = !string.IsNullOrEmpty(excelString[3]) ? Int32.Parse(excelString[3]) : 0,
                        Capacity = !string.IsNullOrEmpty(excelString[4]) ? Int32.Parse(excelString[4]) : 0,
                        Date = !string.IsNullOrEmpty(excelString[6]) ? DateTime.Parse(excelString[6]) : DateTime.Now,
                        ArrivalDate = !string.IsNullOrEmpty(excelString[6]) ? (DateTime?)DateTime.Parse(excelString[6]) : null,
                    };

                    shipments.Add(shipment);
                    startRowIndex++;
                    excelString.Clear();
                }
            } while (!isEmptyRow);

            objExcel.Quit();

            return shipments;
        }
    }
}

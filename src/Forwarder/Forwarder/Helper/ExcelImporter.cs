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
            Application ObjExcel = new Application();
            //Открываем книгу.                                                                                                                                                        
            Workbook ObjWorkBook = ObjExcel.Workbooks.Open(fileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Выбираем таблицу(лист).
            Worksheet ObjWorkSheet = (Worksheet)ObjWorkBook.Sheets[1];
            Range rg = null;

            Int32 row = 2;
            List<String> ExcelString = new List<string>();
            List<Shipment> shipments = new List<Shipment>();
            while (row < 10)
            {
                for (int i = 0; i < 7; i++)
                {
                    string Column = ((char)(65 + i)).ToString();
                    rg = ObjWorkSheet.get_Range(Column + row, Column + row);
                    ExcelString.Add(rg.Text.ToString());
                }

                Shipment shipment = new Shipment
                {
                    WagonNumber = ExcelString[1],
                    BillNumber = ExcelString[2],
                    Weight = !string.IsNullOrEmpty(ExcelString[3]) ? Int32.Parse(ExcelString[3]) : 0,
                    Capacity = !string.IsNullOrEmpty(ExcelString[4]) ? Int32.Parse(ExcelString[4]) : 0,
                    Date = !string.IsNullOrEmpty(ExcelString[6]) ? DateTime.Parse(ExcelString[6]) : DateTime.Now,
                    ArrivalDate = !string.IsNullOrEmpty(ExcelString[6]) ? (DateTime?)DateTime.Parse(ExcelString[6]) : null,
                };
                shipments.Add(shipment);
                row++;
                ExcelString.Clear();
            }

            ObjExcel.Quit();

            return shipments;
        }

    }
}

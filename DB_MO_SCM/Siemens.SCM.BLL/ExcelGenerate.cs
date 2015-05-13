using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using System.Threading.Tasks;

namespace Siemens.SCM.BLL
{
    public class ExcelGenerate
    {
        public static byte[] GenerateExcel(string TempFilePath)
        {
            byte[] excelFile = null;

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(12, 20, 1, 7)
            //for (int i = 0; i < 10; i++)
            //{
            //    IRow row = sheet1.CreateRow(i);
            //    for (int j = 0; j < 10; j++)
            //    {
            //        ICell cell = row.CreateCell(j);
            //        cell.SetCellValue(i * 10 + j);
            //    }

            //}
            Parallel.Invoke(
                () => {
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(12, 20, 1, 7));
                },
                () => {
                    Parallel.For(0, 10, i =>
                    {
                        IRow row = sheet1.CreateRow(i);
                        for (int j = 0; j < 10; j++)
                        {
                            ICell cell = row.CreateCell(j);
                            cell.SetCellValue(i * 10 + j);
                        }
                    });
                });
            
            FileStream file = new FileStream(TempFilePath, FileMode.Create);
            workbook.Write(file);
            file.Close();
            file = new FileStream(TempFilePath, FileMode.Open, FileAccess.Read);
            excelFile = new byte[file.Length];
            file.Read(excelFile, 0, excelFile.Length);
            file.Close();
            Task.Factory.StartNew(() => { System.IO.File.Delete(TempFilePath); });

            return excelFile;
        }

    }
}

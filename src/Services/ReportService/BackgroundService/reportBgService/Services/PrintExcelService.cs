using ClosedXML.Excel;
using reportBgService.Models.Response;

namespace reportBgService.Services
{
    public static class PrintExcelService
    {
        public static async Task<PrintResponse> Print(ReportResponse response, string reportId)
        {
            try
            {
                var fileName = DateTime.Now.ToString("ddMMyyyhhmmssMs");
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Report");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "Fullname";
                    worksheet.Cell(currentRow, 2).Value = "Company";
                    worksheet.Cell(currentRow, 3).Value = "Created Date";
                    foreach (var user in response.ListPersonQueryResponse)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = user.FullName;
                        worksheet.Cell(currentRow, 2).Value = user.Company;
                        worksheet.Cell(currentRow, 3).Value = user.CreatedDate.ToString("dd.MM.yyyy");
                    }
                    workbook.SaveAs($"Content/{fileName}.xlsx");
                }
                return new PrintResponse { IsSuccess = true, FilePath= $"Content/{fileName}.xlsx" };
            }
            catch (Exception)
            {
                return new PrintResponse { IsSuccess = false };
            }
            
        }
    }
}

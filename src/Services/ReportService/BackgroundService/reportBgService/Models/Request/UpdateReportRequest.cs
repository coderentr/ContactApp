using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reportBgService.Models.Request
{
    public class UpdateReportRequest
    {
        public string ReportId { get; set; }  
        public string FilePath { get; set; }
    }
}

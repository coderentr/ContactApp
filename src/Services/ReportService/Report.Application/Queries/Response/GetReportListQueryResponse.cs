using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Queries.Response
{
    public class GetReportListQueryResponse
    {
        public List<GetReportQueryResponse> ReportList { get; set; }
    }
}

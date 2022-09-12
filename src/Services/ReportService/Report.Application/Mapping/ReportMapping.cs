using Report.Application.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Mapping
{
    public static class ReportMapping
    {
        public static GetReportQueryResponse ToDTO(this Report.Domain.ReportAggregate.Report report)
        {
            return new GetReportQueryResponse
            {
                Id=report.Id.ToString(),
                Date = report.Date,
                FilePath = report.FilePath,
                Location = report.Location,
                PersonCount = report.PersonCount,
                Status = report.Status
            };
        }
    }
}

using MediatR;
using Report.Application.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Queries.Request
{
    public class GetReportQueryRequest:IRequest<GetReportQueryResponse>
    {
        public string ReportId { get; set; }
    }
}

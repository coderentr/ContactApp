using MediatR;
using Report.Application.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Commands.Request
{
    public class UpdateReportCommandRequest:IRequest<UpdateReportCommandResponse>
    {
        public string ReportId { get; set; }
        public string FilePath { get; set; }
    }
}

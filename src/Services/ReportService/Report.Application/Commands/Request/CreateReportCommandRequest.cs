using MediatR;
using Report.Application.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Commands.Request
{
    public class CreateReportCommandRequest:IRequest<CreateReportCommandResponse>
    {
        public string Location { get; set; }
    }
}

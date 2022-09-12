using MediatR;
using Report.Application.Mapping;
using Report.Application.Queries.Request;
using Report.Application.Queries.Response;
using Report.Domain.ReportAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Handlers.QueryHandlers
{
    public class GetReportQueryHandler : IRequestHandler<GetReportQueryRequest, GetReportQueryResponse>
    {
        private readonly IReportRepository _reportRepository;
        public GetReportQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<GetReportQueryResponse> Handle(GetReportQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var report = _reportRepository.Get(request.ReportId);
               return report.ToDTO();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

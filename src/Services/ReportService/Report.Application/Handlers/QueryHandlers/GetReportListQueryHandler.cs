using MassTransit;
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
    public class GetReportListQueryHandler : IRequestHandler<GetReportListQueryRequest, GetReportListQueryResponse>
    {
        private readonly IReportRepository _reportRepository;
        public GetReportListQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<GetReportListQueryResponse> Handle(GetReportListQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new GetReportListQueryResponse();
                List<GetReportQueryResponse> reportList = new List<GetReportQueryResponse>();
                var reports = _reportRepository.Get().ToList();
                foreach (var report in reports)
                {
                    try
                    {
                    reportList.Add(report.ToDTO());
                    }
                    catch{ }
                }
                result.ReportList = reportList;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

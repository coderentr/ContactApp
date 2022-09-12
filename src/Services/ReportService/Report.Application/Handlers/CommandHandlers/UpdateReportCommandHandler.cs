using MediatR;
using Report.Application.Commands.Request;
using Report.Application.Commands.Response;
using Report.Domain.ReportAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Handlers.CommandHandlers
{
    public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommandRequest, UpdateReportCommandResponse>
    {
        IReportRepository _reportRepository;
        public UpdateReportCommandHandler(IReportRepository reportRepository)
        {
            _reportRepository=reportRepository;
        }
        public async Task<UpdateReportCommandResponse> Handle(UpdateReportCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var report = _reportRepository.Get(request.ReportId);
                if (report != null)
                {
                    report.Status = Shared.Enums.ReportStatus.Done;
                    report.FilePath = request.FilePath;
                    _reportRepository.Update(report);
                }
                return  new UpdateReportCommandResponse
                {
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new UpdateReportCommandResponse { Message = ex.Message, IsSuccess = false };
            }
            
        }
    }
}

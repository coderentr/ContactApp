using MassTransit;
using MediatR;
using Report.Application.Commands.Request;
using Report.Application.Commands.Response;
using Report.Domain.ReportAggregate;
using Report.Infrastructure.rabbitmq;
using Report.Shared.Enums;
using Report.Shared.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Handlers.CommandHandlers
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommandRequest, CreateReportCommandResponse>
    {
        IReportRepository _reportRepository;
        private readonly IBus _bus;

        public CreateReportCommandHandler(IReportRepository reportRepository, IBus bus)
        {
            _reportRepository = reportRepository;
            _bus = bus;
        }
        public async Task<CreateReportCommandResponse> Handle(CreateReportCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Domain.ReportAggregate.Report report = new Domain.ReportAggregate.Report
                {
                    Status=ReportStatus.Preparing,
                    Location=request.Location,
                };
                await  _reportRepository.Create(report);
                var reportMessage = new ReportMessage { ReportId = report.Id.ToString(), Location = request.Location };

                var endPoint = await _bus.GetSendEndpoint(new Uri($"queue:{RabbitMQConstants.reportServiceQueueName}"));

                await endPoint.Send<ReportMessage>(reportMessage);
                return new CreateReportCommandResponse { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new CreateReportCommandResponse { IsSuccess = true, Message=ex.Message };
            }
        }
    }
}

using Contact.Application.Mapping;
using Contact.Application.Queries.Request;
using Contact.Application.Queries.Response;
using Contact.Domain.PersonAggregate;
using Contact.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Handlers.QueryHandlers
{
    public class GetPersonReportQueryHandle : IRequestHandler<GetPersonReportQueryRequest, GetPersonReportQueryResponse>
    {
        IPersonRepository _personRepository;
        public GetPersonReportQueryHandle(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<GetPersonReportQueryResponse> Handle(GetPersonReportQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                GetPersonReportQueryResponse result = new GetPersonReportQueryResponse();
                List<ListPersonQueryResponse> listPersonQueryResponse = new List<ListPersonQueryResponse>();
                List<Person> reports = _personRepository.Get()
                    .Where(_ => _.ContactInfo != null && _.ContactInfo.Any() &&
                    _.ContactInfo.All(ci => ci.ContactContent.Contains(request.Location))).ToList();
                foreach (var report in reports)
                {
                    ListPersonQueryResponse item =new ListPersonQueryResponse
                    {
                        Company = report.Company,
                        ContactInfo = report.ContactInfo.ToDto(),
                        FullName = $"{report.Name} {report.Surname}",
                        Id = report.Id.ToString(),
                        CreatedDate=report.CreatedDate
                    };
                    listPersonQueryResponse.Add(item);
                }
                result.ListPersonQueryResponse = listPersonQueryResponse;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
         
        }
    }
}

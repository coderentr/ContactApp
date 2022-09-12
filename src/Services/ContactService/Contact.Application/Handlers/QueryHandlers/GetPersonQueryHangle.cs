using Contact.Application.Queries.Request;
using Contact.Application.Queries.Response;
using Contact.Domain.PersonAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Handlers.QueryHandlers
{
    public class GetPersonQueryHangle : IRequestHandler<GetPersonQueryRequest, GetPersonQueryResponse>
    {
        IPersonRepository _personRequest;
        public GetPersonQueryHangle(IPersonRepository personRequest)
        {
            _personRequest = personRequest;
        }

        public async Task<GetPersonQueryResponse> Handle(GetPersonQueryRequest request, CancellationToken cancellationToken)
        {
           var person= _personRequest.Get(request.PersonId);
            return new GetPersonQueryResponse { Person = person };
        }
    }
}

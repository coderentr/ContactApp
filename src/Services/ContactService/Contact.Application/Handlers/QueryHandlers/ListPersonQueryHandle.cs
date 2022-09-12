using Contact.Application.Mapping;
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
    public class ListPersonQueryHandle : IRequestHandler<ListPersonQueryRequest,List<ListPersonQueryResponse>>
    {
        IPersonRepository _personRequest;
        public ListPersonQueryHandle(IPersonRepository personRequest)
        {
             _personRequest= personRequest;
        }

        public async Task<List<ListPersonQueryResponse>> Handle(ListPersonQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<ListPersonQueryResponse> res = new List<ListPersonQueryResponse>();
                var persons= _personRequest.Get();
                return persons.ToDto(); 
            }
            catch (Exception)
            {
                return null;
            }
          
        }
    }
}

using Contact.Application.Queries.Response;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Queries.Request
{
    public class GetPersonQueryRequest: IRequest<GetPersonQueryResponse>
    {
        public string PersonId { get; set; }
    }
}

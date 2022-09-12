using Contact.Application.Commands.Response;
using Contact.Application.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Queries.Request
{
    public class ListPersonQueryRequest: IRequest<List<ListPersonQueryResponse>> 
    {

    }
}

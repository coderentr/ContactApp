using Contact.Application.Commands.Response;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Commands.Request
{
    public class DeletePersonCommandRequest: IRequest<DeletePersonCommandResponse>
    {
        public string PersonId { get; set; }
    }
}

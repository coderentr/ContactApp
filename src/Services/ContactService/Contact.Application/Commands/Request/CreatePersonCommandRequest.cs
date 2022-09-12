using Contact.Application.Commands.Response;
using Contact.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Commands.Request
{
    public class CreatePersonCommandRequest : IRequest<CreatePersonCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ContactType ContactType { get; set; }
        public string ContactınfoContant { get; set; }
    }
}

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
    public class AddPersonContactInfoCommandRequest: IRequest<AddPersonContactInfoCommandResponse>
    {
        public string PersonId { get; set; }
        public ContactType ContactType { get; set; }
        public string ContactContent { get; set; }
    }
}

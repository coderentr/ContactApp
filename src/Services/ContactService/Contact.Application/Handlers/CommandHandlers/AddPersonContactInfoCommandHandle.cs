using Contact.Application.Commands.Request;
using Contact.Application.Commands.Response;
using Contact.Domain.PersonAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Handlers.CommandHandlers
{
    public class AddPersonContactInfoCommandHandle : IRequestHandler<AddPersonContactInfoCommandRequest, AddPersonContactInfoCommandResponse>
    {
        IPersonRepository _personRepository;
        public AddPersonContactInfoCommandHandle(IPersonRepository personRepository)
        {
            _personRepository= personRepository;
        }
        public async Task<AddPersonContactInfoCommandResponse> Handle(AddPersonContactInfoCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var person = _personRepository.Get(request.PersonId);
                if (person != null)
                {
                    var contacInfo = new ContactInfo
                    {
                        ContactContent = request.ContactContent,
                        ContactType = request.ContactType,
                    };
                    person.ContactInfo.Add(contacInfo);
                }
                _personRepository.Update(person);
                return new AddPersonContactInfoCommandResponse
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new AddPersonContactInfoCommandResponse
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}

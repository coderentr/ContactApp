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
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommandRequest, CreatePersonCommandResponse>
    {
        IPersonRepository _personRepository;
        public CreatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<CreatePersonCommandResponse> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<ContactInfo> contactInfo = new List<ContactInfo>
                {
                    new ContactInfo
                    { 
                        ContactContent = request.ContactınfoContant,
                        ContactType = request.ContactType
                    }
                };
                Person person = new Person
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Company = request.Company,
                    ContactInfo = contactInfo
                };
                await _personRepository.Create(person);
                //person.ContactInfo.Add(contactInfo);
                return new CreatePersonCommandResponse
                {
                    IsSuccess = true,
                    PersonId = person.Id.ToString()
                };
            }
            catch (Exception ex)
            {

                return new CreatePersonCommandResponse { IsSuccess = false, Message = ex.Message };
            }

        }
    }
}

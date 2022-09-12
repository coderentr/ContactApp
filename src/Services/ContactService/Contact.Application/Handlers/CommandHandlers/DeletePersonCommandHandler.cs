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
    public class DeletePersonCommandHandler:IRequestHandler<DeletePersonCommandRequest, DeletePersonCommandResponse>
    {
        IPersonRepository _personRepository;
        public DeletePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<DeletePersonCommandResponse> Handle(DeletePersonCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                Person p = _personRepository.Get(request.PersonId);
                if(p!=null)
                {
                    _personRepository.Delete(p.Id.ToString());
                    return new DeletePersonCommandResponse { IsSuccess = true };
                }
                else
                {
                    return new DeletePersonCommandResponse
                    {
                        IsSuccess = false,
                        Message = "Person couldnt find ! "
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeletePersonCommandResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}

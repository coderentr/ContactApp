using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Commands.Response
{
    public class CreatePersonCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string PersonId { get; set; }
    }
}

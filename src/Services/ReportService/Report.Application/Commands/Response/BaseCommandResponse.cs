using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Commands.Response
{
    public class BaseCommandResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}

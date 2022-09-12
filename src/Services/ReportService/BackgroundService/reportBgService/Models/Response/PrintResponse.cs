using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reportBgService.Models.Response
{
    public class PrintResponse
    {
        public bool IsSuccess { get; set; }
        public string FilePath { get; set; }
    }
}

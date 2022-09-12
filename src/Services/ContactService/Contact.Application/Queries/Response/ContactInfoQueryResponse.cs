using Contact.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Queries.Response
{
    public  class ContactInfoQueryResponse
    {
        public ContactType ContactType { get; set; }
        public string ContantContent { get; set; }
        public string ContantTypeStr { get; set; }

    }
}

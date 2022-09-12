using Contact.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Queries.Response
{
    public class ListPersonQueryResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Company { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ContactInfoQueryResponse> ContactInfo { get; set; }
    }
}

using Contact.Domain.Core;
using Contact.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.PersonAggregate
{
    public class ContactInfo : Entity
    {
        public ContactType ContactType { get; set; }
        public string ContactContent { get; set; }
    }
}

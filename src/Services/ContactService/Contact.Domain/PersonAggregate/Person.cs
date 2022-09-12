using Contact.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.PersonAggregate
{
    public class Person :Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInfo> ContactInfo { get; set; }
    }
}

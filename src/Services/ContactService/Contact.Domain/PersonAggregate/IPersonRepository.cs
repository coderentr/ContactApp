using Contact.Infrastructure.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.PersonAggregate
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
    }
}

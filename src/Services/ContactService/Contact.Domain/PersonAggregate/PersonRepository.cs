using Contact.Infrastructure.mongodb;
using Contact.Infrastructure.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.PersonAggregate
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IMongoDBContext context) : base(context)
        {

        }
    }
}

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.mongodb
{
    public interface IMongoDBContext
    {
        IMongoCollection<Book> GetCollection<Book>(string name);
    }
}

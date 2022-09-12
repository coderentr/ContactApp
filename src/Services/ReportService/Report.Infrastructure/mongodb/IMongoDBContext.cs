using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Infrastructure.mongodb
{
    public interface IMongoDBContext
    {
        IMongoCollection<Book> GetCollection<Book>(string name);
    }
}

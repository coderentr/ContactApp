using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.mongodb
{
    public class MongoDbContext : IMongoDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoDbContext(IOptions<MongoDbSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.Database);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}

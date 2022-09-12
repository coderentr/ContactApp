using MongoDB.Bson;
using MongoDB.Driver;
using Report.Infrastructure.mongodb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Infrastructure.repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection;
       
        protected BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            await _dbCollection.InsertOneAsync(obj);
        }

        public void Delete(string id)
        {
            var objectId = new ObjectId(id);
            _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));
        }

        public TEntity Get(string id)
        {

            var objectId = new ObjectId(id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            return  _dbCollection.FindAsync(filter).Result.FirstOrDefault();
        }

        public IEnumerable<TEntity> Get()
        {
            var all =  _dbCollection.Find(Builders<TEntity>.Filter.Empty);
            return  all.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj), obj);
        }
    }
}

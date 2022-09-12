using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(string id);
        TEntity Get(string id);
        IEnumerable<TEntity> Get();
    }
}

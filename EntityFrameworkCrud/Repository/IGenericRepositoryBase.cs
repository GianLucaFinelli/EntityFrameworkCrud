using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace EntityFrameworkCrud.Repository
{
    public interface IGenericRepositoryBase<Entity>
    {
        IEnumerable<Entity> GetAll();
        IEnumerable<Entity> GetAll(params Expression<Func<Entity, object>>[] includes);

        Entity GetById(long id);
        Entity Insert(Entity dto);
        Entity Update(Entity dto);
        void Delete(long id);

        int SaveChanges();
    }
}

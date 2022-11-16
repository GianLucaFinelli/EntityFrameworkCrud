using EntityFrameworkCrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCrud.Exceptions;

namespace EntityFrameworkCrud.Repository
{
    public class GenericRepositoryBase<Entity>: IGenericRepositoryBase<Entity>
        where Entity : class, IEntityBase, new()
    {
        private readonly EFCrudContext dbContext;
        private DbSet<Entity> table;

        public GenericRepositoryBase(EFCrudContext dbContext)
        {
            this.dbContext = dbContext;
            table = dbContext.Set<Entity>();
        }

        public IEnumerable<Entity> GetAll()
        {
            return table.ToList();
        }

        public IEnumerable<Entity> GetAll(params Expression<Func<Entity, object>>[] includes)
        {
            IQueryable<Entity> query = dbContext.Set<Entity>();
            if (includes.Length > 0)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public Entity GetById(long id)
        {
            Entity existing = table.Find(id);
            if (existing != null)
            {
                return existing;
            }
            else throw new ApiException("Dicho registro no existe... contactese con el administrador.");
        }
        public Entity Insert(Entity entity)
        {
            table.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Added;
            table.Add(entity);
            return entity;
        }
        public Entity Update(Entity entity)
        {
            Entity entityToChange = GetById(entity.Id);
            dbContext.Entry(entityToChange).CurrentValues.SetValues(entity);
            return entityToChange;
        }
        public void Delete(long id)
        {
            Entity existing = table.Find(id);
            if (existing != null)
            {
                table.Remove(existing);
            }
            else throw new ApiException("Lo que desea borrar no existe... contactese con el administrador.");
        }

        public int SaveChanges()
        {
            try
            {
                var saveChanges = dbContext.SaveChanges();
                return saveChanges;
            }
            catch (ApiException exception)
            {
                ApiException.ThrowException(exception);
            }
            return -1; // Error
        }
    }
}

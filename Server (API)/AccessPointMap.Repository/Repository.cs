﻿using AccessPointMap.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessPointMap.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> entities;

        public Repository(DbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await entities.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entitiesCollection)
        {
            await entities.AddRangeAsync(entitiesCollection);
        }

        public async Task<TEntity> Get(long id)
        {
            return await entities.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public void Remove(TEntity entity, bool hard = false)
        {
            if(hard)
            {
                entities.Remove(entity);
                return;
            }

            entity.Delete();
            context.Entry(entity).State = EntityState.Modified;
        }

        public void RemoveRange(IEnumerable<TEntity> entitiesCollection, bool hard = false)
        {
            if(hard)
            {
                entities.RemoveRange(entitiesCollection);
                return;
            }

            foreach(var entity in entitiesCollection)
            {
                entity.Delete();
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

        public void UpdateState(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}

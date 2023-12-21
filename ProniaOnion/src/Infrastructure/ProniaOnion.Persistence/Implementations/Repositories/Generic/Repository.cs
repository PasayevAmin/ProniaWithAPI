using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }



        public IQueryable<T> GetAll(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? OrderExpression = null,
            bool Isdescending = false,
            int skip = 0, int take = 0,
            bool IsTracking = false,
            params string[] include)
        {
            IQueryable<T> query = _context.Set<T>();
            if (expression != null) query = query.Where(expression);

            if (OrderExpression != null)
            {
                if (Isdescending == false) query = query.OrderBy(OrderExpression);

                else query = query.OrderByDescending(OrderExpression);
            }

            if (skip != 0) query = query.Skip(skip);
            if (take != 0) query = query.Take(take);

            if (include != null)
            {
                for (int i = 0; i < include.Length; i++)
                {
                    query = query.Include(include[i]);
                }
            }
            return IsTracking ? query : query.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T entity = await _dbset.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }
        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }
        public async void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BEExam.Core.Entities;
using BEExam.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BEExam.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _dbContext { get; set; }

        public GenericRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }


        public async Task Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(int? n,bool tracking = false)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (tracking)
                query = query.AsNoTracking().AsQueryable();
            
            if (n != null)
                query = query.OrderByDescending(c => c.Id).Take((int)n);

            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id, bool tracking = false)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (tracking)
                query = query.AsNoTracking().AsQueryable();
            
            var entity = await query.FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            
        }

        public async Task<IEnumerable<T>> GetAllWithExpression(Expression<Func<T, bool>> expression, bool tracking)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (tracking)
                query = query.AsNoTracking().AsQueryable();

            var entities = await query.Where(expression).ToListAsync();
            return entities;
        }
    }
}

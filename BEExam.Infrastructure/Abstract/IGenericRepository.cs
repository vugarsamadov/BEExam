using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BEExam.Infrastructure.Abstract
{
    public interface IGenericRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync(int? n,bool tracking);
        public Task<T> GetById(int id, bool tracking);
        
        public Task<IEnumerable<T>> GetAllWithExpression(Expression<Func<T,bool>> expression, bool tracking);



        public void Update(T entity);
        
        public Task SaveChangesAsync();

        public Task Create(T entity);

        public Task Delete(T entity);
    }
}

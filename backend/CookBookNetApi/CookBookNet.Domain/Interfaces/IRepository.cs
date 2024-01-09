using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Interfaces
{
    public interface IRepository<T> where T: class
    {
        public IEnumerable<T> GetAll();

        public Task<T> GetSingle(Guid id);

        public Task<T> Update(Guid id, T entity);

        public T Delete(T entity);

        public Task<T> Create(T entity);

        public Task<IEnumerable<T>> GetBySpec(Func<T, bool> spec);
    }
}

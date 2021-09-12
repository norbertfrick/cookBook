using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T GetSingle(Guid id);

        public T Update(Guid id, T entity);

        public void Delete(Guid id);

        public T Create(T entity);
    }
}

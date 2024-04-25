using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(Guid id);

        T Delete(Guid id);

        T Update(Guid id, T newObject);

        Task<IEnumerable<T>> GetAll();

        T Create(T entity);
    }
}

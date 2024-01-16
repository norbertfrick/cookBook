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

        Task<T> Delete(Guid id);

        Task<T> Update(Guid id, T newObject);

        Task<IEnumerable<T>> GetAll();

        Task<T> Create(T entity);
    }
}

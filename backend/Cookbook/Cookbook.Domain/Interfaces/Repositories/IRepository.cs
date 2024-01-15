using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        T GetById(Guid id);

        T Delete(Guid id);

        T Update(Guid id, T newObject);

        IEnumerable<T> GetAll();
    }
}

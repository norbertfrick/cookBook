using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Interfaces
{
    public interface IEntityMapper<T, K> where T: IDto
    {
        public T MapToDto(K entity);

        public K MapFromDto(T dto);
    }
}

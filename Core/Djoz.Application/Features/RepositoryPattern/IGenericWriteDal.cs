using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.RepositoryPattern
{
    public interface IGenericWriteDal<T> : IGenericDal<T> where T : class 
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync(); //unit of work
    }
}

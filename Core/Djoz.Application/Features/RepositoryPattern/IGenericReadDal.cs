using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.RepositoryPattern
{
    public interface IGenericReadDal<T>: IGenericDal<T> where T : class
    {
        Task<List<T>> GetListAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}

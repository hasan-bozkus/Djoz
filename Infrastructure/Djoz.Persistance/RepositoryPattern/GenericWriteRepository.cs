using Djoz.Application.Features.RepositoryPattern;
using Djoz.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern
{
    public class GenericWriteRepository<T> : IGenericWriteDal<T> where T : class
    {
        private readonly DjozContext _context;

        public GenericWriteRepository(DjozContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync(); //unit of work
    }
}

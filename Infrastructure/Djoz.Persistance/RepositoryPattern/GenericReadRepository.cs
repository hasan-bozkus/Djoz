using Djoz.Application.Features.RepositoryPattern;
using Djoz.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern
{
    public class GenericReadRepository<T> : IGenericReadDal<T> where T : class
    {
        private readonly DjozContext _context;

        public GenericReadRepository(DjozContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}

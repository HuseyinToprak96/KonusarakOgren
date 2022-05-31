using KonusarakOgren.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        protected readonly ContextKonusarakOgren _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ContextKonusarakOgren context)
        {
            _context = context;
            _dbSet = context.Set<T>();
            context.Database.EnsureCreated();
        }
        public async Task AddAsync(T t)
        {
          await  _dbSet.AddAsync(t);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> getAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public void remove(T t)
        {

            _dbSet.Remove(t);
        }

        public void Update(T t)
        {
            _dbSet.Update(t);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T:class
    {
        Task<List<T>> getAllAsync();
        Task<T>GetByIdAsync(int id);
        void remove(T t);
        void Update(T t);
        Task AddAsync(T t);


    }
}

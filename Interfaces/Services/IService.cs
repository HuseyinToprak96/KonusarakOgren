using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Services
{
    public interface IService<T> where T:class
    {
        Task<List<T>> getAllAsync();
        Task<T> getByIdAsync(int id);
        Task removeAsync(int id);
        Task UpdateAsync(T t);
        Task AddAsync(T t);
    }
}

using AutoMapper;
using KonusarakOgren.Interfaces.Repositories;
using KonusarakOgren.Interfaces.Services;
using KonusarakOgren.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Service.Services
{
    public class Service<T>:IService<T> where T:class
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _genericRepository;
        protected private IMapper _mapper;

        public Service(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(T t)
        {
           await _genericRepository.AddAsync(t);
           await _unitOfWork.CommitAsync();
        }

        public async Task<List<T>> getAllAsync()
        {
            return await _genericRepository.getAllAsync();
        }

        public async Task<T> getByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task removeAsync(int id)
        {
            var obj =await _genericRepository.GetByIdAsync(id);
            _genericRepository.remove(obj);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _genericRepository.Update(t);
            await _unitOfWork.CommitAsync();
        }
    }
}

using AutoMapper;
using KonusarakOgren.Dtos;
using KonusarakOgren.Interfaces.Repositories;
using KonusarakOgren.Interfaces.Services;
using KonusarakOgren.Interfaces.UnitOfWork;
using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Service.Services
{
    public class VisitorService : Service<Visitor>,IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;
        public VisitorService(IGenericRepository<Visitor> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, IVisitorRepository visitorRepository) : base(genericRepository, unitOfWork, mapper)
        {
            _visitorRepository = visitorRepository;
        }

        public async Task<inputInformationDto> LoginVisitor(string username, string password)
        {
            var visitor = await _visitorRepository.LoginVisitor(username, password);
            var dto = _mapper.Map<inputInformationDto>(visitor);
            return dto;
        }
    }
}

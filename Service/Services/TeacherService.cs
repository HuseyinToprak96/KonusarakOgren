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
    public class TeacherService : Service<Teacher>, ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(IGenericRepository<Teacher> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, ITeacherRepository teacherRepository) : base(genericRepository, unitOfWork, mapper)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<inputInformationDto> LoginTeacher(string username, string password)
        {
            var teacher= await _teacherRepository.LoginTeacher(username, password);
            var dto = _mapper.Map<inputInformationDto>(teacher);
            return dto;
        }

        public async Task<Teacher> TeacherDetails(int id)
        {
            return await _teacherRepository.TeacherDetails(id);
        }

        public async Task<List<Student>> TeacherWithStudents(int id)
        {
            return await _teacherRepository.TeacherWithStudents(id);
        }
    }
}

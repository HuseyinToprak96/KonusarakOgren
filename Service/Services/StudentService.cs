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
    public class StudentService : Service<Student>,IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IGenericRepository<Student> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, IStudentRepository studentRepository) : base(genericRepository, unitOfWork, mapper)
        {
            _studentRepository = studentRepository;
        }

        public async Task<inputInformationDto> LoginStudent(string username, string password)
        {
            return _mapper.Map<inputInformationDto>(await _studentRepository.LoginStudent(username, password));
        }

        public async Task<StudentDetailDto> StudentDetail(int id)
        {
            var studentDetail = await _studentRepository.StudentDetail(id);
            var studentDetailDto = _mapper.Map<StudentDetailDto>(studentDetail);
            return studentDetailDto;
        }
    }
}

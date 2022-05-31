using KonusarakOgren.Dtos;
using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Services
{
    public interface IVisitorService:IService<Visitor>
    {
        Task<inputInformationDto> LoginVisitor(string username, string password);
    }
}

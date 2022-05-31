using KonusarakOgren.Dtos;
using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Repositories
{
    public interface IVisitorRepository:IGenericRepository<Visitor>
    {
        Task<Visitor> LoginVisitor(string username, string password);
    }
}

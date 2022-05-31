using KonusarakOgren.Dtos;
using KonusarakOgren.Interfaces.Repositories;
using KonusarakOgren.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Repositories
{
    public class VisitorRepository : GenericRepository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(ContextKonusarakOgren context) : base(context)
        {
        }

        public async Task<Visitor> LoginVisitor(string username, string password)//veya out kullanılır
        {
            var visitor= await _context.Visitors.Where(x => x.UserName == username && x.Password == password).SingleOrDefaultAsync();
          
            return visitor;
        }
    }
}

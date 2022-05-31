using KonusarakOgren.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.UnitOfWork
{
    public class UnitOFwork:IUnitOfWork
    {
        private readonly ContextKonusarakOgren _context;
        public UnitOFwork(ContextKonusarakOgren context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

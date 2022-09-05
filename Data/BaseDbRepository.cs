using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BaseDbRepository
    {
        private readonly ApplicationDbContext _db;

        public BaseDbRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task SaveAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}

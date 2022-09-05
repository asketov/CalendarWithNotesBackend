using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesDomain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DateRepository : BaseDbRepository, IDateRepository
    {
        private readonly ApplicationDbContext _db;

        public DateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<int> CheckDateIsExists(int dateNumber)
        {
            var date = await _db.Dates.FirstOrDefaultAsync(date => date.DateNumber == dateNumber);
            if (date == null)
            {
                return 0;
            }
            else
            {
                return date.DateId;
            }
        }
    }
}

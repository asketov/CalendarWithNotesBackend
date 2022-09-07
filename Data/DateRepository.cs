using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
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
        public async Task<Date> CheckDateIsExists(int dateNumber)
        {
            var date = await _db.Dates.FirstOrDefaultAsync(date => date.DateNumber == dateNumber);
            return date;
        }
    }
}

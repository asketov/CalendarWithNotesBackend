using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core;
using InterfacesDomain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UserRepository : BaseDbRepository, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task AddUserAsync(User user)
        {
            await _db.Users.AddAsync(user);
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
            return user;
        }
        public async Task<User> GetUserAsync(Expression<Func<User, bool>> predicate)
        {
            var user = await _db.Users.FirstOrDefaultAsync(predicate);
            return user;
        }
    }
}

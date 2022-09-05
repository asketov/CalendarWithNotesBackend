using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace InterfacesDomain
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(Expression<Func<User, bool>> predicate);
        Task SaveAsync();
    }
}

using CodeFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodeFirstApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync(Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null);
        Task<User> GetAsync(int id);
        Task<User> AddAsync(User user);
        Task<IEnumerable<User>> FindByAsync(string username, string password);

    }
}

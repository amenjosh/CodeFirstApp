using CodeFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApp.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllAsync(Func<IQueryable<Teacher>, IOrderedQueryable<Teacher>> orderBy = null);
        Task<Teacher> GetAsync(int id);
        Task<Teacher> AddAsync(Teacher teacher);
    }
}

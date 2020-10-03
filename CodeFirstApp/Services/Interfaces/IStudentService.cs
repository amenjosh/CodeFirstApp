using CodeFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApp.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync(Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null);
        Task<Student> GetAsync(int id);
        Task<Student> AddAsync(Student student);
    }
}

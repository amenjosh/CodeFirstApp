using CodeFirstApp.Context;
using CodeFirstApp.Models;
using CodeFirstApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApp.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        protected readonly SchoolDBContext _context;
        protected readonly DbSet<Teacher> _teacherDbSet;

        public TeacherService(SchoolDBContext context)
        {
            _context = context;
            _teacherDbSet = _context.Set<Teacher>();
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync(Func<IQueryable<Teacher>, IOrderedQueryable<Teacher>> orderBy = null)
        {
            try
            {
                var query = _context.Teachers;
                var teachersQuery = await query.ToListAsync();
                return teachersQuery;
            }
            catch (Exception) { return null; }
        }

        public async Task<Teacher> GetAsync(int id)
        {
            try
            {
                var teacherQuery = await _context.Teachers.FindAsync(id);
                return teacherQuery;
            }
            catch (Exception) { return null; }
        }

        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            try
            {
                await _context.AddAsync(teacher);
                await _context.SaveChangesAsync();

                return teacher;
            }
            catch (Exception) { return null; }
        }
    }
}

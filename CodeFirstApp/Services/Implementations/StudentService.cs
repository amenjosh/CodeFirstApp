using CodeFirstApp.Context;
using CodeFirstApp.Models;
using CodeFirstApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApp.Service.Implementations
{
    public class StudentService : IStudentService
    {
        protected readonly SchoolDBContext _context;
        protected readonly DbSet<Student> _studDbSet; 

        public StudentService(SchoolDBContext context)
        {
            _context = context;
            _studDbSet = _context.Set<Student>();
        }

        public async Task<IEnumerable<Student>> GetAllAsync(Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null)
        {
            try
            {
                var query = _context.Students;
                var studentsQuery = await query.ToListAsync();
                return studentsQuery;
            }
            catch (Exception) { return null; }
        }

        public async Task<Student> GetAsync(int id)
        {
            try
            {
                var studentQuery = await _context.Students.FindAsync(id);
                return studentQuery;
            }
            catch (Exception) { return null; }
        }

        public async Task<Student> AddAsync(Student student)
        {
            try
            {
                await _context.AddAsync(student);
                await _context.SaveChangesAsync();

                return student;
            }
            catch (Exception) { return null; }
        }

    }
}

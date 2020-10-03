using CodeFirstApp.Context;
using CodeFirstApp.Models;
using CodeFirstApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodeFirstApp.Service.Implementations
{
    public class UserService : IUserService
    {
        protected readonly SchoolDBContext _context;
        protected readonly DbSet<User> _userDbSet;

        public UserService(SchoolDBContext context)
        {
            _context = context;
            _userDbSet = _context.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null)
        {
            try
            {
                var query = _context.Users;
                var usersQuery = await query.ToListAsync();
                return usersQuery;
            }
            catch (Exception) { return null; }
        }

        public async Task<User> GetAsync(int id)
        {
            try
            {
                var userQuery = await _context.Users.FindAsync(id);
                return userQuery;
            }
            catch (Exception) { return null; }
        }

        public async Task<User> AddAsync(User user)
        {
            try
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception) { return null; }
        }

        public async Task<IEnumerable<User>> FindByAsync(string username, string password)
        {
            try
            {
                var userQuery = await _context.Users.Where(u=>u.username == username && u.password == password).ToListAsync();
                return userQuery;
            }
            catch (Exception e) 
            { 
                return null; 
            }
        }
    }
}

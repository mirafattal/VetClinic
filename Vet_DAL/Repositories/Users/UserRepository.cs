using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        readonly VetClinicContext _context;
        public UserRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }
        public User GetUserbyUsername(string username)
        {
            var result = _dbSet.Where(x => x.Username == username).FirstOrDefault();
            return result;
        }

        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

    }
}

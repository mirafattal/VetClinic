using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetUserbyUsername(string username);

        Task<bool> IsEmailRegisteredAsync(string email);
        Task AddUserAsync(User user);
        public Task<User> GetUserByUsernameAsync(string username);
    }
}

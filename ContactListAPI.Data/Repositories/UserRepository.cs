using System;
using ContactListAPI.Data.Repositories.Base;
using ContactListAPI.Domain.Entities;
using ContactListAPI.Domain.Interfaces.Repositories;

namespace ContactListAPI.Data.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

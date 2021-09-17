using System;
using ContactListAPI.Domain.Entities;

namespace ContactListAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using twin.Data;
using twin.Models;

namespace twin.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base (dbContext)
        {

        }
    }
}

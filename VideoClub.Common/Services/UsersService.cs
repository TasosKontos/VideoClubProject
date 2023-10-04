using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Infrastructure.Data;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;

namespace VideoClub.Common.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return _dbContext.Users.Find(username);
        }

        public ApplicationUser GetUserById(string id)
        {
            return _dbContext.Users.Find(id);
        }
    }
}

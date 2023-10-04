﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IUsersService
    {
        ApplicationUser GetUserByUsername(string username);
        ApplicationUser GetUserById(string id);
    }
}

﻿using Attlas.Domain.Commands.Output;
using Attlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Repositories
{
    public interface IUserRepository
    {
        bool CheckEmail(string email);
        void Save(User user);
        IEnumerable<GetUserCommandResult> GetAllUsers();
        GetUserCommandResult GetUserById(int userId);
        void DeleteUserById(int userId);

    }
}

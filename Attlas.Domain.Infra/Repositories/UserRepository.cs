using Attlas.Domain.Entities;
using Attlas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }
    }
}

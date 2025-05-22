using Attlas.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Input
{
    public class DeleteUserCommand : ICommand
    {
        public DeleteUserCommand(){ }

        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}

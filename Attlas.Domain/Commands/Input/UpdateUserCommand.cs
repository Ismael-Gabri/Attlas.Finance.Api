using Attlas.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Input
{
    public class UpdateUserCommand : ICommand
    {
        public UpdateUserCommand() { }

        public UpdateUserCommand(string firstName, string lastName, string email, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}

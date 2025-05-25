using Attlas.Domain.Commands.Contracts;
using Attlas.Domain.Commands.Input;
using Attlas.Domain.Commands.Output;
using Attlas.Domain.Entities;
using Attlas.Domain.Handlers.Contracts;
using Attlas.Domain.Repositories;
using Attlas.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Handlers
{
    public class UserHandler : IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
            Notifications = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Notifications { get; set; }

        public ICommandResult Handler(CreateUserCommand command)
        {
            if(!command.Validate())
                Notifications.Add("Command Validation", "Something is Wrong");

            //Criar VOs
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);

            if (name.Notifications.Count > 0 && email.Notifications.Count > 0)
                Notifications.Add("Name or Email", "Incorrect format");

            var user = new User(name, email, command.UserName, command.Password);

            _repository.Save(user);

            return new CreateUserCommandResult(user.Id, name.FirstName, name.LastName, email.Address, user.PasswordHash);
        }

        public ICommandResult Handler(CreateUserCommand command, int userId)
        {
            throw new NotImplementedException();
        }
    }
}

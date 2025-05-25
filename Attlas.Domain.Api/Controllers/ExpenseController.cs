using Attlas.Domain.Commands.Input;
using Attlas.Domain.Commands.Output;
using Attlas.Domain.Handlers;
using Attlas.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Attlas.Domain.Api.Controllers
{
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _repository;
        private readonly ExpenseHandler _handler;

        public ExpenseController(IExpenseRepository repository, ExpenseHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost("/expense")]
        [Authorize]
        public object Post([FromBody] CreateExpenseCommand command)
        {
            var userId = int.Parse(User.Identity.Name);

            var result = (CreateExpenseCommandResult)_handler.Handler(command, userId);
            if (_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }

        [HttpGet("/expense")]
        [AllowAnonymous]
        public object Get()
        {
            return _repository.GetAllExpenses();
        }

        [HttpGet("/expense/{id}")]
        [AllowAnonymous]
        public object GetById(int id)
        {
            return _repository.GetExpenseById(id);
        }

        [HttpGet("/expense/user")]
        [Authorize]
        public object GetUserExpenses()
        {
            var userId = int.Parse(User.Identity.Name);
            return _repository.GetExpensesByUserId(userId);
        }

        [HttpDelete("/expense/user/{id}")]
        [Authorize]
        public object DeleteUserExpense(int id)
        {
            var userId = int.Parse(User.Identity.Name);

            return _repository.DeleteExpenseById(userId, id);
        }

        [HttpPut("/expense/{id}")]
        [Authorize]
        public object UpdateExpense([FromBody] UpdateExpenseCommand command, int id)
        {
            var result = (UpdateExpenseCommandResult)_handler.Handler(id, command);
            if (_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }
    }
}

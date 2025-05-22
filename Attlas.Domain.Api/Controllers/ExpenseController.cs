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
        [AllowAnonymous]
        public object Post([FromBody] CreateExpenseCommand command)
        {
            var result = (CreateExpenseCommandResult)_handler.Handler(command);
            if (_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }
    }
}

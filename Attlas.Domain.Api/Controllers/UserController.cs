﻿using Attlas.Domain.Commands.Input;
using Attlas.Domain.Commands.Output;
using Attlas.Domain.Entities;
using Attlas.Domain.Handlers;
using Attlas.Domain.Infra.Contexts;
using Attlas.Domain.Infra.Services;
using Attlas.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Attlas.Domain.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;

        public UserController(IUserRepository repository, UserHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost("/users")]
        [AllowAnonymous]
        public object Post([FromBody] CreateUserCommand command)
        {
            var result = (CreateUserCommandResult)_handler.Handler(command);
            if (_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices] AttlasFinanceContext context, [FromBody] LoginInputCommand model)
        {
            var users = _repository.GetAllUsers();
            var user = users.FirstOrDefault(x => x.user_name == model.UserName && x.password_hash == model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário não encontrado" });

            var token = TokenService.GenerateToken(user);
            return new
            {
                user = user,
                token = token,
            };
        }

        [HttpDelete("/users/{id}")]
        [Authorize(Roles ="0")]
        public object Delete(int id)
        {
            _repository.DeleteUserById(id);
            return true;
        }

        [HttpGet("/users")]
        [AllowAnonymous]
        public object Get()
        {
            return _repository.GetAllUsers();
        }

        [HttpGet("/users/{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var user = _repository.GetUserById(id);

            if (user == null)
                return NotFound(new { message = "Usuário não encontrado." });

            return Ok(user);
        }
    }
}

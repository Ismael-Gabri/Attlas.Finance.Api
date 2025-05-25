using Attlas.Domain.Commands.Contracts;
using Attlas.Domain.Commands.Input;
using Attlas.Domain.Commands.Output;
using Attlas.Domain.Entities;
using Attlas.Domain.Handlers.Contracts;
using Attlas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Handlers
{
    public class ExpenseHandler : IHandler<CreateExpenseCommand>
    {
        private readonly IExpenseRepository _repository;
        public ExpenseHandler(IExpenseRepository repository)
        {
            _repository = repository;
            Notifications = new Dictionary<string, string>();
        }
        public Dictionary<string, string> Notifications { get; set; }

        public ICommandResult Handler(CreateExpenseCommand command, int userId)
        {
            if (!command.Validate())
                Notifications.Add("Command Validation", "Something is Wrong");

            var expense = new Expense(userId, command.ClientId, command.Title, command.Description, command.Amount, command.CategoryId, command.PixType, command.Pix);
            _repository.Save(expense);

            return new CreateExpenseCommandResult(expense.UserId, expense.ClientId, expense.Title, expense.Description, expense.Amount, expense.CategoryId, expense.PixType, expense.Pix);
        }

        public ICommandResult Handler(int expenseId, UpdateExpenseCommand command)
        {

            var expense = _repository.GetExpenseById(expenseId);

            expense.Title = command.Title;
            expense.Description = command.Description;
            expense.Pix = command.Pix;
            expense.Pix_Type = command.PixType;

            var newExpense = new Expense(expense.Id, expense.Cliente_Id, expense.Title, expense.Description, expense.Amount, expense.Category_Id, expense.Pix_Type, expense.Pix);

            _repository.UpdateExpenseById(newExpense, expense.Id);

            return new UpdateExpenseCommandResult();
        }

        public ICommandResult Handler(CreateExpenseCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

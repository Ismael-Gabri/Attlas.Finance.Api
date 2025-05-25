using Attlas.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Input
{
    public class DeleteExpenseCommandResult : ICommand
    {
        public DeleteExpenseCommandResult() { }
        public DeleteExpenseCommandResult(int userId, int expenseId)
        {
            UserId = userId;
            ExpenseId = expenseId;
        }

        public int UserId { get; set; }
        public int ExpenseId { get; set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}

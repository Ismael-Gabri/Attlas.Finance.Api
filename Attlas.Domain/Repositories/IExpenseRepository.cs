using Attlas.Domain.Commands.Input;
using Attlas.Domain.Commands.Output;
using Attlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Repositories
{
    public interface IExpenseRepository
    {
        void Save(Expense expense);
        IEnumerable<GetExpenseCommandResult> GetAllExpenses();
        IEnumerable<GetExpenseCommandResult> GetExpensesByUserId(int userId);
        GetExpenseCommandResult GetExpenseById(int id);
        bool DeleteExpenseById(int userId, int expenseId);
        bool UpdateExpenseById(Expense expense, int expenseId);

    }
}

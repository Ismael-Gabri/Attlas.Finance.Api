using Attlas.Domain.Commands.Input;
using Attlas.Domain.Commands.Output;
using Attlas.Domain.Entities;
using Attlas.Domain.Infra.Contexts;
using Attlas.Domain.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Infra.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AttlasFinanceContext _context;
        public ExpenseRepository(AttlasFinanceContext context)
        {
            _context = context;
        }

        public bool DeleteExpenseById(int userId, int expenseId)
        {
            var query = @"
        DELETE FROM [attlas_finance].[dbo].[expenses]
        WHERE [id] = @Id AND [user_id] = @UserId
    ";

            using (var connection = _context.GetConnection())
            {
                var rowsAffected = connection.Execute(query, new { Id = expenseId, UserId = userId });
                return rowsAffected > 0; // true se alguma linha foi deletada
            }
        }

        public IEnumerable<GetExpenseCommandResult> GetAllExpenses()
        {
            var query = @"
        SELECT TOP (1000) 
            [id],
            [user_id],
            [client_id],
            [category_id],
            [title],
            [description],
            [amount],
            [pix_type],
            [pix],
            [date_created],
            [date_updated]
        FROM [attlas_finance].[dbo].[expenses]
    ";

            using (var connection = _context.GetConnection())
            {
                var expense = connection.Query<GetExpenseCommandResult>(query);
                return expense;
            }
        }

        public GetExpenseCommandResult GetExpenseById(int id)
        {
            var query = @"
        SELECT 
            [id],
            [user_id],
            [client_id],
            [category_id],
            [title],
            [description],
            [amount],
            [pix_type],
            [pix],
            [date_created],
            [date_updated]
        FROM [attlas_finance].[dbo].[expenses]
        WHERE [id] = @Id
    ";

            using (var connection = _context.GetConnection())
            {
                var expense = connection.QueryFirstOrDefault<GetExpenseCommandResult>(query, new { Id = id });
                return expense;
            }
        }

        public IEnumerable<GetExpenseCommandResult> GetExpensesByUserId(int userId)
        {
            var query = @"
        SELECT 
            [id],
            [user_id],
            [client_id],
            [category_id],
            [title],
            [description],
            [amount],
            [pix_type],
            [pix],
            [date_created],
            [date_updated]
        FROM [attlas_finance].[dbo].[expenses]
        WHERE [user_id] = @UserId
    ";

            using (var connection = _context.GetConnection())
            {
                var expenses = connection.Query<GetExpenseCommandResult>(query, new { UserId = userId });
                return expenses;
            }
        }

        public void Save(Expense expense)
        {
            using (var connection = _context.GetConnection())
            {
                var query = @"
            INSERT INTO expenses (
                user_id,
                client_id,
                title,
                description,
                amount,
                category_id,
                pix_type,
                pix,
                date_created
            )
            VALUES (
                @UserId,
                @ClientId,
                @Title,
                @Description,
                @Amount,
                @CategoryId,
                @PixType,
                @Pix,
                @DateCreated
            );
        ";

                connection.Execute(query, new
                {
                    expense.UserId,
                    expense.ClientId,
                    expense.Title,
                    expense.Description,
                    expense.Amount,
                    CategoryId = expense.CategoryId,
                    PixType = (int)expense.PixType,
                    expense.Pix,
                    expense.DateCreated
                });
            }
        }

        public bool UpdateExpenseById(Expense expense, int expenseId)
        {
            var query = @"
        UPDATE [attlas_finance].[dbo].[expenses]
        SET 
            [title] = @Title,
            [description] = @Description,
            [pix_type] = @PixType,
            [pix] = @Pix,
            [date_updated] = GETDATE()
        WHERE [id] = @Id
    ";

            using (var connection = _context.GetConnection())
            {
                var rowsAffected = connection.Execute(query, new
                {
                    Title = expense.Title,
                    Description = expense.Description,
                    PixType = expense.PixType,
                    Pix = expense.Pix,
                    Id = expenseId // <- aqui está a mudança importante
                });

                return rowsAffected > 0;
            }
        }
    }
}

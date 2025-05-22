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
    }
}

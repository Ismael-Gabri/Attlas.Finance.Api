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
    }
}

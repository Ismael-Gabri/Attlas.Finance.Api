using Attlas.Domain.Commands.Contracts;
using Attlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Output
{
    public class GetExpenseCommandResult : ICommandResult
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Cliente_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Category_Id { get; set; }
        public EPixType Pix_Type { get; set; }
        public string Pix { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
    }
}

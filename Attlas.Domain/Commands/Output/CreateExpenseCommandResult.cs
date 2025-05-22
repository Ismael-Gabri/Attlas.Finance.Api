using Attlas.Domain.Commands.Contracts;
using Attlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Output
{
    public class CreateExpenseCommandResult : ICommandResult
    {
        public CreateExpenseCommandResult(int userId, int clientId, string title, string description, decimal amount, int categoryId, EPixType pixType, string pix)
        {
            UserId = userId;
            ClientId = clientId;
            Title = title;
            Description = description;
            Amount = amount;
            CategoryId = categoryId;
            PixType = pixType;
            Pix = pix;
        }

        public int UserId { get; set; }
        public int ClientId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public EPixType PixType { get; set; }
        public string Pix { get; set; }
    }
}

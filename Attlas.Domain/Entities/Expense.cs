using Attlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Entities
{
    public class Expense
    {
        public Expense(int userId, int clientId, string title, string description, decimal amount, int category, EPixType pixType, string pix)
        {
            UserId = userId;
            ClientId = clientId;
            Title = title;
            Description = description;
            Amount = amount;
            CategoryId = category;
            PixType = pixType;
            Pix = pix;
            DateCreated = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int ClientId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public int CategoryId { get; private set; }
        public EPixType PixType { get; private set; }
        public string Pix { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }
    }
}

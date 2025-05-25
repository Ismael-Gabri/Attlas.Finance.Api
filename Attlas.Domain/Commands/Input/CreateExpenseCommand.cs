using Attlas.Domain.Commands.Contracts;
using Attlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Input
{
    public class CreateExpenseCommand : ICommand
    {
        public CreateExpenseCommand() { }
        public CreateExpenseCommand(int clientId, string title, string description, decimal amount, int categoryId, EPixType pixType, string pix)
        {
            ClientId = clientId;
            Title = title;
            Description = description;
            Amount = amount;
            CategoryId = categoryId;
            PixType = pixType;
            Pix = pix;
        }

        public int ClientId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public EPixType PixType { get; set; }
        public string Pix { get; set; }

        Dictionary<string, string> Notifications = new Dictionary<string, string>();

        public bool Validate()
        {

            if (ClientId <= 0)
                Notifications.Add("ClientId", "O ID do cliente é obrigatório e deve ser maior que 0.");

            if (string.IsNullOrWhiteSpace(Title))
                Notifications.Add("Title", "O título é obrigatório.");

            if (string.IsNullOrWhiteSpace(Description))
                Notifications.Add("Description", "A descrição é obrigatória.");

            if (Amount <= 0)
                Notifications.Add("Amount", "O valor da despesa deve ser maior que 0.");

            if (CategoryId <= 0)
                Notifications.Add("CategoryId", "A categoria é obrigatória e deve ser maior que 0.");

            if (!Enum.IsDefined(typeof(EPixType), PixType))
                Notifications.Add("PixType", "O tipo de Pix é inválido.");

            if (string.IsNullOrWhiteSpace(Pix))
                Notifications.Add("Pix", "A chave Pix é obrigatória.");

            if (Notifications.Count > 0)
                return false;
            else
                return true;
        }
    }
}

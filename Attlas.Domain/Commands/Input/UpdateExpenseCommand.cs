using Attlas.Domain.Commands.Contracts;
using Attlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Input
{
    public class UpdateExpenseCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EPixType PixType { get; set; }
        public string Pix { get; set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}

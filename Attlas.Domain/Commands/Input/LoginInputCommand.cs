using Attlas.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Input
{
    public class LoginInputCommand
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}

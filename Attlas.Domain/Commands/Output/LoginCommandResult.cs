﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Output
{
    public class LoginCommandResult
    {
        public string? UserName { get; set; }
        public string? AccessToken { get; set; }
    }
}

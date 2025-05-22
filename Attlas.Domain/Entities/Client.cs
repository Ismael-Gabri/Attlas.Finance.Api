using Attlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Entities
{
    public class Client
    {
        public Client(int id, string name, EClientStatus status)
        {
            Id = id;
            Name = name;
            Status = EClientStatus.Active;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public EClientStatus Status { get; private set; }
    }
}

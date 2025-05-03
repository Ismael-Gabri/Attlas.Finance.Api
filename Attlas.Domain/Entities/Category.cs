using Attlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Entities
{
    public class Category
    {
        public Category(int id, string name, string description, ECategoryStatus status, DateTime dateCreated)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
            DateCreated = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ECategoryStatus Status { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }
    }
}

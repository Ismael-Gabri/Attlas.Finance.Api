using Attlas.Domain.Enums;
using Attlas.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Entities
{
    public class User
    {
        private readonly IList<Expense> _expenses;
        public User(int id, Name name, Email email, string userName, string passwordHash, ERole role)
        {
            Id = id; //implementar lógica
            Name = name;
            Email = email;
            UserName = userName;
            PasswordHash = passwordHash;
            EntryDate = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string? ProfileImage { get; private set; }
        public ERole Role { get; private set; }
        public DateTime EntryDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public EPixType? PixType { get; private set; }
        public string? PixKey { get; private set; }
        public IReadOnlyCollection<Expense> Expenses { get { return _expenses.ToArray(); } }
        public IDictionary<string, string> Notifications { get; private set; }
    }
}

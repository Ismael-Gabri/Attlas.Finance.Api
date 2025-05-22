using Attlas.Domain.Entities;
using Attlas.Domain.Enums;
using Attlas.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Commands.Output
{
    public class GetUserCommandResult
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string Email { get; set; }
        public string user_name { get; set; }
        public string password_hash { get; set; }
        public string? profile_image { get; set; }
        public ERole role { get; set; }
        public DateTime entry_date { get; set; }
        public DateTime? update_date { get; set; }
        public DateTime? last_login { get; set; }
        public EPixType? pix_type { get; set; }
        public string? pix_key { get; set; }
    }
}

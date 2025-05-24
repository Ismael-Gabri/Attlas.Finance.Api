using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Infra
{
    public class Settings
    {
        public static string ConnectionString { get; set; } = "Server=localhost,1433\\SQLEXPRESS;Database=attlas_finance;User ID=sa;Encrypt=False;Password=1q2w3e4r@#$";
        public static string Secret = "73018858-5180-4b0d-8f2f-21f9a7958c47";
    }
}

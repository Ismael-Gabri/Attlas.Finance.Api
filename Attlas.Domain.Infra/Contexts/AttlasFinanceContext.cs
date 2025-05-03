using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Infra.Contexts
{
    public class AttlasFinanceContext
    {
        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}

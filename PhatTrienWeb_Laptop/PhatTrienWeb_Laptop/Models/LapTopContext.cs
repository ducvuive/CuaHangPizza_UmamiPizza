using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Models
{
    public class LapTopContext
    {
        readonly IConfiguration configuration;
        public string ConnectionString { get; set; }

        public LapTopContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}

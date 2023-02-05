using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SqlUsing
{
    internal class PostgreSql
    {
        public string Sql (string path)
        {
            // Подключаем соединение
            var connectionString = "Host=localhost;Username=postgres;Password=s$cret;Database=testdb";
            // Открываем соединение
            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            return path;
        }
    }
}

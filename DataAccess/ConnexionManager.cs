using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;

namespace Gestion_inventaire.DataAccess
{
    public static class ConnexionManager
    {
        public static string ConnectionString { get; } = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=InventoryApp";

        public static NpgsqlConnection GetConnection()
        {
            var conn = new NpgsqlConnection(ConnectionString); // Associe la chaîne de connexion
            conn.Open();
            return conn;
        }
    }
}

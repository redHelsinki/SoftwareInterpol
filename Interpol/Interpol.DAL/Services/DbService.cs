using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Interpol.DAL.Services {
    public partial class DbService : IDbService, IDisposable {
        private DbConnection _db { get; set; }
        private readonly string _connectionString;
        public DbService(string connectionString) {
            _connectionString = connectionString;
            GetDbConnection();
        }

        public DbConnection GetDbConnection() {
            _db = new SqlConnection(_connectionString);
            _db.Open();
            return _db;
        }

        public void Dispose() {
            _db.Close();
        }
    }
}

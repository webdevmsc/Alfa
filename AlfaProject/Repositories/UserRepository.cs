using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using AlfaProject.Extensions;
using AlfaProject.Models;
using Microsoft.Extensions.Configuration;

namespace AlfaProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        private void EnsureTableExists()
        {
            using var connection = GetDbConnection();
            var cmd = connection.CreateCommand("CREATE TABLE IF NOT EXISTS Users(Id TEXT NOT NULL PRIMARY KEY, FirstName TEXT NOT NULL, MiddleName TEXT NOT NULL, LastName TEXT, Login TEXT NOT NULL, IsDeleted INTEGER NOT NULL, CreatedAt NUMERIC NOT NULL, UpdatedAt NUMERIC NOT NULL)");
            cmd.ExecuteNonQuery();
        }

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            EnsureTableExists();
        }

        private IDbConnection GetDbConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
        
        public Task<string> Insert(User model)
        {
            
        }

        public Task<int> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(User model)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
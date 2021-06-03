using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text.Json.Serialization;
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
            var cmd = connection.CreateCommand(
                "CREATE TABLE IF NOT EXISTS Users(Id TEXT NOT NULL PRIMARY KEY, FirstName TEXT NOT NULL, MiddleName TEXT NOT NULL, LastName TEXT, Login TEXT NOT NULL, IsDeleted INTEGER NOT NULL, CreatedAt NUMERIC NOT NULL, UpdatedAt NUMERIC NOT NULL)");
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

        public void Create(User user)
        {
            using var connection = GetDbConnection();
            
            var cmd = connection.CreateCommand(
                "INSERT INTO Users (Id, FirstName, MiddleName, LastName, Login, IsDeleted, CreatedAt, UpdatedAt) VALUES (@id, @firstName, @middleName, @lastName, @login, @isDeleted, @createdAt, @updatedAt)");

            cmd.Parameters.Add(new SQLiteParameter("@id", user.Id));
            cmd.Parameters.Add(new SQLiteParameter("@firstName", user.FullName.FirstName));
            cmd.Parameters.Add(new SQLiteParameter("@middleName", user.FullName.MiddleName));
            cmd.Parameters.Add(new SQLiteParameter("@lastName", user.FullName.LastName));
            cmd.Parameters.Add(new SQLiteParameter("@login", user.Login));
            cmd.Parameters.Add(new SQLiteParameter("@isDeleted", user.IsDeleted));
            cmd.Parameters.Add(new SQLiteParameter("@createdAt", user.CreatedAt.ValueInt));
            cmd.Parameters.Add(new SQLiteParameter("@updatedAt", user.CreatedAt.ValueInt));
            
            cmd.ExecuteNonQuery();
        }
        

        public void Update(User user)
        {
            using var connection = GetDbConnection();
            var cmd = connection.CreateCommand(
                "UPDATE Users SET FirstName = @firstName, MiddleName = @middleName, LastName = @lastName, Login = @login, IsDeleted = @isDeleted, UpdatedAt = @updatedAt WHERE Id = @id");

            cmd.Parameters.Add(new SQLiteParameter("@id", user.Id));
            cmd.Parameters.Add(new SQLiteParameter("@firstName", user.FullName.FirstName));
            cmd.Parameters.Add(new SQLiteParameter("@middleName", user.FullName.MiddleName));
            cmd.Parameters.Add(new SQLiteParameter("@lastName", user.FullName.LastName));
            cmd.Parameters.Add(new SQLiteParameter("@login", user.Login));
            cmd.Parameters.Add(new SQLiteParameter("@isDeleted", user.IsDeleted));
            cmd.Parameters.Add(new SQLiteParameter("@updatedAt", user.UpdatedAt.ValueInt));

            cmd.ExecuteNonQuery();
        }

        public User GetById(string userId)
        {
            using var connection = GetDbConnection();
            var cmd = connection.CreateCommand("SELECT * FROM Users WHERE Id = @id");
            cmd.Parameters.Add(new SQLiteParameter("@id", userId));
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return reader.GetUser();
            }
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            using var connection = GetDbConnection();
            var cmd = connection.CreateCommand("SELECT * FROM Users WHERE IsDeleted = 0");
            using IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(reader.GetUser());
            }
            return users.AsEnumerable();
        }
    }
}
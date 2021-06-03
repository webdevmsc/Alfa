using System;
using System.Data;
using AlfaProject.Models;

namespace AlfaProject.Extensions
{
    public static class DbConnectionExtensions
    {
        public static IDbCommand CreateCommand(this IDbConnection connection, string commandText)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = commandText;
            return cmd;
        }

        public static User GetUser(this IDataReader reader)
        {
            var id = reader.GetString(0);
            var firstName = reader.GetString(1);
            var lastName = reader.GetString(3);
            var middleName = reader.GetString(2);
            var login = reader.GetString(4);
            var isDeleted = Convert.ToBoolean(reader.GetInt32(5));
            var createdAt = reader.GetInt64(6);
            var updatedAt = reader.GetInt64(7);
            
            return new User(id, isDeleted, new FullNameValue(firstName, lastName, middleName), login,
                new DateTimeConvertibleValue(createdAt), new DateTimeConvertibleValue(updatedAt));
        }
    }
}
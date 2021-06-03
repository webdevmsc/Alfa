using System.Data;

namespace AlfaProject.Extensions
{
    public static class IDbConnectionExtensions
    {
        public static IDbCommand CreateCommand(this IDbConnection connection, string commandText)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = commandText;
            return cmd;
        }
    }
}
using System;
using System.Data.SQLite;

namespace AlfaProject.Database
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext()
        {
            using (var connection = new SQLiteConnection("Data Source=alfabank.db"))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE Users(Id TEXT NOT NULL PRIMARY KEY, Name TEXT NOT NULL, Surname TEXT NOT NULL, SecondName TEXT, Login TEXT NOT NULL, IsDeleted numeric NOT NULL, CreatedAt TEXT NOT NULL)";
                command.ExecuteNonQuery();
                Console.WriteLine("Таблица Users создана");
            }
        }
    } 
}
using Microsoft.Data.SqlClient;
using System;

namespace _01.InitialSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                sqlConnection.Open();

                CreateTableCountries(sqlConnection);
                CreateTableTowns(sqlConnection);
                CreateTableMinions(sqlConnection);
                CreateTableEvilnessFactors(sqlConnection);
                CreateTableVillains(sqlConnection);
                CreateTableMinionsVillains(sqlConnection);
            }

        }
        public static void CreateTableMinionsVillains(SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand($"CREATE TABLE MinionsVillains (MinionId INT REFERENCES Minions(Id)  , VillainId INT REFERENCES Villains(Id) , PRIMARY KEY(MinionId, VillainId))", sqlConnection);
            command.ExecuteNonQuery();

        }
        public static void CreateTableVillains(SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand($"CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY , Name NVARCHAR(50) NOT NULL , EvilnessFactorId INT REFERENCES EvilnessFactors(Id))", sqlConnection);
            command.ExecuteNonQuery();

        }
        public static void CreateTableEvilnessFactors(SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand($"CREATE TABLE EvilnessFactors (Id INT PRIMARY KEY IDENTITY , Name NVARCHAR(50) NOT NULL)", sqlConnection);
            command.ExecuteNonQuery();

        }
        public static void CreateTableMinions(SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand($"CREATE TABLE Minions (Id INT PRIMARY KEY IDENTITY , Name NVARCHAR(50) NOT NULL , Age INT NOT NULL , TownId INT REFERENCES Towns(Id))", sqlConnection);
            command.ExecuteNonQuery();

        }
        public static void CreateTableTowns(SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand($"CREATE TABLE Towns (Id INT PRIMARY KEY IDENTITY , Name NVARCHAR(50) NOT NULL , CountryCode INT REFERENCES Countries(Id))", sqlConnection);
            command.ExecuteNonQuery();
        }
        public static void CreateTableCountries(SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand($"CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY , Name NVARCHAR(50) NOT NULL)", sqlConnection);
            command.ExecuteNonQuery();

        }
        public static void CreateDatabase(SqlConnection sqlConnection, string name) // name =  MinionsDB
        {
            SqlCommand command = new SqlCommand($"CREATE DATABASE {name}", sqlConnection);
            command.ExecuteNonQuery();
        }
    }
}

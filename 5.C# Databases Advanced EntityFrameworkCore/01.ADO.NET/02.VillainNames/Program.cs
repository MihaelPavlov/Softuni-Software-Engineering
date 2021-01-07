using System;
using Microsoft.Data.SqlClient;
namespace _02.VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT v.[Name] , COUNT(mv.MinionId) AS MinionsCount FROM Villains AS v INNER JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.[Name] HAVING COUNT(mv.MinionId) > 3 ORDER BY COUNT(mv.MinionId) DESC ",sqlConnection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    int countOfMinions = (int)reader["MinionsCount"];

                    Console.WriteLine($"{name} - {countOfMinions}");
                }
                
            }
        }
    }
}

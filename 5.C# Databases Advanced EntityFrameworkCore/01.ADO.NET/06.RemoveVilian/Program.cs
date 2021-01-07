using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _06.RemoveVilian
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                sqlConnection.Open();

                StringBuilder sb = new StringBuilder();

                int villianId = int.Parse(Console.ReadLine());

                string? villianName = GetVillianName(sqlConnection, villianId);

                if (villianName != null)
                {
                    sb.AppendLine($"{villianName} was deleted.");
                    sb.AppendLine($"{ReturnDeleteCountReleasesMinions(sqlConnection,villianId)} minions were released.");

                    for (int i = 0; i < sb.Length; i++)
                    {
                        Console.Write(sb[i]);
                    }
                }
                else
                {
                    Console.WriteLine("No such villian was found.");
                }

                


            }
        }

        public static string GetVillianName(SqlConnection sqlConnection , int villianId)
        {
            string getVillianNameQueryText = "SELECT [Name] FROM Villains WHERE Id = @villianId";
            SqlCommand cmdGetVillianNameQuery = new SqlCommand(getVillianNameQueryText, sqlConnection);
            cmdGetVillianNameQuery.Parameters.AddWithValue("@villianId", villianId);

            return (string?)cmdGetVillianNameQuery.ExecuteScalar();
        }

        public static void DeleteVillian(SqlConnection sqlConnection , int villianId)
        {
            string deleteVillianQueryText = "DELETE FROM Villains WHERE Id = @villianId";
            SqlCommand deleteVillianQuery = new SqlCommand(deleteVillianQueryText, sqlConnection);
            deleteVillianQuery.Parameters.AddWithValue("@villianId", villianId);
            deleteVillianQuery.ExecuteNonQuery();
        }

        public static int ReturnDeleteCountReleasesMinions(SqlConnection sqlConnection , int villianId)
        {
            string releasesMinionQueryText = "DELETE FROM MinionsVillains WHERE VillainId = @villianId";

            SqlCommand releasesMinionQuery = new SqlCommand(releasesMinionQueryText, sqlConnection);
            releasesMinionQuery.Parameters.AddWithValue("@villianId", villianId);
            return (int)releasesMinionQuery.ExecuteNonQuery();
        }
    }
}

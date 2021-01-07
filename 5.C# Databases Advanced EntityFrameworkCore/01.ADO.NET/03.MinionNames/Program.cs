using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                StringBuilder sb = new StringBuilder();

                sqlConnection.Open();
                int villainId = int.Parse(Console.ReadLine());


                string villainIdQueryText = "SELECT Name FROM Villains WHERE Id = @villainId";
                SqlCommand villainIdQuery = new SqlCommand(villainIdQueryText, sqlConnection);
                villainIdQuery.Parameters.AddWithValue("@villainId", villainId);

                string villainName = villainIdQuery.ExecuteScalar()?.ToString();

                string minionsCountQueryText = "SELECT COUNT(m.[Name]) FROM Villains AS v INNER JOIN MinionsVillains AS mv ON v.Id = mv.VillainId INNER JOIN Minions AS m ON m.Id = mv.MinionId WHERE v.Id = @villainId";
                SqlCommand minionsCountQuery = new SqlCommand(minionsCountQueryText, sqlConnection);
                minionsCountQuery.Parameters.AddWithValue("@villainId", villainId);

                int countOfMinions = (int)minionsCountQuery.ExecuteScalar();

                if (villainName == null)
                {
                    sb.AppendLine($"No villain with ID {villainId} exists in the database.");
                }
                else
                {
                    sb.AppendLine($"Villain: {villainName}");
                    if (countOfMinions == 0)
                    {
                        sb.AppendLine("(no minions)");
                    }
                    else
                    {
                        // can use reader.HasRows() ; instead of minionsCountQuery can use minionsNamesAndAgeQuary
                        SqlCommand minionsNamesAndAgeQuery = new SqlCommand("SELECT m.[Name] , m.Age FROM Villains AS v INNER JOIN MinionsVillains AS mv ON v.Id = mv.VillainId INNER JOIN Minions AS m ON m.Id = mv.MinionId WHERE v.Id = @villainId ORDER BY m.[Name]", sqlConnection);
                        minionsNamesAndAgeQuery.Parameters.AddWithValue("@villainId", villainId);
                        using SqlDataReader reader = minionsNamesAndAgeQuery.ExecuteReader();
                        int count = 0;
                        while (reader.Read())
                        {
                            count++;
                            sb.AppendLine($"{count}. {reader["Name"]} {reader["Age"]}");
                        }
                    }
                }

                for (int i = 0; i < sb.Length; i++)
                {
                    Console.Write(sb[i]);
                }
            }

        }
    }
}

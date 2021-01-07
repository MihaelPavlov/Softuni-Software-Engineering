using Microsoft.Data.SqlClient;
using System;

namespace _09.Increase_Age_Stored_Procedure
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                sqlConnection.Open();

                string cmdExecProcText = "EXEC usp_GetOlder @minionId";
                SqlCommand cmdExecuteProcedure = new SqlCommand(cmdExecProcText, sqlConnection);

                int minionId = int.Parse(Console.ReadLine());
                cmdExecuteProcedure.Parameters.AddWithValue("@minionId", minionId);

                cmdExecuteProcedure.ExecuteNonQuery();
                Console.WriteLine(GetMinionNameAndAge(sqlConnection, minionId));
            }

        }

        public static string GetMinionNameAndAge(SqlConnection sqlConnection, int minionId)
        {
            string cmdMinionNameAgeQueryText = "SELECT [Name] , Age FROM Minions WHERE Id = @minionId";

            SqlCommand cmdMinionNameAgeQuery = new SqlCommand(cmdMinionNameAgeQueryText, sqlConnection);

            cmdMinionNameAgeQuery.Parameters.AddWithValue("@minionId", minionId);

            SqlDataReader reader = cmdMinionNameAgeQuery.ExecuteReader();
            string nameAndAge = string.Empty;

            reader.Read();
            nameAndAge = reader["Name"] + " - " + reader["Age"] + " years old.";


            return nameAndAge;

        }
    }
}

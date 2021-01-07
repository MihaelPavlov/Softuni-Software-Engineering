using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace _08.Increase_Minion_Age
{
    class Program
    {
        static void Main(string[] args)
        {

            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                sqlConnection.Open();

                int[] inputRows = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                StringBuilder sb = new StringBuilder();

                string cmdText = "SELECT Id,Name,Age FROM Minions";

                SqlCommand cmd = new SqlCommand(cmdText, sqlConnection);




                for (int i = 0; i < inputRows.Length; i++)
                {
                    string minionName = GetMinionName(sqlConnection, inputRows[i]);
                    if (minionName != null)
                    {
                        SqlCommand getMinionId = new SqlCommand("SELECT Id FROM Minions WHERE Name = @minionName",sqlConnection);
                        getMinionId.Parameters.AddWithValue("@minionName", minionName);
                        int minionId = (int)getMinionId.ExecuteScalar();
                        if (inputRows[i] == minionId)
                        {
                            ChangeAge(sqlConnection, minionName);

                        }
                    }
                }
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sb.AppendLine(reader["Name"].ToString() +" "+ reader["Age"].ToString());
                }
                for (int i = 0; i < sb.Length; i++)
                {
                    Console.Write(sb[i]);
                }


            }
        }

        private static string GetMinionName(SqlConnection sqlConnection, int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT [Name] FROM Minions WHERE Id = @id", sqlConnection);
            cmd.Parameters.AddWithValue("@id", id);
            return (string?)cmd.ExecuteScalar();
        }

        private static void ChangeAge(SqlConnection sqlConnection, string name)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Minions SET Age += 1 WHERE Name = @name", sqlConnection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
        }
    }
}

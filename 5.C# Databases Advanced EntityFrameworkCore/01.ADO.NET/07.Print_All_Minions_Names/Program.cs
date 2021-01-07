using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07.Print_All_Minions_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                sqlConnection.Open();

                SqlCommand findMinionsCmd = new SqlCommand("SELECT Name FROM Minions ORDER BY Id", sqlConnection);
                SqlDataReader reader = findMinionsCmd.ExecuteReader();
                List<string> names = new List<string>();

                using (reader)
                {
                    while (reader.Read())
                    { names.Add((string)reader["Name"]); }
                }
                for (int i = 0; i < names.Count / 2; i++)
                {
                    Console.WriteLine(names[i]);
                    Console.WriteLine(names[names.Count - 1 - i]);
                }
                if (names.Count % 2 == 1)
                    Console.WriteLine(names[names.Count / 2]);

            }
        }
    }
}

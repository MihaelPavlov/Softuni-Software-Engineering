using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                sqlConnection.Open();

                string inputCountry = Console.ReadLine();

                List<string> list = new List<string>();

                int countRows = 0;

                string getTownsQueryText = "SELECT t.[Name] FROM Towns AS t INNER JOIN Countries AS c ON t.CountryCode = c.Id WHERE @countryName = c.[Name]";
                SqlCommand getTownsQuery = new SqlCommand(getTownsQueryText, sqlConnection);

                getTownsQuery.Parameters.AddWithValue("@countryName", inputCountry);


                using SqlDataReader readerTowns = getTownsQuery.ExecuteReader();

                if (readerTowns.HasRows)
                {
                    while (readerTowns.Read())
                    {

                        list.Add((string)readerTowns["Name"]);

                        countRows++;

                    }
                    readerTowns.Close();
                    Console.WriteLine($"{countRows} town names were affected.");


                    // concat with string join . stringBuilder

                    for (int i = 0; i < list.Count; i++)
                    {
                        MakeUpperCase(sqlConnection, list[i]);
                    }
                    foreach (var item in list)
                    {
                        item.ToUpper();
                    }
                    Console.WriteLine(string.Join(", ", list));


                }
                else
                {
                    Console.WriteLine("No town names were affected.");

                }


            }

        }

        public static void MakeUpperCase(SqlConnection sqlConnection, string townName)
        {
            //TODO need to find other way to update or selecct the towns that are going to transform to upper case
            string upperCaseQueryText = "UPDATE Towns SET Name = UPPER(Name) WHERE Name = @townName ";

            using SqlCommand upperCaseQuery = new SqlCommand(upperCaseQueryText, sqlConnection);

            upperCaseQuery.Parameters.AddWithValue("@townName", townName);

            upperCaseQuery.ExecuteNonQuery();
        }
    }
}

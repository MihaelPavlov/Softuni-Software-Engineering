using Microsoft.Data.SqlClient;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                sqlConnection.Open();

                string[] inputMinion = Console.ReadLine().Split(" ");
                string[] inputVillian = Console.ReadLine().Split(" ");

                string minionName = inputMinion[1];
                int minionAge = int.Parse(inputMinion[2]);
                string minionTown = inputMinion[3];

                string villianName = inputVillian[1];


                StringBuilder sb = new StringBuilder();

                if (!IsTownExist(sqlConnection, minionTown))
                {
                    AddTownInDatabase(sb, sqlConnection, minionTown);
                }
                if (!ChekcIsVillianExist(sqlConnection, villianName))
                {
                    AddVillian(sb, sqlConnection, villianName);
                }

                AddMinion(sqlConnection, minionName, minionAge, minionTown);
                MakeMinionServantToVillian(sb, sqlConnection, minionName, villianName);


                for (int i = 0; i < sb.Length; i++)
                {
                    Console.Write(sb[i]);
                }
            }
        }

        public static bool IsTownExist(SqlConnection sqlConnection, string town)
        {
            bool townExist = false;
            string townQueryText = "SELECT [Name] FROM Towns";
            SqlCommand townQuery = new SqlCommand(townQueryText, sqlConnection);
            using SqlDataReader readerTown = townQuery.ExecuteReader();

            while (readerTown.Read())
            {
                string readedTown = readerTown["Name"]?.ToString();

                if (readedTown == town)
                {
                    return townExist = true;
                }
            }


            return townExist;

        }

        public static void AddTownInDatabase(StringBuilder sb, SqlConnection sqlConnection, string town)
        {
            string addTownQueryText = "INSERT INTO Towns([Name]) VALUES(@town)";
            SqlCommand addTown = new SqlCommand(addTownQueryText, sqlConnection);
            addTown.Parameters.AddWithValue("@town", town);

            addTown.ExecuteNonQuery();
            sb.AppendLine($"Town {town} was added to the database.");
        }

        public static bool ChekcIsVillianExist(SqlConnection sqlConnection, string villianName)
        {
            bool isVillianExist = false;

            string villianQueryText = "SELECT [Name] FROM Villains ";
            SqlCommand villianNames = new SqlCommand(villianQueryText, sqlConnection);

            using SqlDataReader villianReader = villianNames.ExecuteReader();

            while (villianReader.Read())
            {
                string readedVillian = villianReader["Name"]?.ToString();

                if (readedVillian == villianName)
                {
                    isVillianExist = true;
                    return isVillianExist;
                }
            }

            return isVillianExist;


        }

        public static void AddVillian(StringBuilder sb, SqlConnection sqlConnection, string villianName)
        {
            string addVillianQueryText = "INSERT INTO Villains ([Name],EvilnessFactorId) VALUES (@villianName, 4)";
            SqlCommand addVillian = new SqlCommand(addVillianQueryText, sqlConnection);
            addVillian.Parameters.AddWithValue("@villianName", villianName);
            addVillian.ExecuteNonQuery();

            sb.AppendLine($"Villain {villianName} was added to the database.");
        }


        public static void AddMinion(SqlConnection sqlConnection, string minionName, int minionAge, string minionTown)
        {
            string addMinionQueryText = "INSERT INTO Minions ([Name] ,Age , TownId ) VALUES (@minionName, @minionAge,@townId) ";
            SqlCommand addMinionQuery = new SqlCommand(addMinionQueryText, sqlConnection);
            addMinionQuery.Parameters.AddWithValue("@minionName", minionName);
            addMinionQuery.Parameters.AddWithValue("@minionAge", minionAge);
            addMinionQuery.Parameters.AddWithValue("@townId", GetTownId(sqlConnection, minionTown));


        }
        public static int GetTownId(SqlConnection sqlConnection, string townName)
        {
            string townIdQueryText = "SELECT Id FROM Towns WHERE[Name] = @townName";
            SqlCommand townIdQuery = new SqlCommand(townIdQueryText, sqlConnection);
            townIdQuery.Parameters.AddWithValue("@townName", townName);

            int townId = (int)townIdQuery.ExecuteScalar();
            return townId;
        }

        public static void MakeMinionServantToVillian
            (StringBuilder sb, SqlConnection sqlConnection, string minionName, string villianName)
        {
            string getMinionIdQueryText = "SELECT Id FROM Minions WHERE[Name] = @minionName";
            SqlCommand getMinionIdQuery = new SqlCommand(getMinionIdQueryText, sqlConnection);
            getMinionIdQuery.Parameters.AddWithValue("@minionName", minionName);


            string getVillianIdQueryText = "SELECT Id FROM Villains WHERE[Name] = @villianName";
            SqlCommand getVillianIdQuery = new SqlCommand(getVillianIdQueryText, sqlConnection);
            getVillianIdQuery.Parameters.AddWithValue("@villianName", villianName);

            int minionId = (int)getMinionIdQuery.ExecuteScalar();
            int villianId = (int)getVillianIdQuery.ExecuteScalar();

            string insertIntoDatabaseMinionServantToVillianQueryText = "INSERT INTO MinionsVillains (MinionId,VillainId)VALUES (@minionId,@villianId)";
            SqlCommand insertIntoDatabaseMinionServantToVillianQuery = new SqlCommand(insertIntoDatabaseMinionServantToVillianQueryText, sqlConnection);
            insertIntoDatabaseMinionServantToVillianQuery.Parameters.AddWithValue("@minionId", minionId);
            insertIntoDatabaseMinionServantToVillianQuery.Parameters.AddWithValue("@villianId", villianId);
            insertIntoDatabaseMinionServantToVillianQuery.ExecuteNonQuery();

            sb.AppendLine($"Successfully added {minionName} to be minion of {villianName}.");
        }


    }
}

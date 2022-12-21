using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ADO.NET_Exercises
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();

            //Problem 1.
            //SetUpMinionsDb(sqlConnection);

            //Problem 2.
            //PrintVillainNames(sqlConnection);

            //Problem 3.
            //PrintMinionsNames(sqlConnection);

            //Problem 4.
            //AddMinion(sqlConnection);

            //Problem 5.
            //ChangeTownNamesCasing(sqlConnection);

            //Problem 6.
            //RemoveVillain(sqlConnection);

            //Problem 7.
            //PrintAllMinionNames(sqlConnection);

            //Problem 8.
            //IncreaseMinionAge(sqlConnection);

            //Problem 9.
            //IncreaseAgeStoredProcedure(sqlConnection);

            sqlConnection.Close();
        }

        private static void SetUpMinionsDb(SqlConnection sqlConnection)
        {
            SqlCommand createDbCmd = new SqlCommand("CREATE DATABASE MinionsDB", sqlConnection);
            createDbCmd.ExecuteNonQuery();

            SqlCommand createTCountriesCmd =
                new SqlCommand("CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))", sqlConnection);

            SqlCommand createTTownsCmd =
                new SqlCommand(
                    "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                    sqlConnection);

            SqlCommand createTMinionsCmd =
                new SqlCommand(
                    "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                    sqlConnection);

            SqlCommand createTEvilnessFactorsCmd =
                new SqlCommand("CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                    sqlConnection);

            SqlCommand createTVillainsCmd =
                new SqlCommand(
                    "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                    sqlConnection);

            SqlCommand createTMinionsVillainsCmd = new SqlCommand(
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))",
                sqlConnection);

            createTCountriesCmd.ExecuteNonQuery();
            createTTownsCmd.ExecuteNonQuery();
            createTMinionsCmd.ExecuteNonQuery();
            createTEvilnessFactorsCmd.ExecuteNonQuery();
            createTVillainsCmd.ExecuteNonQuery();
            createTMinionsVillainsCmd.ExecuteNonQuery();

            SqlCommand insertIntoCountriesCmd =
                new SqlCommand(
                    "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",
                    sqlConnection);

            SqlCommand insertIntoTownsCmd =
                new SqlCommand(
                    "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",
                    sqlConnection);

            SqlCommand insertIntoMinionsCmd =
                new SqlCommand(
                    "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",
                    sqlConnection);

            SqlCommand insertIntoEvilnessFactorsCmd =
                new SqlCommand(
                    "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",
                    sqlConnection);

            SqlCommand insertIntoVillainsCmd =
                new SqlCommand(
                    "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)",
                    sqlConnection);

            SqlCommand insertIntoMinionsVillainsCmd =
                new SqlCommand(
                    "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)",
                    sqlConnection);

            insertIntoCountriesCmd.ExecuteNonQuery();
            insertIntoTownsCmd.ExecuteNonQuery();
            insertIntoMinionsCmd.ExecuteNonQuery();
            insertIntoEvilnessFactorsCmd.ExecuteNonQuery();
            insertIntoVillainsCmd.ExecuteNonQuery();
            insertIntoMinionsVillainsCmd.ExecuteNonQuery();
        }

        private static void PrintVillainNames(SqlConnection sqlConnection)
        {
            string query = @"
                    SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                      FROM Villains AS v 
                      JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                  GROUP BY v.Id, v.Name 
                    HAVING COUNT(mv.VillainId) > 3 
                  ORDER BY COUNT(mv.VillainId)
            ";

            SqlCommand villainNamesCmd = new SqlCommand(query, sqlConnection);
            using SqlDataReader sqlDataReader = villainNamesCmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                string villainName = (string)sqlDataReader["Name"];
                int minionsCount = (int)sqlDataReader["MinionsCount"];
                Console.WriteLine($"{villainName} - {minionsCount}");
            }

            sqlDataReader.Close();
        }

        private static void PrintMinionsNames(SqlConnection sqlConnection)
        {
            int villainId = int.Parse(Console.ReadLine());

            string queryVillain = @"SELECT Name FROM Villains WHERE Id = @Id";
            
            SqlCommand sqlCmdVillainName = new SqlCommand(queryVillain, sqlConnection);
            sqlCmdVillainName.Parameters.AddWithValue("@Id", villainId);
            string villainName = (string)sqlCmdVillainName.ExecuteScalar();

            if (villainName == null)
            {
                Console.WriteLine("No villain with ID 10 exists in the database.");
                return;
            }

            Console.WriteLine($"Villain: {villainName}");

            string queryMinions = @"
                  SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                         m.Name, 
                         m.Age
                    FROM MinionsVillains AS mv
                    JOIN Minions As m ON mv.MinionId = m.Id
                   WHERE mv.VillainId = @Id
                ORDER BY m.Name
            ";

            SqlCommand sqlCmdMinionsData = new SqlCommand(queryMinions, sqlConnection);
            sqlCmdMinionsData.Parameters.AddWithValue("@Id", villainId);
            using SqlDataReader minionSqlDataReader = sqlCmdMinionsData.ExecuteReader();

            if (!minionSqlDataReader.HasRows)
            {
                Console.WriteLine("(no minions)");
            }
            else
            {
                while (minionSqlDataReader.Read())
                {
                    long rowNum = (long)minionSqlDataReader["RowNum"];
                    string name = (string)minionSqlDataReader["Name"];
                    int age = (int)minionSqlDataReader["Age"];

                    Console.WriteLine($"{rowNum}. {name} {age}");
                }
            }

            minionSqlDataReader.Close();
        }

        private static void AddMinion(SqlConnection sqlConnection)
        {
            string[] minionInfo = Console.ReadLine().Split(" ");
            string minionName = minionInfo[1];
            string minionAge = minionInfo[2];
            string minionTown = minionInfo[3];
            string villainName = Console.ReadLine().Split(" ")[1];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            SqlCommand sqlCmdGetTownId = new SqlCommand(
                "SELECT Id FROM Towns WHERE Name = @townName", 
                sqlConnection, sqlTransaction);
            sqlCmdGetTownId.Parameters.AddWithValue("@townName", minionTown);
            object response = sqlCmdGetTownId.ExecuteScalar();
            int townId;

            if (response == null)
            {
                SqlCommand sqlCmdInsertTown = new SqlCommand(
                        "INSERT INTO Towns (Name) VALUES (@townName)", 
                        sqlConnection, sqlTransaction);
                sqlCmdInsertTown.Parameters.AddWithValue("@townName", minionTown);
                sqlCmdInsertTown.ExecuteNonQuery();
                townId = (int)sqlCmdGetTownId.ExecuteScalar();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }
            else
            {
                townId = (int)response;
            }

            SqlCommand sqlCmdGetVillainId = new SqlCommand(
                "SELECT Id FROM Villains WHERE Name = @Name", 
                sqlConnection, sqlTransaction);
            sqlCmdGetVillainId.Parameters.AddWithValue("@Name", villainName);
            response = sqlCmdGetVillainId.ExecuteScalar();
            int villainId;

            if (response == null)
            {
                SqlCommand sqlCmdInsertVillain =
                    new SqlCommand(
                        "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", 
                        sqlConnection, sqlTransaction);
                sqlCmdInsertVillain.Parameters.AddWithValue("@villainName", villainName);
                sqlCmdInsertVillain.ExecuteNonQuery();
                villainId = (int)sqlCmdGetVillainId.ExecuteScalar();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            else
            {
                villainId = (int)response;
            }

            SqlCommand sqlCmdGetMinionId = new SqlCommand(
                    "SELECT Id FROM Minions WHERE Name = @name AND Age = @age AND TownId = @townId", 
                    sqlConnection, sqlTransaction);
            sqlCmdGetMinionId.Parameters.AddWithValue("@name", minionName);
            sqlCmdGetMinionId.Parameters.AddWithValue("@age", minionAge);
            sqlCmdGetMinionId.Parameters.AddWithValue("@townId", townId);
            response = sqlCmdGetMinionId.ExecuteScalar();

            if (response != null)
            {
                Console.WriteLine($"Minion {minionName} is already in the Database");
                return;
            }

            SqlCommand sqlCmdInsertIntoMinions = new SqlCommand(
                    "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)", 
                    sqlConnection, sqlTransaction);
            sqlCmdInsertIntoMinions.Parameters.AddWithValue("@name", minionName);
            sqlCmdInsertIntoMinions.Parameters.AddWithValue("@age", minionAge);
            sqlCmdInsertIntoMinions.Parameters.AddWithValue("@townId", townId);
            sqlCmdInsertIntoMinions.ExecuteNonQuery();

            int minionId = (int)sqlCmdGetMinionId.ExecuteScalar();

            SqlCommand sqlCmdInsertIntoMinionVillains = new SqlCommand(
                    "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)",
                    sqlConnection, sqlTransaction);
            sqlCmdInsertIntoMinionVillains.Parameters.AddWithValue("@villainId", villainId);
            sqlCmdInsertIntoMinionVillains.Parameters.AddWithValue("@minionId", minionId);
            sqlCmdInsertIntoMinionVillains.ExecuteNonQuery();

            sqlTransaction.Commit();

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void ChangeTownNamesCasing(SqlConnection sqlConnection)
        {
            string countryName = Console.ReadLine();

            string query = @"
                UPDATE Towns
                   SET Name = UPPER(Name)
                 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)
            ";

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            SqlCommand sqlUpdateCmd = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlUpdateCmd.Parameters.AddWithValue("@countryName", countryName);
            int affectedRows = sqlUpdateCmd.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            string selectTownsQuery = @"
                SELECT Name
                  FROM Towns
                 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)
            ";

            SqlCommand sqlSelectTownsCmd = new SqlCommand(selectTownsQuery, sqlConnection, sqlTransaction);
            sqlSelectTownsCmd.Parameters.AddWithValue("@countryName", countryName);
            using SqlDataReader sqlTownsReader = sqlSelectTownsCmd.ExecuteReader();

            List<string> towns = new List<string>();

            while (sqlTownsReader.Read())
            {
                towns.Add((string)sqlTownsReader["Name"]);
            }

            sqlTownsReader.Close();

            if (affectedRows != towns.Count)
            {
                sqlTransaction.Rollback();
                return;
            }

            sqlTransaction.Commit();

            Console.WriteLine($"{affectedRows} town names were affected.");
            Console.WriteLine("[" + string.Join(", ", towns) + "]");
        }

        private static void RemoveVillain(SqlConnection sqlConnection)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlCommand sqlCheckVillainCmd = new SqlCommand(
                    "SELECT Name FROM Villains WHERE Id = @villainId", 
                    sqlConnection);
            sqlCheckVillainCmd.Parameters.AddWithValue("@villainId", villainId);
            object response = sqlCheckVillainCmd.ExecuteScalar();

            if (response == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            string villainName = (string)response;

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            SqlCommand sqlDeleteMinionsVillainCmd = new SqlCommand(
                    "DELETE FROM MinionsVillains WHERE VillainId = @villainId", 
                    sqlConnection, sqlTransaction);
            sqlDeleteMinionsVillainCmd.Parameters.AddWithValue("@villainId", villainId);
            int releasedMinions = sqlDeleteMinionsVillainCmd.ExecuteNonQuery();

            SqlCommand sqlDeleteVillainCmd = new SqlCommand(
                "DELETE FROM Villains WHERE Id = @villainId", 
                sqlConnection, sqlTransaction);
            sqlDeleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            if (sqlDeleteVillainCmd.ExecuteNonQuery() == 1)
            {
                sqlTransaction.Commit();
                
                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
            else
            {
                sqlTransaction.Rollback();
            }
        }

        private static void PrintAllMinionNames(SqlConnection sqlConnection)
        {
            string query = "SELECT Name FROM Minions";

            SqlCommand sqlSelectNamesCmd = new SqlCommand(query, sqlConnection);
            List<string> minions = new List<string>();
            using SqlDataReader sqlDataReader = sqlSelectNamesCmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                minions.Add((string)sqlDataReader["Name"]);
            }

            sqlDataReader.Close();

            while (minions.Any())
            {
                string first = minions[0];
                Console.WriteLine(first);
                minions.RemoveAt(0);
                string last = minions[minions.Count - 1];
                Console.WriteLine(last);
                minions.RemoveAt(minions.Count - 1);
            }
        }

        private static void IncreaseMinionAge(SqlConnection sqlConnection)
        {
            string updateQuery = @"
                UPDATE Minions
                   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                 WHERE Id = @Id
            ";

            int[] ids = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            foreach (var id in ids)
            {
                SqlCommand sqlUpdateCmd = new SqlCommand(updateQuery, sqlConnection);
                sqlUpdateCmd.Parameters.AddWithValue("@Id", id);
                sqlUpdateCmd.ExecuteNonQuery();
            }

            string selectQuery = "SELECT Name, Age FROM Minions";

            SqlCommand sqlSelectCmd = new SqlCommand(selectQuery, sqlConnection);
            using SqlDataReader sqlDataReader = sqlSelectCmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                string name = (string)sqlDataReader["Name"];
                int age = (int)sqlDataReader["Age"];
                Console.WriteLine($"{name} {age}");
            }

            sqlDataReader.Close();
        }

        private static void IncreaseAgeStoredProcedure(SqlConnection sqlConnection)
        {
            int minionId = int.Parse(Console.ReadLine());

            SqlCommand sqlStoredProc = new SqlCommand("usp_GetOlder", sqlConnection);
            sqlStoredProc.CommandType = CommandType.StoredProcedure;
            sqlStoredProc.Parameters.AddWithValue("@id", minionId);
            sqlStoredProc.ExecuteNonQuery();

            string selectQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";
            SqlCommand sqlSelectCmd = new SqlCommand(selectQuery, sqlConnection);
            sqlSelectCmd.Parameters.AddWithValue("@Id", minionId);
            using SqlDataReader sqlDataReader = sqlSelectCmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                string name = (string)sqlDataReader["Name"];
                int age = (int)sqlDataReader["Age"];
                Console.WriteLine($"{name} – {age} years old");
            }

            sqlDataReader.Close();
        }
    }
}

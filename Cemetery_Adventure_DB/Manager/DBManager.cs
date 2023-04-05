using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;

namespace Cemetery_Adventure_DB.Manager
{
    public static class DBManager
    {
        public static void SaveGame(int floor, string playerName, int maxHP, int damage, int defense, string armor, string weapon)
        {
            string connectionString = Environment.GetEnvironmentVariable("connectionString");
            const string sqlCommand = @"INSERT INTO saved_games 
                (saved_time, floor, player_name, maxHP, damage, defense, armor, weapon)
                VALUES (GETDATE(), @floor, @player_name, @maxHP, @damage, @defense, @armor, @weapon);";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand(sqlCommand, connection);
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    cmd.Parameters.AddWithValue("@floor", floor);
                    cmd.Parameters.AddWithValue("@player_name", playerName);
                    cmd.Parameters.AddWithValue("@maxHP", maxHP);
                    cmd.Parameters.AddWithValue("@damage", damage);
                    cmd.Parameters.AddWithValue("@defense", defense);
                    cmd.Parameters.AddWithValue("@armor", armor);
                    cmd.Parameters.AddWithValue("@weapon", weapon);

                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                throw new RuntimeWrappedException(e);
            }
        }

        public static Dictionary<string, string> LoadGame(int id)
        {
            var saved_game = new Dictionary<string, string>();
            string connectionString = "Server=localhost;Database=Cemetery_Adventure;Trusted_Connection=True;Encrypt=False;";
            string connectionString2 = ConfigurationManager.AppSettings["connectionString"];

            const string sqlCommand = @"SELECT * FROM saved_games
                    WHERE id = @id";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand(sqlCommand, connection);
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    cmd.Parameters.AddWithValue("@id", id);
                    var dataReader = cmd.ExecuteReader();

                    if (!dataReader.Read()) return saved_game;

                    saved_game.Add("floor", $"{dataReader.GetInt32("floor")}");
                    saved_game.Add("player_name", $"{dataReader.GetString("player_name")}");
                    saved_game.Add("maxHP", $"{dataReader.GetInt32("maxHP")}");
                    saved_game.Add("damage", $"{dataReader.GetInt32("damage")}");
                    saved_game.Add("defense", $"{dataReader.GetInt32("defense")}");
                    saved_game.Add("armor", $"{dataReader.GetString("armor")}");
                    saved_game.Add("weapon", $"{dataReader.GetString("weapon")}");

                    connection.Close();
                }

                return saved_game;
            }
            catch (SqlException e)
            {
                throw new RuntimeWrappedException(e);
            }
        }

        public static List<Dictionary<string, string>> GetAllSavedGames()
        {
            string connectionString = "Server=localhost;Database=Cemetery_Adventure;Trusted_Connection=True;Encrypt=False;";
            //string connectionString = Environment.GetEnvironmentVariable("connectionString");
            var savedGamesList = new List<Dictionary<string, string>>();

            const string sqlCommand = @"SELECT * FROM saved_games";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand(sqlCommand, connection);
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    var dataReader = cmd.ExecuteReader();

                    if (!dataReader.HasRows) return savedGamesList;

                    while (dataReader.Read())
                    {
                        var saved_game = new Dictionary<string, string>
                        {
                            { "floor", $"{dataReader.GetInt32("floor")}" },
                            { "player_name", $"{dataReader.GetString("player_name")}" },
                            { "maxHP", $"{dataReader.GetInt32("maxHP")}" },
                            { "damage", $"{dataReader.GetInt32("damage")}" },
                            { "defense", $"{dataReader.GetInt32("defense")}" },
                            { "armor", $"{dataReader.GetString("armor")}" },
                            { "weapon", $"{dataReader.GetString("weapon")}" }
                        };
                        savedGamesList.Add(saved_game);
                    }

                    connection.Close();
                }

                return savedGamesList;
            }
            catch (SqlException e)
            {
                throw new RuntimeWrappedException(e);
            }
        }
    }
}

﻿using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;

namespace Cemetery_Adventure_DB.Manager
{
    public static class DBManager
    {
        public static void SaveGame(int floor, string playerName, int maxHP, int? armorType, int? weaponType)
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            const string sqlCommand = @"INSERT INTO saved_games 
                (saved_time, floor, player_name, maxHP, armor_type, weapon_type)
                VALUES (GETDATE(), @floor, @player_name, @maxHP, @armor_type, @weapon_type);";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand(sqlCommand, connection);
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    cmd.Parameters.AddWithValue("@floor", floor);
                    cmd.Parameters.AddWithValue("@player_name", playerName);
                    cmd.Parameters.AddWithValue("@maxHP", maxHP);
                    cmd.Parameters.AddWithValue("@armor_type", armorType);
                    cmd.Parameters.AddWithValue("@weapon_type", weaponType);
                    cmd.ExecuteNonQuery();

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
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

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
                    saved_game.Add("armor_type", $"{dataReader.GetInt32("armor_type")}");
                    saved_game.Add("weapon_type", $"{dataReader.GetInt32("weapon_type")}");

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
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
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
                        var savedGame = new Dictionary<string, string>
                        {   { "id", $"{dataReader.GetInt32("id")}"},
                            { "save_time", $"{dataReader.GetDateTime("saved_time")}"},
                            { "floor", $"{dataReader.GetInt32("floor")}" },
                            { "player_name", $"{dataReader.GetString("player_name")}" },
                            { "maxHP", $"{dataReader.GetInt32("maxHP")}" },
                            { "armor_type", $"{dataReader.GetInt32("armor_type")}" },
                            { "weapon_type", $"{dataReader.GetInt32("weapon_type")}" }
                        };
                        savedGamesList.Add(savedGame);
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
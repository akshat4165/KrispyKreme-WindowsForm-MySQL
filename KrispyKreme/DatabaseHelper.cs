﻿using System;
using MySql.Data.MySqlClient;

namespace KrispyKreme
{
    public static class DatabaseHelper
    {
        // Connection string (modify according to your MySQL setup)
        private static string connectionString = "server=localhost;database=krispykreme;uid=root;pwd=1234;";

        /// <summary>
        /// Validates user credentials against the database.
        /// </summary>
        public static bool ValidateUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT password FROM users WHERE username = @username";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    object result = cmd.ExecuteScalar();
                    return result != null && result.ToString() == password; // Hash in real app
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Fetches the latest bill ID from the database.
        /// </summary>
        public static int GetLatestBillID()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MAX(id) FROM bills"; // Assuming "id" is the primary key
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value && result != null ? Convert.ToInt32(result) : 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                    return 0;
                }
            }
        }

        /// <summary>
        /// Saves a bill in the database.
        /// </summary>
        public static void SaveBill(string customerName, string phone, string items, decimal total, decimal discount, decimal final)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO bills (customer_name, phone_number, items, total_price, discount, final_price) " +
                                   "VALUES (@name, @phone, @items, @total, @discount, @final)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", customerName);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@items", items);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@discount", discount);
                    cmd.Parameters.AddWithValue("@final", final);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                }
            }
        }
    }
}

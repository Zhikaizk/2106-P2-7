using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Project.Models.Feedback
{
    public class FeedbackTDG1
    {
       
        public static void findAll()
        {
            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT * FROM Feedback";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
              
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                    Console.WriteLine(rdr[1]);
                    Console.WriteLine(rdr[2]);
                    Console.WriteLine(rdr[3]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }
        
        //insert data
         public static void insert(string type, string content, string email)
        {
            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                // not good to do like this because can be easily attack by hackers
                string sql = "INSERT INTO zk.Feedback(feedbackContent, householdEmail, feedbackStatus, feedbackType) VALUES('" + content + "', '" + email + "', 'pending', '" + type + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }
    }
}
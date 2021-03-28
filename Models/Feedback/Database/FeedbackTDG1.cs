using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Project.Models.Feedback
{
    public class FeedbackTDG1
    {
        // retrieve all feedback
        public static List<List<string>> findAll()
        {
            // create arrayList to store data retrieved
            List<List<string>> feedbackList = new List<List<string>>(); 

            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT * FROM zk.Feedback";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    // total number of column in zk.Feedback
                    List<string> data = new List<string>();
                    for (int i = 0; i < 5; i++)
                    {
                        data.Add(rdr[i].ToString());
                    }

                    // adding terms array into arrayList
                    feedbackList.Add(data);
                }

                rdr.Close();

                return feedbackList;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return feedbackList;
        }

        // retrieve resolved feedback
        public static List<List<string>> getResolvedFeedback()
        {
            // create arrayList to store data retrieved
            List<List<string>> feedbackList = new List<List<string>>();

            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "SELECT * FROM zk.Feedback WHERE feedbackStatus = 'resolved'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    // total number of column in zk.Feedback
                    List<string> data = new List<string>();
                    for (int i = 0; i < 5; i++)
                    {
                        data.Add(rdr[i].ToString());
                    }

                    // adding terms array into arrayList
                    feedbackList.Add(data);
                }

                rdr.Close();

                return feedbackList;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return feedbackList;
        }

        // retrieve pending feedback
        public static List<List<string>> getPendingFeedback()
        {
            // create arrayList to store data retrieved
            List<List<string>> feedbackList = new List<List<string>>();

            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT * FROM zk.Feedback WHERE feedbackStatus = 'pending'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    // total number of column in zk.Feedback
                    List<string> data = new List<string>();
                    for (int i = 0; i < 5; i++)
                    {
                        data.Add(rdr[i].ToString());
                    }

                    // adding terms array into arrayList
                    feedbackList.Add(data);
                }

                rdr.Close();

                return feedbackList;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return feedbackList;
        }

        // updating feedback status column
        public static void updateStatus(string status, int id)
        {
            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "UPDATE zk.Feedback SET feedbackStatus = '" + status + "' WHERE feedbackId = '" + id + "'";
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
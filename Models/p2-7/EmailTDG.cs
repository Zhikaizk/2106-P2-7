using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Project.Models.Notification
{
public class EmailTDG{
        private List<IEmail> emails = new List<IEmail>();
        public List<IEmail> find(){
            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
             MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT email FROM Account";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
               IEmail email = new Email(rdr[0].ToString());
               emails.Add(email);
            }
            rdr.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        conn.Close();
        return emails;
    }
    
        // find person record by id.
    }
    
}
    

using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Project.Models.Notification
{
public class AdminGmailTDG{
        public void find(){

            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
             MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT * FROM AdminGmail";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
               EncryptedAdminGmailSingleton.GetInstance().decryptedpasswordStart(rdr[1].ToString());

            }
            rdr.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        conn.Close();
        Console.WriteLine("Done.");
    }
    
        // find person record by id.
    }
    
}
    

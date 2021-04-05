using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Project.Models
{
    public class LoginTDG
    {
         public  List<string> find(String username,String password){

             String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
             MySqlConnection conn = new MySqlConnection(connStr);
             List<string> list = new List<string>();
             LoginModel login = new LoginModel();
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT * FROM testingHouseholdAccount WHERE householdEmail ='"+username+"'AND householdPassword = '"+password+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add((rdr[3].ToString()));//type
                list.Add((rdr[0].ToString()));//id
                list.Add((rdr[1].ToString()));//name
                list.Add((rdr[2].ToString()));//password
                list.Add("email");//email
                list.Add("5");//p
                list.Add("10");//p

            
            }
            rdr.Close();
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        conn.Close();
        Console.WriteLine(login.password);
        return list;
    }
    }
}
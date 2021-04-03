using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class DeleteInactiveTDG
    {

        private List<InactiveUsers> inactiveUsers = new List<InactiveUsers>();
        public List<InactiveUsers> findInactiveUsers(DateTime inactiveDate)
        {

            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                //open connection
                conn.Open();

                // select 
                string sqlQuery = "SELECT a.idAccount as ID, al.lastLogin as LastLogin, h.email as Email, h.Username as Username FROM Account a, AccountLogs al, Household h where a.idAccount = al.idAccountLogs and a.email = h.email and al.lastLogin < '2020-04-10'" /*+ inactiveDate.ToString()*/;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine(Convert.ToDateTime(rdr[1].ToString()));
                    InactiveUsers inactiveUser = new InactiveUsers(Convert.ToDateTime(rdr[1].ToString()), rdr[3].ToString(), rdr[2].ToString(), Int16.Parse(rdr[0].ToString()), 0, false);
                    inactiveUsers.Add(inactiveUser);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return inactiveUsers;

        }






    }
}



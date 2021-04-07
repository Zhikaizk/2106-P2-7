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
        private List<DeletedHouseholdLogs> deletedLogsL = new List<DeletedHouseholdLogs>();
        private Household household = new Household();
        public List<InactiveUsers> findInactiveUsers(DateTime inactiveDate)
        {

            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                //open connection
                conn.Open();

                // select 
                string sqlQuery = "SELECT a.idAccount as ID, al.lastLogin as LastLogin, h.email as Email, h.Username as Username FROM Account a, AccountLogs al, Household h where a.idAccount = al.idAccountLogs and a.email = h.email and al.lastLogin < '"+ inactiveDate.ToString("yyyy-MM-dd") + "'";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

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

        public IHousehold findHouseholdInfo(string email)
        {

            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                //open connection
                conn.Open();

                // select all household information
                string sqlQuery = "SELECT * FROM Household where email ='" + email + "'";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    household = new Household(rdr[0].ToString(), rdr[1].ToString(), Int32.Parse(rdr[2].ToString()), rdr[3].ToString(), Int32.Parse(rdr[4].ToString()), rdr[5].ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return household;

        }



        public void insertDeleteLog(DeletedHouseholdLogs deleteLog)
        {

            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                //open connection
                conn.Open();

                // insert statement into DeletedLogs table
                String sqlQuery = "INSERT INTO DeletedLogs (accountID,email,username,hlocation,eplan,property_size,roomlist,deleted_date,reason_for_deletion) VALUES (@accountID,@email, @username, @hlocation,@eplan,@property_size,@roomlist,@deleted_date,@reason_for_deletion)";

                MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@accountID", deleteLog.accountID);
                command.Parameters.AddWithValue("@email", deleteLog.email);
                command.Parameters.AddWithValue("@username", deleteLog.username);
                command.Parameters.AddWithValue("@hlocation", deleteLog.hlocation);
                command.Parameters.AddWithValue("@eplan", deleteLog.eplan);
                command.Parameters.AddWithValue("@property_size", deleteLog.property_size);
                command.Parameters.AddWithValue("@roomlist", deleteLog.roomlist);
                command.Parameters.AddWithValue("@deleted_date", deleteLog.deleted_date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@reason_for_deletion", deleteLog.reason_for_deletion);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();

        }



        public List<DeletedHouseholdLogs> findDeletedLogs()
        {

            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                //open connection
                conn.Open();

                // insert statement into DeletedLogs table
                String sqlQuery = "SELECT * FROM DeletedLogs";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    DeletedHouseholdLogs tempDelLogs = new DeletedHouseholdLogs(Int32.Parse(rdr[1].ToString()), rdr[2].ToString(), rdr[3].ToString(), Int32.Parse(rdr[4].ToString()), rdr[5].ToString(), Int32.Parse(rdr[6].ToString()), rdr[7].ToString(), Convert.ToDateTime(rdr[8].ToString()), rdr[9].ToString());
                    deletedLogsL.Add(tempDelLogs);
                }
                rdr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return deletedLogsL;

        }



    }
}



using Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

//added new things to try to fetch data 
using MySql.Data.MySqlClient;
//ends here 


namespace Project.Models
{
    public class PasswordResetTDG

    {
        //when user resetPassword with new password
        public static void insert(String householdEmail, String newResetPassword, String confirmResetPassword)
        {
            using (var context = new NewPasswordResetContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                //insert feedback to db
                context.NewPasswordReset.Add(new NewPasswordResetTableModule
                {
                    householdEmail = householdEmail,
                    newResetPassword = newResetPassword,
                    confirmResetPassword = confirmResetPassword
                });

                // Saves changes
                context.SaveChanges();
            }

        }

        //when user request reset password (only store their email)
        public static void insertEmail(String householdEmail)
        {
            using (var context = new PasswordResetContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                //insert feedback to db
                context.PasswordReset.Add(new PasswordResetTableModule
                {
                    householdEmail = householdEmail
                });

                // Saves changes
                context.SaveChanges();
            }

        }

        public static void printData()
        {
            // Gets and prints all books in database
            using (var context = new PasswordResetContext())
            {
                var datas = context.PasswordReset;
                foreach (var data1 in datas)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Id: {data1.passwordResetID}");
                    data.AppendLine($"Email: {data1.householdEmail}");
                    Console.WriteLine(data.ToString());
                }
            }
        }

        public static void printDataNewPasswordReset()
        {
            // Gets and prints all books in database
            using (var context = new NewPasswordResetContext())
            {

                var datas = context.NewPasswordReset;
                foreach (var datas1 in datas)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Id: {datas1.newPasswordResetID}");
                    data.AppendLine($"Email: {datas1.householdEmail}");
                    data.AppendLine($"Password: {datas1.newResetPassword}");
                    data.AppendLine($"Password: {datas1.confirmResetPassword}");
                    Console.WriteLine(data.ToString());
                }
            }
        }

        //trying to retrieve data through the console

        // public static void find()
        // {
        //     String conStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
        //     MySqlConnection con = new MySqlConnection(conStr);
        //     try
        //     {
        //         con.Open();

        //         string sql = "SELECT householdEmail FROM PasswordReset";
        //         MySqlCommand cmd = new MySqlCommand(sql, con);
        //         MySqlDataReader rdr = cmd.ExecuteReader();

        //         if (rdr.HasRows)
        //         {
        //             while (rdr.Read())
        //             {
        //                 Console.WriteLine(rdr[0]);
        //                 //  Console.WriteLine(rdr[1]);
        //             }
        //             rdr.Close();
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         // con.Close();
        //         Console.WriteLine(ex.ToString());
        //     }
        //     con.Close();
        //     Console.WriteLine("Done.");
        // }
        
        //ends here
    }
}


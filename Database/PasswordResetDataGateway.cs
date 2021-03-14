
using Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace Project.Database
{
    //is a subset to the dbcontext
    // public class PasswordResetDataGateway<T> : IPasswordResetDataGateway<T> where T : class
    public class PasswordResetDataGateway

    {
        // internal PasswordResetContext db;
        // internal DbSet<T> data = null;

        // public PasswordResetDataGateway(PasswordResetContext context)
        // {
        //     this.db = context;
        //     this.data = db.Set<T>();
        // }

        // // private PasswordResetDataGateway db = new PasswordResetDataGateway();
        // public T SelectByHouseholdEmail(string? householdEmail)
        // {
        //     return data.Find(householdEmail);
        // }


//when user resetPassword with new password
        public void insert(String householdEmail,String newPassword,String confirmPassword)
        {
            //declare that the data has been changed
            // db.Entry(obj).State = EntityState.Modified;
            using (var context = new PasswordResetContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                //insert feedback to db
                context.PasswordReset.Add(new PasswordResetTableModule
                {
                    householdEmail = householdEmail,
                    newPassword = newPassword,
                    confirmResetPassword = confirmPassword
                });

                // Saves changes
                // Save();
                context.SaveChanges();
            }


        }

        //when user request reset password (only store their email)
        public static void insertEmail(String householdEmail)
        {
            //declare that the data has been changed
            // db.Entry(obj).State = EntityState.Modified;
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
                // Save();
                context.SaveChanges();
            }


        }

        // public void Save()
        // {
        //     db.SaveChanges();
        // }

        public static void printData()
        {
            // Gets and prints all books in database
            using (var context = new PasswordResetContext())
            {

                var datas = context.PasswordReset;
                foreach (var data1 in datas)
                {
                    // var data = new StringBuilder();
                    var data = new StringBuilder();
                    data.AppendLine($"Id: {data1.passwordResetID}");
                    data.AppendLine($"Email: {data1.householdEmail}");
                    data.AppendLine($"Password: {data1.newPassword}");
                    data.AppendLine($"Password: {data1.confirmResetPassword}");
                    Console.WriteLine(data.ToString());
                    // Console.WriteLine(data.ToString());

                }
            }
        }

    }
}


using System;

using Project.Models;


using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.DataAnnotations;


namespace Project.Models
{

    public class NewPasswordResetContext : DbContext
    {

        //whatever we put in recordset passwordreset class is correspond to the database
        //recordset is a table datagatway , provide insert update delete 
         public DbSet<NewPasswordResetTableModule> NewPasswordReset { get; set; }

        //trying to connect to mysql
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseMySQL($"server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123");

        //feedback db table    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NewPasswordResetTableModule>(entity =>
            {
                entity.HasKey(e => e.newPasswordResetID);
                entity.Property(e => e.householdEmail).IsRequired();
                entity.Property(e => e.newResetPassword).IsRequired();
                entity.Property(e => e.confirmResetPassword).IsRequired();
            });
        }

    }
}

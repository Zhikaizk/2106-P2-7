using System;

using Project.Models;


using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.DataAnnotations;


namespace Project.Database
{

    public class PasswordResetContext : DbContext
    {

        public PasswordResetContext(DbContextOptions<PasswordResetContext> options) : base(options) { }


        //whatever we put in recordset passwordreset class is correspond to the database
        //recordset is a table datagatway , provide insert update delete 
        public DbSet<PasswordResetTableModule> PasswordReset { get; set; }

        //trying to connect to mysql
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseMySQL($"");

        //feedback db table    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PasswordResetTableModule>(entity =>
            {
                entity.HasKey(e => e.passwordResetID);
                entity.Property(e => e.householdEmail).IsRequired();
                entity.Property(e => e.newPassword).IsRequired();
                entity.Property(e => e.confirmPassword).IsRequired();
            });
        }

    }
}
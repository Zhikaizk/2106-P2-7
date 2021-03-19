using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

namespace Project.Models.DeleteInactive
{
    public class DeleteInactiveContext : DbContext
    {
        public DbSet<AccountDBAttr> Account { get; set; }
        public DbSet<AccountLogsDBAttr> AccountLogs { get; set; }
        public DbSet<HouseholdDBAttr> Household { get; set; }
        public DbSet<DeletedLogsDBAttr> DeletedLogs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;database=zk;user=root;password=qwerty123;port=3306");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Account table in Database
            modelBuilder.Entity<AccountDBAttr>(entity =>
            {
                entity.HasKey(e => e.idAccount);
                entity.Property(e => e.email).IsRequired();
            });

            //AccountLogs table in Database
            modelBuilder.Entity<AccountLogsDBAttr>(entity =>
            {
                entity.HasKey(e => e.idAccountLogs);
                entity.Property(e => e.lastLogin).IsRequired();
            });

            //Account table in Database
            modelBuilder.Entity<HouseholdDBAttr>(entity =>
            {
                entity.HasKey(e => e.email);
                entity.Property(e => e.username).IsRequired();
                entity.Property(e => e.hlocation).IsRequired();
                entity.Property(e => e.eplan).IsRequired();
                entity.Property(e => e.property_size).IsRequired();
                entity.Property(e => e.roomlist).IsRequired();
            });

            //DeletedLogs table in Database
            modelBuilder.Entity<DeletedLogsDBAttr>(entity =>
            {
                entity.HasKey(e => e.accountID);
                entity.Property(e => e.username).IsRequired();
                entity.Property(e => e.hlocation).IsRequired();
                entity.Property(e => e.eplan).IsRequired();
                entity.Property(e => e.property_size).IsRequired();
                entity.Property(e => e.roomlist).IsRequired();
                entity.Property(e => e.username).IsRequired();
                entity.Property(e => e.deleted_date).IsRequired();
                entity.Property(e => e.email).IsRequired();
                entity.Property(e => e.reason_for_deletion).IsRequired();
            });

        }


    }
}

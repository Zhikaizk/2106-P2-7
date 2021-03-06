using EFCoreMySQL.Models;  
using Microsoft.EntityFrameworkCore;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace EFCoreMySQL.DBContexts  
{  
    public class MyDBContext : DbContext  
    {  
        public DbSet<FeedbackDB> UserGroups { get; set; }   
  
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)  
        {   
        }  
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            // Use Fluent API to configure  
  
            // Map entities to tables  
            modelBuilder.Entity<FeedbackDB>().ToTable("FeedbackDB");   
  
            // Configure Primary Keys  
            modelBuilder.Entity<FeedbackDB>().HasKey(fDB => fDB.FeedbackId).HasName("FeedbackId"); 
  
            // Configure indexes  
  
            // Configure columns  
            modelBuilder.Entity<FeedbackDB>().Property(fDB => fDB.FeedbackId).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<FeedbackDB>().Property(fDB => fDB.HouseholdEmail).HasColumnType("varchar(100)").IsRequired();  
            modelBuilder.Entity<FeedbackDB>().Property(fDB => fDB.FeedabackType).HasColumnType("varchar(100)").IsRequired();  
            modelBuilder.Entity<FeedbackDB>().Property(fDB => fDB.FeedbackContent).HasColumnType("varchar(500)").IsRequired();  
            modelBuilder.Entity<FeedbackDB>().Property(fDB => fDB.FeedbackStatus).HasColumnType("varchar(100)").IsRequired();  
  
            // Configure relationships   
        }  
    }  
}  
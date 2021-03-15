using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace EFCoreSample
{
  public class FeedbackContext : DbContext
  {
    
    public DbSet<FeedbackDBAttr> Feedback { get; set; }

    //databse connection strings
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySQL($"server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;database=zk;user=root;password=qwerty123");

    //feedback db table    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<FeedbackDBAttr>(entity =>
      {
        entity.HasKey(e => e.feedbackId);
        entity.Property(e => e.feedbackType).IsRequired();
        entity.Property(e => e.feedbackStatus).IsRequired();
        entity.Property(e => e.householdEmail).IsRequired();
        entity.Property(e => e.feedbackContent).IsRequired();
      });
    }
  }
}
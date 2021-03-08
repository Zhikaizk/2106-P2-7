using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace EFCoreSample


{
  public class FeedbackContext : DbContext
  {
    
    public DbSet<FeedbackTableModule> Feedback { get; set; }

    //databse connection strings
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySQL($"");

    //feedback db table    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<FeedbackTableModule>(entity =>
      {
        entity.HasKey(e => e.FeedbackId);
        entity.Property(e => e.FeedbackType).IsRequired();
        entity.Property(e => e.FeedbackStatus).IsRequired();
        entity.Property(e => e.HouseholdEmail).IsRequired();
        entity.Property(e => e.FeedbackContent).IsRequired();
      });
    }
  }


}
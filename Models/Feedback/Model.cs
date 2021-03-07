using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace EFCoreSample
{
  public class FeedbackContext : DbContext
  {
    
    public DbSet<Feedback> Feedback { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySQL($"server=127.0.0.1;database=test;user=root;password=");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Feedback>(entity =>
      {
        entity.HasKey(e => e.FeedbackId);
        entity.Property(e => e.FeedbackType).IsRequired();
        entity.Property(e => e.FeedbackStatus).IsRequired();
        entity.Property(e => e.HouseholdEmail).IsRequired();
        entity.Property(e => e.FeedbackContent).IsRequired();
      });
    }
  }
  [MySqlCollation("latin1_spanish_ci")]
  public class Feedback
  {
    [MySqlCharset("latin1")]
    public string FeedbackContent { get; set; }
    public string HouseholdEmail { get; set; }
    public string FeedbackStatus { get; set; }
    public string FeedbackType { get; set; }
    public int FeedbackId { get; set; }
  }

}
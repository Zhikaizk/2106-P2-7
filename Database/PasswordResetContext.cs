using System;

using Project.Models;


using Microsoft.EntityFrameworkCore;


namespace Project.Database
{
    
public class PasswordResetContext : DbContext{

    public PasswordResetContext(DbContextOptions<PasswordResetContext> options) : base (options){}


//whatever we put in recordset passwordreset class is correspond to the database
//recordset is a table datagatway , provide insert update delete 
    public DbSet<PasswordResetModel> PasswordResetModel{get;set;}

}
}
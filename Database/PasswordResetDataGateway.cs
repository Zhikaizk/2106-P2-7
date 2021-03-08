
using Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project.Database
{
    //is a subset to the dbcontext
    public class PasswordResetDataGateway<T> : IPasswordResetDataGateway<T> where T : class 
    {
        internal PasswordResetContext db;
        internal DbSet<T> data = null;

            public PasswordResetDataGateway(PasswordResetContext context)
        {
            this.db = context;
            this.data = db.Set<T>();
        }

        // private PasswordResetDataGateway db = new PasswordResetDataGateway();
        public T SelectByHouseholdEmail(string? householdEmail)
        {
            return data.Find(householdEmail);
        }
        
        public void Update(T obj)
        {
            //declare that the data has been changed
            db.Entry(obj).State = EntityState.Modified;
            Save();
        }

        public void Save(){
            db.SaveChanges();
        }
         
    }
}


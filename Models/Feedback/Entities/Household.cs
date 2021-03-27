using System;
using System.Collections.Generic;
using Project.Models.Notification;

namespace Project.Models.Feedback
{
   public class Household: Account, IAccount
    {

        // list of attributes of household properties
        public string email { get ; set; }
        public int postalcode { get; set; } 
        public int property_size { get; set; }

        // attribute from Module 2
        //private ElectricityPlan();

        // constructor 
        public Household():base() { }
        public Household(string id, string name, string password, string role, string email, int hlocation, int property_size) : base(id, name, password, role)
      
        {
            this.id = id;
            this.email = email;
            this.postalcode = hlocation;
            this.property_size = property_size;
        }

    }

}


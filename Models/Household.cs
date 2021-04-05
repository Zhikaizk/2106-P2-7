using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_2106.Models
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
            this.email = email;
            this.postalcode = hlocation;
            this.property_size = property_size;
            this.password = password;
            this.id = id;
            this.name = name;
            this.role = role;


        }

        public string getEmail()
        {
            return email;
        }

    }
}

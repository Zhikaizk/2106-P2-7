using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_2106.Models
{
    public abstract class Account: IAccount
    {
        // list of attributes of account properties
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string role { get; set;  }
        // constructors
        public Account() { }
        public Account(string id, string name, string password, string role)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.role = role;
        }

        public string getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }

        public string getPassword()
        {
            return password;
        }
        public string getRole()
        {
            return role;
        }
    }
}

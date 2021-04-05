using System;
using System.Collections.Generic;
namespace ICT_2106.Models
{
    public class Admin: Account, IAccount
    {
        //private EmailNotification _emailNotification;  
        public String adminid { get; set; }
        public Admin()
        {
        }

        public Admin(string adminid)
        {
            // save the address for later
           this.adminid = adminid;
        }

    }
}

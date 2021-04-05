using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class InactiveUsers : IInactiveUsers
    {

        public DateTime lastActive { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int id { get; set; }
        public int inactivityPeriod { get; set; }
        public bool deleteChk { get; set; } = false; //by default will be set to false unless check box was checked to delete

        //constructor for inacive users
        public InactiveUsers()
        {

        }

        public InactiveUsers(DateTime lastActive, string username, string email, int id, int inactivityPeriod, bool deleteChk)
        {
            this.lastActive = lastActive;
            this.username = username;
            this.email = email;
            this.id = id;
            this.inactivityPeriod = inactivityPeriod;
            this.deleteChk = deleteChk;
        }


    }

    /*    public class DeletionLog : IInactiveUsers
        {
            public DateTime lastActive { get; set; }
            public string username { get; set; }
            public string email { get; set; }
            public int id { get; set; }
            public int inactivityPeriod { get; set; }
            public int hlocation { get; set; }
            public string eplan { get; set; }
            public int property_size { get; set; }
            public string roomlist { get; set; }
            public DateTime deleted_date { get; set; }

        }*/

 

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Delete
{
    public class InactiveUsers
    {
        public DateTime lastActive { get; set; }
        public string username { get; set; }
        public string id { get; set; }
        public int inactivityPeriod { get; set; }
        public bool deleteChk{ get; set; } = false; //by default will be set to false unless check box was checked to delete


    }
    public class InactiveUsersList{
        public List<InactiveUsers> InactiveU{get ; set; }
    }

}

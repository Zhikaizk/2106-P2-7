using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class Household : IHousehold
    {
        public string email { get; set; }
        public string username { get; set; }
        public int hlocation { get; set; }
        public string eplan { get; set; }
        public int property_size { get; set; }
        public string roomlist { get; set; }
        
        public Household()
        {

        }

        public Household(string email, string username, int hlocation, string eplan, int property_size, string roomlist)
        {
            this.email = email;
            this.username = username;
            this.hlocation = hlocation;
            this.eplan = eplan;
            this.property_size = property_size;
            this.roomlist = roomlist;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_2106.Models
{
    public interface IAccount
    {
        public string getId();
        public string getName();
        public string getPassword();
        public string getRole();
        
    }
}

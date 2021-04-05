using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_2106.Models
{
    public class AccountFactory
    {
        public static Account createAccount(string[] data)
        {
            if(data[0] == "household")
            {
                Household h = new Household(data[1], data[2], data[4], data[0], data[3], int.Parse(data[5]), int.Parse(data[6]));
                Console.WriteLine(h.getId());
                  Console.WriteLine("nth");
                return h;
            }
            else if(data[0] == "admin")
            {
                return new Household();
            }
            return null;
        }

        
    }
}

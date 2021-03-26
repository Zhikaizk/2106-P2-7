using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class HouseholdTDG
    {

        public static string retrieveUsernameFromEmail(String email)
        {
            //get Household username by email
            using (var context = new DeleteInactiveContext())
            {

                var datas = context.Household
                           .Where(s => s.email == email)
                           .FirstOrDefault();

                return datas.username;

            }

        }

        public static Household retrieveHouseholdfromEmail(String email)
        {
            //get Household username by email
            using (var context = new DeleteInactiveContext())
            {

                Household h = new Household();

                var dataset = context.Household
                           .Where(s => s.email == email)
                           .FirstOrDefault();

                h.email = dataset.email;
                h.username = dataset.username;
                h.eplan = dataset.eplan;
                h.hlocation = dataset.hlocation;
                h.property_size = dataset.property_size;
                h.roomlist = dataset.roomlist;

                return h;

            }

        }
    }
}

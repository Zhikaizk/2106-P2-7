using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class AccountLogsTDG
    {
        public static DateTime retrieveLastLoginFromEmail(int idAccount)
        {
            //get Household username by email
            using (var context = new DeleteInactiveContext())
            {

                var dataset = context.AccountLogs
                           .Where(s => s.idAccountLogs == idAccount)

                           .FirstOrDefault();

                return dataset.lastLogin;

            }

        }
    }
}

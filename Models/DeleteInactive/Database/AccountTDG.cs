using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class AccountTDG
    {
        public static List<AccountDBAttr> retrieveAccounts()
        {
            //get Household username by email
            using (var context = new DeleteInactiveContext())
            {
                List<AccountDBAttr> accList = new List<AccountDBAttr>();

                var dataset = context.Account;

                foreach (var data in dataset)
                {
                    AccountDBAttr tempAcc = new AccountDBAttr();
                    tempAcc.email = data.email;
                    tempAcc.idAccount = data.idAccount;
                    accList.Add(tempAcc);
                }

                return accList;

            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class DeleteInactiveControl
    {
        public DeleteInactiveControl(){
            //constructor
            // this.btn = button;
            

        }
        public List<InactiveUsers> populateInactiveModel(){

            //temp made this hardcoded for now.
            //Later will connect to database to store into the model

            List<InactiveUsers> iU = new List<InactiveUsers>();

            List<AccountDBAttr> accountList = AccountTDG.retrieveAccounts();

            foreach (var acc in accountList)
            {

                InactiveUsers temp = new InactiveUsers();
                temp.id = acc.idAccount;
                temp.inactivityPeriod = calcInactiveDays(AccountLogsTDG.retrieveLastLoginFromEmail(acc.idAccount));
                temp.lastActive = AccountLogsTDG.retrieveLastLoginFromEmail(acc.idAccount);
                temp.username = HouseholdTDG.retrieveUsernameFromEmail(acc.email);

                iU.Add(temp);
            }

            return iU;
        }

        public int calcInactiveDays(DateTime date){
            //get current date
            DateTime currentDate = DateTime.Now;  
            //return number of days in int
            return (currentDate - date).Days;
        }

        public bool checkIfInactive(int inactDays){
            //if more than 200 inactive days then display as inactive user for admin to delete
            if(inactDays>200)
            {return true;}
            else
            {return false;}
        }

        public InactiveUsersList deleteAccount(InactiveUsersList inactUsersList){

            //will change return type to bool to show success or failed
            InactiveUsersList temp = inactUsersList;
            int indexTrack = 0;
            for(int i =0; i< inactUsersList.InactiveU.Count; i++){
                if(inactUsersList.InactiveU[i].deleteChk == true){
                    temp.InactiveU.RemoveAt(indexTrack);
                    indexTrack++;
                }
                indexTrack++;
            }
            return temp;

        }




    }
}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class DeleteInactiveControl
    {


        private List<InactiveUsers> iU = new List<InactiveUsers>();

        private DeleteInactiveTDG delTDG = new DeleteInactiveTDG();

        public DeleteInactiveControl()
        {
            //constructor
            // this.btn = button;


        }

        public List<InactiveUsers> populateInactiveModel()
        {

            //temp made this hardcoded for now.
            //Later will connect to database to store into the model
            int days = 180;

            DateTime startOfInactiveDays = getStartOfInactiveDate(days);

            iU = delTDG.findInactiveUsers(startOfInactiveDays);


            foreach (var usr in iU)
            {
                //calculate and set inactivity period
                usr.inactivityPeriod = calcInactiveDays(usr.lastActive);
            }

            return iU;
        }

        public int calcInactiveDays(DateTime date)
        {
            //get current date
            DateTime currentDate = DateTime.Now;
            //return number of days in int
            return (currentDate - date).Days;
        }

        public DateTime getStartOfInactiveDate(int days)
        {
            DateTime currentDate = DateTime.Now;
            DateTime dateConsideredInactive = currentDate.AddDays(-days);

            return dateConsideredInactive;
        }

        /*        public bool checkIfInactive(int inactDays){
                    //if more than 200 inactive days then display as inactive user for admin to delete
                    if(inactDays>200)
                    {return true;}
                    else
                    {return false;}
                }*/

        public InactiveUsersList deleteAccount(InactiveUsersList inactUsersList)
        {

            //will change return type to bool to show success or failed

            InactiveUsersList updateInactiveUserList = new InactiveUsersList();
            updateInactiveUserList.InactiveU = iU;


            int indexTrack = 0;//for tracking the index once deleted

            if(inactUsersList.InactiveU != null)
            {
                updateInactiveUserList = inactUsersList;
                for (int i = 0; i < inactUsersList.InactiveU.Count; i++)
                {
                    //checking which were selected to delete
                    if (inactUsersList.InactiveU[i].deleteChk == true)
                    {
                        //get household info for each
                        IHousehold householdInfo = new Household();
                        householdInfo = delTDG.findHouseholdInfo(inactUsersList.InactiveU[i].email);


                        DateTime currentDate = DateTime.Now;

                        //create new deleteLog
                        DeletedHouseholdLogs delLog = new DeletedHouseholdLogs();
                        delLog.accountID = inactUsersList.InactiveU[i].id;
                        delLog.email = householdInfo.email;
                        delLog.username = householdInfo.username;
                        delLog.hlocation = householdInfo.hlocation;
                        delLog.eplan = householdInfo.eplan;
                        delLog.property_size = householdInfo.property_size;
                        delLog.roomlist = householdInfo.roomlist;
                        delLog.deleted_date = currentDate;
                        delLog.reason_for_deletion = "Account has been inactive for more than 6 months and hence has been Deleted";

                        //add deleteLog to database
                        delTDG.insertDeleteLog(delLog);

                        //remove InactiveUsers by index
                        updateInactiveUserList.InactiveU.RemoveAt(indexTrack);
                        indexTrack++;
                    }
                    indexTrack++;
                }
            }

            return updateInactiveUserList;

        }




    }
}

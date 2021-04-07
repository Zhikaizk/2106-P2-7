



using Project.Models.Notification;
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

        private IEmail emailAccess;

        public DeleteInactiveControl()
        {
            //constructor
            // this.btn = button;


        }

        public List<InactiveUsers> populateInactiveModel()
        {

            int days = 180;//180 days is 6 months

            DateTime startOfInactiveDays = getStartOfInactiveDate(days);

            iU = delTDG.findInactiveUsers(startOfInactiveDays);


            foreach (var usr in iU)
            {
                //calculate and set inactivity period
                usr.inactivityPeriod = calcInactiveDays(usr.lastActive);
            }

            return iU;
        }

        public List<DeletedHouseholdLogs> populateDeletedLogsView()
        {

            return delTDG.findDeletedLogs();
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
                        DeletedHouseholdLogs delLog = new DeletedHouseholdLogs(
                            inactUsersList.InactiveU[i].id,
                            householdInfo.email,
                            householdInfo.username,
                            householdInfo.hlocation,
                            householdInfo.eplan,
                            householdInfo.property_size,
                            householdInfo.roomlist,
                            currentDate,
                            "Account has been inactive for more than 6 months and hence has been Deleted");


                        //add deleteLog to database
                        delTDG.insertDeleteLog(delLog);

                        //sending email to user about account deletion 
                        this.emailAccess = new Email(householdInfo.email);
                        emailAccess.Update("Account Inactive deletion", "Hi there "+ householdInfo.username + ", this email is to notify you that your Acount was deleted due to inactivity for more than 6 months. last login was on the "
                            + inactUsersList.InactiveU[i].lastActive.ToString() + ". Please email Smart Home Management System help team at help@SHMS.com.sg for reactivating account.");

                        EmailNotification notification = new EmailNotification();
                        notification.Attach(emailAccess);
                        notification.NotifyObservers();


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

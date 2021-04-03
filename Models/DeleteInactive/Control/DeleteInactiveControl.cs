



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class DeleteInactiveControl
    {


        private List<InactiveUsers> iU = new List<InactiveUsers>();
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

            DeleteInactiveTDG delTDG = new DeleteInactiveTDG();

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
            InactiveUsersList temp = inactUsersList;
            int indexTrack = 0;
            for (int i = 0; i < inactUsersList.InactiveU.Count; i++)
            {
                if (inactUsersList.InactiveU[i].deleteChk == true)
                {
                    //checking which were selected to delete
                    temp.InactiveU.RemoveAt(indexTrack);
                    indexTrack++;
                }
                indexTrack++;
            }
            return temp;

        }




    }
}

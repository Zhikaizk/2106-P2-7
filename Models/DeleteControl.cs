using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Delete
{
    public class DeleteControl
    {
        public DeleteControl(){
            //constructor
            // this.btn = button;
            

        }
        public List<InactiveUsers> populateInactiveModel(){

            //temp made this hardcoded for now.
            //Later will connect to database to store into the model

            DateTime date1 = new DateTime(2011, 6, 10);

            InactiveUsers d1 = new InactiveUsers();
            d1.id = "1a";
            d1.inactivityPeriod = calcInactiveDays(date1);
            d1.lastActive = date1;
            d1.username = "Test1";

            InactiveUsers d2 = new InactiveUsers();
            d2.id = "1b";
            d2.inactivityPeriod = calcInactiveDays(date1);
            d2.lastActive = date1;
            d2.username = "Test2";

            InactiveUsers d3 = new InactiveUsers();
            d3.id = "1c";
            d3.inactivityPeriod = calcInactiveDays(date1);
            d3.lastActive = date1;
            d3.username = "Test3";

            List<InactiveUsers> iU = new List<InactiveUsers>();
            iU.Add(d1);
            iU.Add(d2);
            iU.Add(d3);
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

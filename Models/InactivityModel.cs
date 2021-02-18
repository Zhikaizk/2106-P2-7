using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Delete
{
    public class InactivityModel
    {
        private IList<DeleteModel> InactivityList {get; set;}

        public void LoadInactivityList()
        {
            //get data through for loop and store in this model of models
            this.InactivityList = new List<DeleteModel>();
            // here will be adding a list

            
            /*this.InactivityList.Add('11/22/2021',"","",10,false);    */                                                                                                                                                                                                                                   
        }
    }
}                                                                     
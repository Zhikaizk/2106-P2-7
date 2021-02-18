using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Delete
{
    public class DeleteModel
    {
        private DateTime lastActive { get; set; }
        private string username { get; set; }
        private string id { get; set; }
        private int inactivityPeriod { get; set; }
        private bool Delete { get; set; } = false; //by default will be set to false unless they decide to delete


    }

}

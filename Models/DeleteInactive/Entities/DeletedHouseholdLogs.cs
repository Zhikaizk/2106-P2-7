using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive
{
    public class DeletedHouseholdLogs
    {
        public int accountID { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public int hlocation { get; set; }
        public string eplan { get; set; }
        public int property_size { get; set; }
        public string roomlist { get; set; }
        public DateTime deleted_date { get; set; }
        public string reason_for_deletion { get; set; }
    }
}

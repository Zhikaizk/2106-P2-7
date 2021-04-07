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

        DeletedHouseholdLogs()
        {

        }

        public DeletedHouseholdLogs(int accountID, string email, string username, int hlocation, string eplan, int property_size, string roomlist, DateTime deleted_date, string reason_for_deletion)
        {
            this.accountID = accountID;
            this.email = email;
            this.username = username;
            this.hlocation = hlocation;
            this.eplan = eplan;
            this.property_size = property_size;
            this.roomlist = roomlist;
            this.deleted_date = deleted_date;
            this.reason_for_deletion = reason_for_deletion;
        }

    }
}

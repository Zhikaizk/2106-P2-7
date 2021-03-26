using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DeleteInactive.Database
{
    public class DeletedLogsTDG
    {
        public static void insertDeletedLogs(int idDeletedLogs, int accountID, string username, string email, int hlocation, string eplan, int property_size, string roomlist, DateTime deleted_date, string reason_for_deletion)
        {
            using (var context = new DeleteInactiveContext())
            {

                //insert deleted logs to db
                context.DeletedLogs.Add(new DeletedLogsDBAttr
                {
                    accountID = accountID,
                    email = email,
                    username = username,
                    deleted_date = deleted_date,
                    hlocation = hlocation,
                    eplan = eplan,
                    property_size = property_size,
                    roomlist = roomlist,
                    reason_for_deletion = reason_for_deletion

                });

                // Saves changes
                context.SaveChanges();
            }


        }
    }
}

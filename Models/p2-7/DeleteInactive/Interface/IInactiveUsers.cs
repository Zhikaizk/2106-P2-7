using System;

namespace Project.Models.DeleteInactive
{
    public interface IInactiveUsers
    {
        int id { get; set; }
        DateTime lastActive { get; set; }
        string username { get; set; }
        string email { get; set; }
        int inactivityPeriod { get; set; }
        bool deleteChk { get; set; }  //by default will be set to false unless check box was checked to delete
    }
}
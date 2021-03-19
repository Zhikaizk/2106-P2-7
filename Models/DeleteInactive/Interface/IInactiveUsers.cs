using System;

namespace Project.Models.DeleteInactive
{
    public interface IInactiveUsers
    {
        int id { get; set; }
        int inactivityPeriod { get; set; }
        DateTime lastActive { get; set; }
        string username { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Project.Database{

    interface IPasswordResetDataGateway<T> where T:class{
        
        // IEnumerable<T> SelectAll();
        T SelectByHouseholdEmail(string? householdEmail);
        void Save();
        void insert(T obj);
    }

}
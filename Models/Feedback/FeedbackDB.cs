using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace EFCoreMySQL.Models  
{  
    public class FeedbackDB 
    {  
        public int FeedbackId { get; set;}  
        public string HouseholdEmail { get; set;}  
        public string FeedabackType { get; set;}  
        public string FeedbackContent { get; set;}  
         public string FeedbackStatus { get; set;}  
    }  
}  
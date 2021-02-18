using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.PasswordReset;

namespace Project.Models.PasswordReset
{
    public class PasswordResetControl   
    {  
        private bool buttonStatus;

        private string requestLink;

//admin to check if there is any customer requesting 
        public bool requestPasswordResetButton(){
            if(buttonStatus == true){
                return true ;
            }
            else{
                return false;
            }
        }
//upload link
        public string link(){
            return "link";
        }

}  
}
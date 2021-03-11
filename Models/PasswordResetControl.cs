using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.PasswordReset;
using Project.Database;

namespace Project.Models.PasswordReset
{
    public class PasswordResetControl
    {
        private bool buttonStatus;

        private string requestLink;

        private string householdEmail;

        //admin to check if there is any customer requesting 
        public bool requestPasswordResetButton()
        {
            if (buttonStatus == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //upload link
        public string link()
        {
            return "link";
        }

        //user click on the request button
        public PasswordResetControl(String householdEmail)
        {

            //querying db
            PasswordResetDataGateway.insertEmail(householdEmail);
            this.householdEmail = householdEmail;

        }

    }
}
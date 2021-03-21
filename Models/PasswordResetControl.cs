using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.PasswordReset;

namespace Project.Models.PasswordReset
{
    public class PasswordResetControl
    {
        private string householdEmail;
        private string newResetPassword;
        private string confirmResetPassword;
        private string retrieveHouseholdEmail;

        //user click on the request button
        public PasswordResetControl(String householdEmail)
        {
            //querying db
            PasswordResetTDG.insertEmail(householdEmail);
            this.householdEmail = householdEmail;
        }

        //user click on the submit reset password button
        public PasswordResetControl(String householdEmail, String newResetPassword, String confirmResetPassword)
        {
            //querying db
            PasswordResetTDG.insert(householdEmail, newResetPassword, confirmResetPassword);
            this.householdEmail = householdEmail;
            this.newResetPassword = newResetPassword;
            this.confirmResetPassword = confirmResetPassword;
        }

//to retrieve through the console
        // public PasswordResetControl()
        // {
        //     PasswordResetTDG.find();
        //     retrieveHouseholdEmail = householdEmail;
        // }
    }
}
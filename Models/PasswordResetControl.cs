using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.PasswordReset;

namespace Project.Models.PasswordReset
{
    public class PasswordResetControl
    {
        private string householdEmail;
        private string newPassword;
        private string confirmResetPassword;

        //user click on the request button
        public PasswordResetControl(String householdEmail)
        {
            //querying db
            PasswordResetDataGateway.insertEmail(householdEmail);
            this.householdEmail = householdEmail;

        }

        //user click on the submit reset password button
        public PasswordResetControl(String householdEmail, String newPassword, String confirmResetPassword)
        {
            //querying db
            PasswordResetDataGateway.insert(householdEmail, newPassword, confirmResetPassword);
            this.householdEmail = householdEmail;
            this.newPassword = newPassword;
            this.confirmResetPassword = confirmResetPassword;
        }
    }
}
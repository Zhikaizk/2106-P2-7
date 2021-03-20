using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class PasswordResetModel
    {

        private string newPassword;

        private string getNewPassword(){
            return this.newPassword;
        }
        private void setNewPassword(string newPassword){
            this.newPassword = newPassword;
        }
        private string confirmResetPassword;

        private string getConfirmResetPassword(){
            return this.confirmResetPassword;
        }

        private void setConfirmResetPassword(string confirmResetPassword){
            this.confirmResetPassword = confirmResetPassword;
        }
        private string householdEmail{get;set;}

        private string getHouseholdEmail(){
            return this.householdEmail;
        }
        private void setHouseholdEmail(string householdEmail){
            this.householdEmail = householdEmail;
        }

        public void insertModifiedPassword(string householdEmail,string newResetPassword , string confirmResetPassword){
            setHouseholdEmail(householdEmail);
            setNewPassword(newResetPassword);
            setConfirmResetPassword(confirmResetPassword);
        }

        public void insertHouseholdEmail(string householdEmail){
            setHouseholdEmail(householdEmail);
        }
    }
}
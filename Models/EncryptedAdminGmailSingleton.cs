using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.Notification;

namespace Project.Models.Notification
{



public class EncryptedAdminGmailSingleton {

   //create an object of SingleObject        // the sole instance of this class
        private static EncryptedAdminGmailSingleton instance = null;
        private string adminGmail =null;
        private string decryptedPassword =null;

        private Decryption decryptingObject = new Decryption();

        // constructor - note that it is declared private so that only this class can instantiate itself
        private EncryptedAdminGmailSingleton()
        {
            // nothing to do
        }

        // get a reference to the sole instance of this class, creating it if necessary
        public static EncryptedAdminGmailSingleton GetInstance()
        {
            if (instance == null)
                instance = new EncryptedAdminGmailSingleton();

            return instance;
        }

   public String decryptedpasswordDone(){

       return decryptedPassword;
     
   }
      public void decryptedpasswordStart(string encryptedpassword){
       decryptingObject.decryptionPerformed(encryptedpassword);
       
       
     
   }
}
}
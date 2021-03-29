using System;
using System.Collections.Generic;
using Project.Models; 
using System.Security.Cryptography;
using System.Text; 
namespace Project.Models
{
 
 public class Decryption : IDecryption  
 {
     private bool decryptedbefore = false;
     private String decryptedPassword = null;

     public Decryption(){}

     public String resultofSecurity(){
         if( decryptedbefore == true){
             return "Decrypted";
         }else{
             return "Not Decrypted";
         }

     }

     public String decryptionPerformed(string password){
            byte[] inputArray = Convert.FromBase64String("");  
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();  
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(password);  
            tripleDES.Mode = CipherMode.ECB;  
            tripleDES.Padding = PaddingMode.PKCS7;  
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();  
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);  
            tripleDES.Clear();   
           // decryptedbefore == true
            return UTF8Encoding.UTF8.GetString(resultArray);  


     }






 }
}
using System;
using System.Collections.Generic;
using Project.Models; 
using System.Security.Cryptography;
using System.Text; 

using System.IO;
namespace Project.Models
{
 
 public class Encryption : IEncryption  
 {
     private bool decryptedbefore = false;
     private String decryptedPassword = null;

     public Encryption(){}

     public String resultofSecurity(){
         if( decryptedbefore == true){
             return "Decrypted";
         }else{
             return "Not Decrypted";
         }

     }

        public String encryptionPerformed(string password){
 try {  
  string textToEncrypt = password;  
  string ToReturn = "";  
  string publickey = "santhosh";  
  string secretkey = "engineer";  
  byte[] secretkeyByte = {};  
  secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);  
  byte[] publickeybyte = {};  
  publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);  
  MemoryStream ms = null;  
  CryptoStream cs = null;  
  byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);  
  using(DESCryptoServiceProvider des = new DESCryptoServiceProvider()) {  
   ms = new MemoryStream();  
   cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);  
   cs.Write(inputbyteArray, 0, inputbyteArray.Length);  
   cs.FlushFinalBlock();  
   ToReturn = Convert.ToBase64String(ms.ToArray());  
  }  
  return ToReturn;  
 } catch (Exception ex) {  
  throw new Exception(ex.Message, ex.InnerException);  
 }  
     }






 }
}
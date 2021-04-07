using System;
using System.Collections.Generic;
using Project.Models; 
using System.Security.Cryptography;
using System.Text;
using System.IO;

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

     public String decryptionPerformed(string encryptedpassword){
 try {  
  string textToDecrypt = encryptedpassword;  
  string ToReturn = "";  
  string publickey = "santhosh";  
  string privatekey = "engineer";  
  byte[] privatekeyByte = {};  
  privatekeyByte = System.Text.Encoding.UTF8.GetBytes(privatekey);  
  byte[] publickeybyte = {};  
  publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);  
  MemoryStream ms = null;  
  CryptoStream cs = null;  
  byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];  
  inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));  
  using(DESCryptoServiceProvider des = new DESCryptoServiceProvider()) {  
   ms = new MemoryStream();  
   cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);  
   cs.Write(inputbyteArray, 0, inputbyteArray.Length);  
   cs.FlushFinalBlock();  
   Encoding encoding = Encoding.UTF8;  
   ToReturn = encoding.GetString(ms.ToArray());  
  }  
  decryptedbefore= true;
  decryptedPassword = ToReturn;
  Console.WriteLine(decryptedPassword+" OVERHERELA");
  return ToReturn;  
 } catch (Exception ae) {  
  throw new Exception(ae.Message, ae.InnerException);  
 }  
     }






 }
}
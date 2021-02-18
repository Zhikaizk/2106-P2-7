using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models; 
using System.Security.Cryptography;
using System.Text; 
 

  namespace Project.Controllers
        {
             public class LoginManagementControl : ILoginManagement {
//                 public LoginManagementControl(string UserName, string Password){
//  if (ModelState.IsValid)
//             {
//                 DBEntity db = new DBEntity();
//                 var user = (from userlist in db.tblUsers
//                             where userlist.UserName == login.UserName && userlist.Password == login.Password
//                             select new
//                             {
//                                 userlist.UserID,
//                                 userlist.UserName
//                             }).ToList();
//                 if (user.FirstOrDefault() != null)
//                 {
//                     Session["UserName"] = user.FirstOrDefault().UserName;
//                     Session["UserID"]=user.FirstOrDefault().UserID;
//                     return Redirect("/home/welcomepage");
//                 }
//                 else
//                 {
//                     ModelState.AddModelError("", "Invalid login credentials.");
//                 }
//             }
//             return View(login);
//         }

        //To encypt the data to protect information
        private static string Encrypt(string username, string password)  
        {  
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(username);  
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();  
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(password);  
            tripleDES.Mode = CipherMode.ECB;  
            tripleDES.Padding = PaddingMode.PKCS7;  
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();  
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);  
            tripleDES.Clear();  
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);  
        } 
         //To decrypt the data if needed
        private static string Decrypt(string username, string password)  
        {  
            byte[] inputArray = Convert.FromBase64String(username);  
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();  
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(password);  
            tripleDES.Mode = CipherMode.ECB;  
            tripleDES.Padding = PaddingMode.PKCS7;  
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();  
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);  
            tripleDES.Clear();   
            return UTF8Encoding.UTF8.GetString(resultArray);  
        }  
    }
                }
            
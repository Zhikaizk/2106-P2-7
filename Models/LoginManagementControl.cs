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
using ICT_2106.Models;
 

  namespace Project.Controllers
        {
             public class LoginManagementControl  {

                 private String typeofaccess;



                 public LoginManagementControl(String enteredusername,String enteredpassword){
                 
                LoginTDG testing = new LoginTDG();
                // array of string of details
                List<String> Details=testing.find(enteredusername,enteredpassword);
                String[] str = Details.ToArray();
                AccountFactory factory = new AccountFactory();
                Account type=AccountFactory.createAccount(str);
                Console.WriteLine(type.getRole().ToString());
                if(type.getRole().ToString() =="household"){
                    typeofaccess = "household";
                }
                else{
                    typeofaccess = "admin";
                }
                 }

                 public string Accounttype(){
                     return typeofaccess;
                 }









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

         /*
        // Call function from Nodule 1 Team4. Whether pass or fail, will log in the account information
        public createLogDB(int h_id, string actionname, string ipaddress, DateTime timestamp){

        }

        // Call function from Module 1 Team 4. If the login fail, will validate the account
        public validateAccount(int h_id)

        */
    }
                }
            
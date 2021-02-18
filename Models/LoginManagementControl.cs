using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models; 
 

  namespace Project.Controllers
        {
//             public class LoginManagementControl : ILoginManagement {
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
//                 }
            }
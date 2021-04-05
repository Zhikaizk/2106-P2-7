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
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            // login function
            return View();
        }

               
         [HttpPost]
        public ActionResult Login(LoginModel model)
        {
        LoginManagementControl logincontrol = new LoginManagementControl(model.UserName.ToString(),model.Password.ToString());
        String accounttype = logincontrol.Accounttype();
        if(accounttype == "household"){
        return View("~/Views/Household/Home.cshtml"); // astra page here
        }else{
        return View("~/Views/Home/Index.cshtml"); // our page here
        }
        }
       
    }
}
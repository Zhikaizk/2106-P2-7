using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using Project.Models.PasswordResetModel;

namespace Project.Controllers.PasswordResetController
{
    public class PasswordResetController : Controller
    {
        private readonly ILogger<PasswordResetController> _logger;

        public PasswordResetController(ILogger<PasswordResetController> logger)
        {
            _logger = logger;
        }

    //get the passwordreset

        [HttpGet]
        public ActionResult PasswordReset()
        {
            return View();
        }

        //check the credentials
        [HttpPost]
        // public ActionResult PasswordReset(PasswordResetModel obj){

        //     int userID = Convert.ToInt32(Session["User ID"]);
        //     User user = db.User.Find(ID);

        //     if (User.password == obj.oldPassword){

        //     }


        //     return View()
            
        // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}

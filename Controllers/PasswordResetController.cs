using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Web;
using Project.Models.PasswordReset;
using System.Collections.Generic;
using System.Threading.Tasks;

using Project.Models.Notification;


//added new things to try to fetch data 
using MySql.Data.MySqlClient;
//ends here 

namespace Project.Controllers
{
    public class PasswordResetController : Controller
    {

        private readonly ILogger<PasswordResetController> _logger;

        public PasswordResetController(ILogger<PasswordResetController> logger)
        {
            _logger = logger;
        }


        //get the passwordreset
        public IActionResult passwordReset()
        {
            return View();
        }

        //get the new password
        public ActionResult resetPasswordPage()
        {
            return View();
        }

        // GET: 
        [HttpGet]
        public ActionResult edit(String householdEmail)
        {
            return View();
        }

        public ActionResult edit(PasswordResetModel passwordResetModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("PasswordReset");
            }
            return View(passwordResetModel);
        }

        //check the credentials
        [HttpPost]
        public ActionResult passwordReset(PasswordResetModel objPasswordResetModel, String householdEmail)
        {
            String email = householdEmail;
            Console.WriteLine(email);

            //addede this viewbag is alert message , modelstate is to validate that the email filled validation meets the requirement at the model
            ViewBag.Message = "Successsfully requested reset password";

            PasswordResetControl pw = new PasswordResetControl(householdEmail);
            return View();
        }

  

        //check the credentials
        [HttpPost]
        public ActionResult resetPasswordPage(PasswordResetModel objPasswordResetModel, String householdEmail, String newResetPassword, String confirmResetPassword,String householdPassword)
        {
            String email = householdEmail;
            String newPassword = newResetPassword;
            String confirmNewResetPassword = confirmResetPassword;

            Console.WriteLine(email);
            Console.WriteLine(newPassword);
            Console.WriteLine(confirmNewResetPassword);

            //trying to update household password
            householdPassword = newPassword;
            Console.WriteLine(email + "under the update password email");
            Console.WriteLine(newPassword + "under update password password" );

            //addede this viewbag is alert message , modelstate is to validate that the email filled validation meets the requirement at the model
            ViewBag.Message = "Successsfully reset new password";

            PasswordResetControl pw = new PasswordResetControl(householdEmail, newResetPassword, confirmResetPassword);

            //trying to update password at household account db
            PasswordResetControl pw1 = new PasswordResetControl(householdEmail, householdPassword);
            return View();
        }
    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

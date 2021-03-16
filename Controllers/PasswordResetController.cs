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

namespace Project.Controllers
{
    public class PasswordResetController : Controller
    {
        //newly added to test on retrieve of data
        PasswordResetContext dbObj = new PasswordResetContext(); 
        //-----

        private readonly ILogger<PasswordResetController> _logger;

        public PasswordResetController(ILogger<PasswordResetController> logger)
        {
            _logger = logger;
        }

        //route after admin click on the send email

        public string url(string householdEmail){
            return HttpUtility.HtmlEncode("Email have been send out");

        }

        // update the password GET PasswordReset/requestPassword

        // public ActionResult Edit(string? householdEmail){
        //     if (householdEmail == null){
        //         return RedirectToAction(nameof(PasswordReset));
        //     }
        //     return View();

        // }


        //get the passwordreset
        public IActionResult passwordReset()
        {
            return View();
        }

        // GET: 
        [HttpGet]
        public ActionResult edit(String householdEmail)
        {
            // PasswordResetContext db  = new PasswordResetContext();
            // PasswordResetModel pwdreset = db.PasswordResetModel.Single(x=> x.householdEmail == householdEmail);
            // return View(pwdreset);
            return View();
        }


        // //update the household password
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit([Bind("resetPassword")]
        //  PasswordResetModel passwordResetModel)
        //  {
        //     if (ModelState.IsValid){
        //         passwordResetDataGateway.Update(passwordResetModel);
        //         return RedirectToAction("resetPasswordPage");
        //     }
        //     return View(passwordResetModel);
        // }
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

        //newly added
        public ActionResult resetPasswordPage()
        {
            return View();
        }

                //check the credentials
        [HttpPost]
        public ActionResult resetPasswordPage(PasswordResetModel objPasswordResetModel, String householdEmail, String newPassword, String confirmResetPassword)
        {
            String email = householdEmail;
            String newResetPassword = newPassword;
            String confirmNewResetPassword = confirmResetPassword;
            Console.WriteLine(email,newResetPassword,confirmNewResetPassword);
            Console.WriteLine(newResetPassword);
            Console.WriteLine(confirmNewResetPassword);
    
            //addede this viewbag is alert message , modelstate is to validate that the email filled validation meets the requirement at the model
            ViewBag.Message = "Successsfully reset new password";

            PasswordResetControl pw = new PasswordResetControl(householdEmail,newPassword,confirmResetPassword);
            return View();
        }

        public IActionResult adminPasswordResetPage()
        {
            var res= dbObj.PasswordReset.ToList();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

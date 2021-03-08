using System;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using Project.Database;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Linq; 

namespace Project.Controllers
{
    public class PasswordResetController : Controller
    {
        private PasswordResetDataGateway<PasswordResetModel> passwordResetDataGateway; 
        private readonly ILogger<PasswordResetController> _logger;

        public PasswordResetController(ILogger<PasswordResetController> logger)
        {
            _logger = logger;
        }

// update the password GET PasswordReset/requestPassword

        // public ActionResult Edit(string? householdEmail){
        //     if (householdEmail == null){
        //         return RedirectToAction(nameof(PasswordReset));
        //     }
        //     return View();

        // }


        //get the passwordreset

        [HttpGet]
        public ActionResult PasswordReset()
        {
            //old
            return View();
        }

        // GET: 
        [HttpGet]
        public ActionResult Edit(String householdEmail)
        {
            // PasswordResetContext db  = new PasswordResetContext();
            // PasswordResetModel pwdreset = db.PasswordResetModel.Single(x=> x.householdEmail == householdEmail);
            // return View(pwdreset);
            return View();
        }


        // //update the household password
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public ActionResult Edit([Bind("resetPassword")]
        //  PasswordResetModel passwordResetModel)
        //  {
        //     if (ModelState.IsValid){
        //         passwordResetDataGateway.Update(passwordResetModel);
        //         return RedirectToAction("resetPasswordPage");
        //     }
        //     return View(passwordResetModel);
        // }
       public ActionResult Edit(PasswordResetModel passwordResetModel)
        {
            if (ModelState.IsValid){
                // PasswordResetContext db = new PasswordResetContext();
                // db.Entry(passwordResetModel).State = EntityState.Modified();
                // db.SaveChanges();
                return RedirectToAction("PasswordReset");
            }
            return View(passwordResetModel);
        }


        //save the household password
        [HttpPost]
        // [ValidateAntiForgeryToken]



        //check the credentials
        [HttpPost]
        public ActionResult PasswordReset(PasswordResetModel objPasswordResetModel){
            //addede this viewbag is alert message , modelstate is to validate that the email filled validation meets the requirement at the model
            ViewBag.Message="Successsfully requested reset password";

            if (ModelState.IsValid){
            }
            else{
            }
            return View();
        }

        //encrypt password
        // public static string EncodePassword(string newPassword)
        // {
        //     try
        //     {
        //         byte[] encData_byte = new byte[newPassword.Length];
        //         encData_byte = System.Text.Encoding.UTF8.GetBytes(newPassword);
        //         string encodedData = Convert.ToBase64String(encData_byte);
        //         return encodedData;
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception("Error in base64Encode" + ex.Message);
        //     }
        // }

        // protected void resetPasswordButton(object sender, EventArgs e)
        // {
        //     PasswordReset.Text = EncodePassword(TextBox1.Text);
        // }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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

        //encrypt password
        public static string EncodePassword(string newPassword)
        {
            try
            {
                byte[] encData_byte = new byte[newPassword.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(newPassword);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

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

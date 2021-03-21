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


//added new things to try to fetch data 
using MySql.Data.MySqlClient;
//ends here 

namespace Project.Controllers
{
    public class PasswordResetController : Controller
    {

        //trying to retrieve data
        MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader rdr;
        List<PasswordResetModel> email = new List<PasswordResetModel>();
        //ends here


        private readonly ILogger<PasswordResetController> _logger;

        public PasswordResetController(ILogger<PasswordResetController> logger)
        {
            _logger = logger;

            //trying to retrieve data
            con.ConnectionString = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            //ends here
        }

        //route after admin click on the send email

        public string url(string householdEmail)
        {
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

        //get the new password
        public ActionResult resetPasswordPage()
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

        //check the credentials
        [HttpPost]
        public ActionResult resetPasswordPage(PasswordResetModel objPasswordResetModel, String householdEmail, String newResetPassword, String confirmResetPassword)
        {
            String email = householdEmail;
            String newPassword = newResetPassword;
            String confirmNewResetPassword = confirmResetPassword;
            Console.WriteLine(email);
            Console.WriteLine(newPassword);
            Console.WriteLine(confirmNewResetPassword);

            //addede this viewbag is alert message , modelstate is to validate that the email filled validation meets the requirement at the model
            ViewBag.Message = "Successsfully reset new password";

            PasswordResetControl pw = new PasswordResetControl(householdEmail, newResetPassword, confirmResetPassword);
            return View();
        }

        //display household email


        [HttpGet]
        public IActionResult adminPasswordResetPage(PasswordResetModel objPasswordResetModel, String householdEmail)
        {

//to retrieve through console
            // String email = householdEmail;
            // Console.WriteLine(email);
            // PasswordResetControl pw = new PasswordResetControl();
            // return View();

//to display on the web
            find();
            return View(email);
        }

        //retrieve database item


        //trying to retrieve data and display on the web

        private void find()
        {
            if (email.Count > 0)
            {
                email.Clear();
            }
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT passwordResetID,householdEmail FROM PasswordReset";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    email.Add(new PasswordResetModel()
                    {
                        passwordResetID = rdr["passwordResetID"].ToString(),
                        householdEmailDetails = rdr["householdEmail"].ToString()

                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Done.");
        }
        //ends here



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

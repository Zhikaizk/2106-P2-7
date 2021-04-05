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



using System.Net.Http;

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

        // get the new password
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

        // //check the credentials
        [HttpPost]
        public ActionResult passwordReset(PasswordResetModel objPasswordResetModel, String householdEmail)
        {
            find(householdEmail);
            // String email = householdEmail;
            // Console.WriteLine(email);

            //addede this viewbag is alert message , modelstate is to validate that the email filled validation meets the requirement at the model
            // ViewBag.Message = "Successsfully requested reset password";

            // PasswordResetControl pw = new PasswordResetControl(householdEmail);
            return View();
        }


        //check the credentials
        private void find(String householdEmail)
        {
                            Console.WriteLine("enter find()");
            String connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            MySqlConnection conn = new MySqlConnection(connStr);
            try{
                conn.Open();
                MySqlCommand command;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                String sql = "";
                MySqlDataReader rdr;
                Console.WriteLine("enter connection()");
                sql="SELECT householdEmail FROM zk.testingHouseholdAccount where householdEmail = '" + householdEmail +"' ";
                Console.WriteLine("enter sql " + sql);
                command = new MySqlCommand(sql, conn);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    Console.WriteLine("enter row()");
                    Console.WriteLine("enter valid");
                    ViewBag.Message = "Valid Account, Please check your email for the request of reset password";
                    String email = householdEmail;
                    Console.WriteLine(email);
                    PasswordResetControl pw = new PasswordResetControl(householdEmail);
            }
            else{
                Console.WriteLine("enter invalid()");
                ViewBag.Message = "Invalid Account, Please key in a valid account";
            }
            Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

        }

//trying to retrieve the household email when they click on the url 
        [HttpGet]
        public ActionResult resetPasswordPage(String householdEmailDetails)
        {
            // String email = householdEmail;
            ViewData["householdEmailDetails"] = householdEmailDetails;

            Console.WriteLine(ViewData["householdEmailDetails"] +"  get only email details" + householdEmailDetails +  "  get only email details" );

            return View();
        }

        //check the credentials
        [HttpPost]
        public ActionResult resetPasswordPage(PasswordResetModel objPasswordResetModel, String householdEmailDetails, String newResetPassword, String confirmResetPassword,String householdPassword)
        {
            // String email = householdEmail;
            ViewData["householdEmailDetails"] = householdEmailDetails;
            String newPassword = newResetPassword;
            String confirmNewResetPassword = confirmResetPassword;

            Console.WriteLine(ViewData["householdEmailDetails"]+ " under the resetj password email" );
            Console.WriteLine(newPassword);
            Console.WriteLine(confirmNewResetPassword);

            //trying to update household password
            householdPassword = newPassword;
            Console.WriteLine(ViewData["householdEmailDetails"]+ " under the update password email");
            Console.WriteLine(newPassword + "under update password password" );

            //addede this viewbag is alert message , modelstate is to validate that the email filled validation meets the requirement at the model
            ViewBag.Message = "Successsfully reset new password";

            PasswordResetControl pw = new PasswordResetControl(householdEmailDetails, newResetPassword, confirmResetPassword);

            //trying to update password at household account db
            PasswordResetControl pw1 = new PasswordResetControl(householdEmailDetails, householdPassword);
            return View();
        }


    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

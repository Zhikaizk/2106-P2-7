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
    public class AdminPasswordResetController : Controller
    {

        //trying to retrieve data
        MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader rdr;
        List<PasswordResetModel> email = new List<PasswordResetModel>();
        private IEmail emailAccess;
        //ends here


        //trying to retrieve url from the submit button
        // private string url;

        private readonly ILogger<PasswordResetController> _logger;

        public AdminPasswordResetController(ILogger<PasswordResetController> logger)
        {
            _logger = logger;

            //trying to retrieve data
            con.ConnectionString = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=zk;port=3306;password=qwerty123";
            //ends here
        }

        //route after admin click on the send email

        // public string url(string householdEmail)
        // {
        //     return HttpUtility.HtmlEncode("Email have been send out");
        // }


        //display household email


        // [HttpGet]
        public IActionResult AdminPasswordResetPage()
        {

            //to display on the web
            Console.WriteLine("lol");
            find();
            Console.WriteLine("eneter");
            //Console.WriteLine("admin password page Endedhere");
            // Console.WriteLine("mytestinghere"+householdEmailDetails);
            return View(email);
        }

        [HttpPost]
        public IActionResult AdminPasswordResetPage(int disabledId,string disabledInput)
        {

            Console.WriteLine(disabledId);
            Console.WriteLine(disabledInput);
            Console.WriteLine("sdiofnewfn");
            //to display on the web

            //find();
            // Console.WriteLine(householdEmailDetails);
            // Console.WriteLine("mytestinghere"+householdEmailDetails);
            

            submitButton(disabledInput,disabledId);

            // PasswordResetController passwordResetController = new PasswordResetController();
            // passwordResetController.resetPasswordPage(disabledInput);
            // return View(disabledInput);
            return View();
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
                Console.WriteLine("JOJOJOJOJO");
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



        //to send email
        [HttpGet]
        public void submitButton(String householdEmailDetails, int passwordResetId)
        {
           this.emailAccess = new Email(householdEmailDetails);
         // my Email have Subscribe and unSubscribe but IEmail don't allow others to access it.
           emailAccess.Update("Reset Password","This is the link to reset password https://localhost:5001/PasswordReset/ResetPasswordPage?passwordResetId=" +  passwordResetId +"&householdEmailDetails="+ householdEmailDetails);//(subject,contentofemail)
           EmailNotification notification = new EmailNotification();
            notification.Attach(emailAccess);// if need more emails , do a list and for loop 
            Boolean results= notification.NotifyObservers();// this do one time can liao

            //trying to delete data
            PasswordResetControl pw = new PasswordResetControl(householdEmailDetails, passwordResetId);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

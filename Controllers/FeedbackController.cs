using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using Project.Models.Feedback;
using Microsoft.AspNetCore.Http;

namespace Project.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(ILogger<FeedbackController> logger)
        {
            _logger = logger;
        }

        //deafult when page loads (householdUser)
        public IActionResult feedbackUser()
        {
          
            return View();
        }

        // when submit btn is clicked
        //parameters are based on the .cshtml name attr

        [HttpPost]
        public IActionResult feedbackUser(string fbType, string feedback)
        {
            // the feedback and fbType will cotains what is type in the view forms(tectbox etc..)
            string content = feedback;
            string type = fbType;

            // need to get email from session (when integrated!)
            string email = "jialin@gmail.com";

            //obj created to do logic in control class
            FeedbackControl fc = new FeedbackControl(type, content, email);

            // alert message upon successful submission
            ViewBag.Message = string.Format("Submitted Successfully! Please kindly wait for a reply back from us. Thank you!");
            return View();
        }

        //deafult when page loads (administrator)
        public IActionResult feedbackAdmin(string feedbackId)
        {
            ViewData["fbTypeKey"] = 1;
            // FeedbackControl fc = new FeedbackControl();
            return View();
        }

        [HttpPost]
        public IActionResult feedbackAdmin(int fbType)
        {
            ViewData["fbTypeKey"] = fbType;
            // string status = fbStatusUpdate;
            // FeedbackControl fc = new FeedbackControl(fbType);
            return View();
        }

        //deafult when page loads (administrator)
        public IActionResult feedbackAdminReply(string feedbackId, string email, string status)
        {
            Console.WriteLine(feedbackId);
            Console.WriteLine(email);
            Console.WriteLine(status);

            ViewData["feedbackId"] = feedbackId;
            ViewData["householdEmail"] = email;
            ViewData["feedbackStatus"] = status;
            return View();
        }

        [HttpPost]
        public IActionResult feedbackAdminReply(string subject, string feedback, string fbStatusUpdate, int feedbackId, string householdEmail)
        {   
    
           // Console.WriteLine(this.HttpContext.Session.GetString("login").ToString());
            Console.WriteLine(subject);
            Console.WriteLine(feedback);
            Console.WriteLine(fbStatusUpdate);
            Console.WriteLine(feedbackId.ToString());
            Console.WriteLine(householdEmail);
            
            FeedbackControl fc = new FeedbackControl(subject, feedback, feedbackId, fbStatusUpdate, householdEmail);
            // alert message upon successful submission
            ViewBag.Message = string.Format("Reply has been sent out!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

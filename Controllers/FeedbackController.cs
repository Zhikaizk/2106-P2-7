using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using Project.Models.Feedback;

namespace Project.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(ILogger<FeedbackController> logger)
        {
            _logger = logger;
        }

        //deafult when page loads
        public IActionResult feedbackUser()
        {
            return View();
        }

        // when submit btn is clicked
        //parameters are based on the .cshtml name attr
        [HttpPost]
        public IActionResult feedbackUser(String fbType, String feedback)
        {
            String content = feedback;
            String type = fbType;
            FeedbackControl fc = new FeedbackControl(type, content);
            return View();
        }

        public IActionResult feedbackAdmin()
        {
            // FeedbackControl fc = new FeedbackControl();
            return View();
        }

        // [HttpPost]
        // public IActionResult feedbackAdmin(String fbStatusUpdate)
        // {
        //     string status = fbStatusUpdate;
        //     FeedbackControl fc = new FeedbackControl(status);
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

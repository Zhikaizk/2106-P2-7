﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using Project.Models.Notification;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminNotification()
        {
            return View();
        }

        [HttpPost]
        // Email emailaddressinput, < input if needed
        //emailaddressinput.emailaddress,
        public IActionResult AdminNotification(Email emailcontent)
        {
            Console.Write(String.IsNullOrEmpty(emailcontent.updatecontent));
            if(String.IsNullOrEmpty(emailcontent.updatecontent)){
            ViewBag.Message = "Content cannot be Empty";
            }else{
            EmailControl emailcontrol = new EmailControl(emailcontent.updatecontent);
            ViewBag.Message = emailcontrol.Success_or_Not();
            }
             return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

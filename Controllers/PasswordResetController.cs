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

        [AllowAnonymous, HttpGet("password-retrieve")]
        public IActionResult PasswordReset()
        {
            return View();
        }
        // [AllowAnonymous, HttpPost("password-retrieve")]
        // public IActionResult PasswordRetrival(PasswordRetrivalModel model)
        // {

        //     if (ModelState.IsValid)
        //     {


        //         // var user = _accountRepository.GetUserByEmailAsync(model.Email);
        //         // if (user != null)
        //         // {
        //         //     await _accountRepository.GeneratePasswordByTokenAsync(user);
        //         // }

        //         ModelState.Clear();
        //         // model.EmailSent = true;
        //     }

        //     return View(model);
        // }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}

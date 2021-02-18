using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.Delete;

namespace Project.Controllers
{
    public class DeleteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Delete()
        {
            // 
            return View();
        }
    }
}

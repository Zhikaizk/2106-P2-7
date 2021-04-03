﻿
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DeleteInactive;

namespace Project.Controllers
{
    public class DeleteInactiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DeleteInactive()
        {
            //initialize the delete control here
            DeleteInactiveControl delCon = new DeleteInactiveControl();

            //populate the Delete Model with inactive user information
            InactiveUsersList iUList = new InactiveUsersList();
            iUList.InactiveU = delCon.populateInactiveModel();

            //populate the Inactive List
            return View(iUList);
        }
        [HttpPost]
        public IActionResult DeleteInactive(InactiveUsersList model)
        {

            DeleteInactiveControl delcon = new DeleteInactiveControl();
            InactiveUsersList iUList = delcon.deleteAccount(model);

            return View(iUList);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using BSBAdminDashboard.BL.Helper;

namespace BSBAdminDashboard.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(string Title, string Message)
        {

            TempData["msg"] = MailHelper.sendMail(Title, Message);

            return RedirectToAction("Index");
        }

        public IActionResult MailBox()
        {
            return View();
        }
    }
}

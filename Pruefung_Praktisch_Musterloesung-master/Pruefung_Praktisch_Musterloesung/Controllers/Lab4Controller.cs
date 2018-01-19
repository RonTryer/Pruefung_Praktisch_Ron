﻿using System;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Pruefung_Praktisch_Musterloesung.Models;

namespace Pruefung_Praktisch_Musterloesung.Controllers
{
    public class Lab4Controller : Controller
    {

        /**
        * 
        * ANTWORTEN BITTE HIER
        * 
        * */

        public ActionResult Index() {

            Lab4IntrusionLog model = new Lab4IntrusionLog();
            return View(model.getAllData());   
        }

        [HttpPost]
        public ActionResult Login()
        {
            var username = Request["username"];
            var password = Request["password"];

            bool intrusion_detected = false;
        
            // Hints
            // Request.Browser.Platform;
            // Request.UserHostAddress;

            Lab4IntrusionLog model = new Lab4IntrusionLog();
            intrusion_detected = model.logIntrusion(Request.UserHostAddress, Request.Browser.Platform, string.Format("{0}", username));

            if (intrusion_detected)
            {
                return RedirectToAction("Index", "Lab4");
            }
            else
            {
                // check username and password
                if (isValidEmail(username))
                {
                    
                }
                // this does not have to be implemented!
                return RedirectToAction("Index", "Lab4");
            }
        }

        private bool isValidEmail(string username)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(username);
                return addr.Address == username;
            }
            catch
            {
                return false;
            }
        }
    }
}
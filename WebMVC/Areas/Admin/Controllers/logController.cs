using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity.Infrastructure;

namespace WebMVC.Areas.Admin.Controllers
{
    public class LogController : Controller
    {
        private DbModel db = new DbModel();
        [HttpGet]
        public IActionResult Logup()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
           
            var use = username;
            var pas = password;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logup(string candidatename, string age, string gender, DateTime dateofbirth, string phonenumber, string email, string placeofbirth, string residentialaddress, string city, string country)
        {

            var candidateNameVar = candidatename;
            var ageVar = age;
            var genderVar = gender;
            var dateOfBirthVar = dateofbirth;
            var phoneNumberVar = phonenumber;
            var emailVar = email;
            var placeOfBirthVar = placeofbirth;
            var residentialAddressVar = residentialaddress;
            var cityVar = city;
            var countryVar = country;

         
            return RedirectToAction("Index", "Home");
        }
    }
}


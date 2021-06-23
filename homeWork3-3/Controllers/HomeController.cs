using homeWork3_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace homeWork3_3.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Persons;Integrated Security=true;";

        public IActionResult Index()
        {
            PeopleDb db = new PeopleDb(_connectionString);
            HomeViewModel vm = new HomeViewModel { People = db.GetPeople() };
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }

        public IActionResult AddPeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPeople(List<People> people)
        {
            PeopleDb db = new PeopleDb(_connectionString);
            db.AddPerson(people.Where(p => !String.IsNullOrEmpty(p.FirstName) && !String.IsNullOrEmpty(p.LastName)).ToList());

            TempData["message"] = "People added successfully"; 
            return Redirect("/");
        }
    }
}

﻿using JCoffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace JCoffee.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // here's one we made earlier..
            //var dbCheck = DbInitialiser.CoffeeCheck();
            //if (dbCheck == null)
            //{
                //call create coffees
            DbInitialiser.CreateCoffees();
            //}
            // else just return view
            return View();
        }

        public ActionResult Selection(int id)
        {
            // rows from db
            var data = SelectionProcessor.LoadCoffees();

            // empty list to transfer rows to from db
            List<CoffeeModel> coffees = new List<CoffeeModel>();

            foreach (var row in data)
            {   // iterate over the the list of employees (from db)
                if (id == row.Id)
                {
                    coffees.Add(new CoffeeModel
                    {
                        // add the db values to new variables and add as row to empty list
                        Id = row.Id,
                        CoffeeName = row.CoffeeName,
                        CoffeeSub = row.CoffeeSub,
                        CoffeeDesc = row.CoffeeDesc,
                    });
                }
            }

            // return the list of employees to be used in view
            return View(coffees);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employees List";
            // rows from db
            var data = EmployeeProcessor.LoadEmployees();

            // empty list to transfer rows to from db
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var row in data)
            {   // iterate over the the list of employees (from db)
                employees.Add(new EmployeeModel
                { 
                    // add the db values to new variables and add as row to empty list
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress
                });
            }

            // return the list of employees to be used in view
            return View(employees);
        }

        //GET
        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee Sign Up";

            return View();
        }

        [HttpPost] //POST
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {
            // back end validation
            if (ModelState.IsValid) 
            {
                // here's one we made earlier..
                int recordsCreated = EmployeeProcessor.CreateEmployee(model.EmployeeId, 
                    model.FirstName, 
                    model.LastName, 
                    model.EmailAddress);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
using JCoffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace JCoffee.Controllers
{
    public class HomeController : Controller
    {
        // constructor
        public HomeController()
        {
            // handles the back button
            ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;

            // create tables
            if (DbInitialiser.CoffeeCheck())
            {
                //create coffees
                DbInitialiser.CreateCoffees();
            }
            if (DbInitialiser.BasketCheck())
            {
                //create coffees
                DbInitialiser.CreateBasket();
            }
        }

        public ActionResult Index()
        {
            // else just return view
            return View();
        }

        public ActionResult Selection(int id)
        {
            // reset all coffee property values upon visiting page
            SelectionProcessor.ResetCoffees(id);
            // grab rows from db
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
                        CoffeeImg = row.CoffeeImg,
                        CoffeeRating = row.CoffeeRating,
                        CoffeePrice = row.CoffeePrice,
                        CoffeeMilk = row.CoffeeMilk,
                        CoffeeSugar = row.CoffeeSugar,
                        CoffeeSalt = row.CoffeeSalt,
                        CoffeeGinger = row.CoffeeGinger,
                        CoffeeSmall = row.CoffeeSmall,
                        CoffeeMedium = row.CoffeeMedium,
                        CoffeeLarge = row.CoffeeLarge
                    });
                }
            }

            // return the list of employees to be used in view
            return View(coffees);
        }

        public ActionResult SelectionUpdate(int id, string name) {

            if (name.Contains("Small") || name.Contains("Medium") || name.Contains("Large"))
            {
                SelectionProcessor.SizeCoffees(id, name);
            }
            else 
            {
                SelectionProcessor.UpdateCoffees(id, name);
            }
            
            return new HttpStatusCodeResult(204);
        }

        public ActionResult Basket()
        {
            var basket = BasketProcessor.LoadBasket();

            List<CoffeeModel> basketList = new List<CoffeeModel>();

            foreach (var row in basket)
            {   // iterate over the the list of employees (from db)
                basketList.Add(new CoffeeModel
                {
                    // add the db values to new variables and add as row to empty list
                    Id = row.Id,
                    CoffeeName = row.CoffeeName,
                    CoffeeSub = row.CoffeeSub,
                    CoffeeDesc = row.CoffeeDesc,
                    CoffeeImg = row.CoffeeImg,
                    CoffeeRating = row.CoffeeRating,
                    CoffeePrice = row.CoffeePrice,
                    CoffeeMilk = row.CoffeeMilk,
                    CoffeeSugar = row.CoffeeSugar,
                    CoffeeSalt = row.CoffeeSalt,
                    CoffeeGinger = row.CoffeeGinger,
                    CoffeeSmall = row.CoffeeSmall,
                    CoffeeMedium = row.CoffeeMedium,
                    CoffeeLarge = row.CoffeeLarge
                });
            }
            return View(basketList);
        }

        public ActionResult AddToBasket(int id)
        {
            BasketProcessor.AddToBasket(id);
            return new HttpStatusCodeResult(204);
        }

        public ActionResult RemoveFromBasket(int id) 
        {
            BasketProcessor.RemoveFromBasket(id);
            return Redirect(Request.UrlReferrer.ToString());
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
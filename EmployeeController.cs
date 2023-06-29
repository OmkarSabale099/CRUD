using CRUDApplication.Models;
using CRUDApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CRUDApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository(new Models.TrainingDbContext());
        }      
        public ActionResult Index()
        {
            var employee = employeeRepository.GetEmployees();
            return View(employee);
        }
       
        public ActionResult Details(int id)
        {
            var employee = employeeRepository.GetEmployeeByID(id);
            return View(employee);
        }
     
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeRepository.InsertEmployee(employee);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = employeeRepository.GetEmployeeByID(id);
            return View(employee);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeRepository.UpdateEmployee(employee);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            var employee = employeeRepository.GetEmployeeByID(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Employee employee)
        {
            try
            {
                employeeRepository.DeleteEmployee(id);
                
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");

            }
            return RedirectToAction("Index");
        }
    }
}

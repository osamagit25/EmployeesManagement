using EMS.BLL.Interfaces;
using EMS.BLL.Repositories;
using EMS.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Employees = employeeRepository.GetAll();
            return View(Employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {

                var Count = employeeRepository.Add(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee= employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            
            var employee= employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {


                var Count = employeeRepository.Update(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            var employee = employeeRepository.GetById(id);
            if (employee == null)
            { return NotFound(); }
            return View(employee);
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee model) {
           
                var count = employeeRepository.Delete(model);
                if (count > 0) { 
                    return RedirectToAction("Index");
                 }
            
            return View(model);
        
        }

    }
}

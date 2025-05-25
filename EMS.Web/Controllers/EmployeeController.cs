using AutoMapper;
using EMS.BLL.Interfaces;
using EMS.BLL.Repositories;
using EMS.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
           
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        
        public IActionResult Index(string input)
        {
            var Employees=Enumerable.Empty<Employee>();
            if (string.IsNullOrEmpty(input))
            {
                Employees = unitOfWork.EmployeeRepository.GetAll();
            }
            else
            {
                Employees = unitOfWork.EmployeeRepository.GetByName(input);

            }
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

                var Count = unitOfWork.EmployeeRepository.Add(model);
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
            var employee= unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            
            var employee= unitOfWork.EmployeeRepository.GetById(id);
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


                var Count = unitOfWork.EmployeeRepository.Update(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            var employee = unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            { return NotFound(); }
            return View(employee);
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee model) {
           
                var count = unitOfWork.EmployeeRepository.Delete(model);
                if (count > 0) { 
                    return RedirectToAction("Index");
                 }
            
            return View(model);
        
        }

    }
}

using AutoMapper;
using EMS.BLL.Interfaces;
using EMS.BLL.Repositories;
using EMS.DAL.Models;
using EMS.Web.Helpers;
using EMS.Web.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            
            var EmployeeVM = mapper.Map<IEnumerable<CreateEmployeeVM >>(Employees);
            

            return View(EmployeeVM);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var departments = unitOfWork.DepartmentRepository.GetAll();

            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeVM model)
        {
            if (ModelState.IsValid)
            {

                if (model.Image != null)
                {
                    model.ImageURL = DocumentSettings.UploadFile(model.Image, "Images");
                }
                var employee = mapper.Map<Employee>(model);


                var Count = unitOfWork.EmployeeRepository.Add(employee);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            
            var departments = unitOfWork.DepartmentRepository.GetAll();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", model.DepartmentId);
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
            var employeeVM = mapper.Map<EmployeeViewModel>(employee);
            var department = unitOfWork.DepartmentRepository.GetById(employeeVM.DepartmentId);

            
            return View(employeeVM);
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            
            var employee= unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeVM = mapper.Map<EmployeeViewModel>(employee);
            var departments = unitOfWork.DepartmentRepository.GetAll();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", employeeVM.DepartmentId);
            return View(employeeVM);
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {

                var employee = mapper.Map<Employee>(model);

                var Count = unitOfWork.EmployeeRepository.Update(employee);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            var departments = unitOfWork.DepartmentRepository.GetAll();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", model.DepartmentId);
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            var employee = unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            { return NotFound(); }
            var employeeVM = mapper.Map<EmployeeViewModel>(employee);
            var department = unitOfWork.DepartmentRepository.GetById(employeeVM.DepartmentId);
            
            return View(employeeVM);
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeViewModel model) {
            
            var employee = mapper.Map<Employee>(model);

            var count = unitOfWork.EmployeeRepository.Delete(employee);
                if (count > 0) { 
                    return RedirectToAction("Index");
                 }
            var department = unitOfWork.DepartmentRepository.GetById(model.DepartmentId);
           
            return View(model);
        
        }

    }
}

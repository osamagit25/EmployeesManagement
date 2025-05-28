using AutoMapper;
using EMS.BLL.Interfaces;
using EMS.BLL.Repositories;
using EMS.DAL.Models;
using EMS.Web.Helpers;
using EMS.Web.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace EMS.Web.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string input)
        {
            var Employees = Enumerable.Empty<Employee>();
            if (string.IsNullOrEmpty(input))
            {
                Employees =await unitOfWork.EmployeeRepository.GetAllAsync();
            }
            else
            {
                Employees = await unitOfWork.EmployeeRepository.GetByNameAsync(input);

            }

            var EmployeeVM = mapper.Map<IEnumerable<CreateEmployeeVM>>(Employees);


            return View(EmployeeVM);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var departments =await unitOfWork.DepartmentRepository.GetAllAsync();

            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeVM model)
        {
            if (ModelState.IsValid)
            {

                if (model.Image != null)
                {
                    model.ImageURL = DocumentSettings.UploadFile(model.Image, "Images");
                }
                var employee = mapper.Map<Employee>(model);


                var Count = await unitOfWork.EmployeeRepository.AddAsync(employee);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            var departments = await unitOfWork.DepartmentRepository.GetAllAsync();
            ViewBag.Departments =  new SelectList(departments, "Id", "Name", model.DepartmentId);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeVM = mapper.Map<EmployeeViewModel>(employee);
            var department = await unitOfWork.DepartmentRepository.GetById(employeeVM.DepartmentId);


            return View(employeeVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id) {

            var employee = await    unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeVM = mapper.Map<EmployeeViewModel>(employee);
            var departments =await unitOfWork.DepartmentRepository.GetAllAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", employeeVM.DepartmentId);
            return View(employeeVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageURL is not null)
                {
                    DocumentSettings.DeleteFile(model.ImageURL, "Images");
                }
                if (model.Image is not null)
                {
                    model.ImageURL = DocumentSettings.UploadFile(model.Image, "Images");
                }

                var employee = mapper.Map<Employee>(model);

                var Count =await unitOfWork.EmployeeRepository.Update(employee);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            var departments = await unitOfWork.DepartmentRepository.GetAllAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", model.DepartmentId);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) {
            var employee = await unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            { return NotFound(); }
            var employeeVM = mapper.Map<EmployeeViewModel>(employee);
            var department =await unitOfWork.DepartmentRepository.GetById(employeeVM.DepartmentId);

            return View(employeeVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeViewModel model)
        {
            

            var employee = mapper.Map<Employee>(model);

            var count = await unitOfWork.EmployeeRepository.Delete(employee);
            if (count > 0)
            {
                if (!string.IsNullOrEmpty(model.ImageURL))
                {
                    DocumentSettings.DeleteFile(model.ImageURL, "Images");
                }

                return RedirectToAction("Index");
            }

            
            var departmentInfo = await unitOfWork.DepartmentRepository.GetById(model.DepartmentId);
            ViewBag.Department = departmentInfo;
            return View(model);
        }


    }
}

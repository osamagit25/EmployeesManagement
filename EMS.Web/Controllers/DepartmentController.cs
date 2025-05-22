using EMS.BLL.Interfaces;
using EMS.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var Departments = departmentRepository.GetAll();
            return View(Departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                var Count = departmentRepository.Add(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details (int ? id)
        {
            var department= departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }
        [HttpGet]
        public IActionResult Edit ([FromRoute]int id)
        {
            var department= departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department model)
        {
            if (ModelState.IsValid)
            {
                var Count = departmentRepository.Update(model);
                if (Count >0)
                {
                    return RedirectToAction("Index");
                }
               
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var department = departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department model)
        {
            var Count = departmentRepository.Delete(model);
            if (Count > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}

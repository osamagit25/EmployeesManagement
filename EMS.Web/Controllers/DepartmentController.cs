using AutoMapper;
using EMS.BLL.Interfaces;
using EMS.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class DepartmentController : Controller
    {
        
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public DepartmentController(IUnitOfWork _UOW,IMapper mapper)
        {
            
            this.unitOfWork = _UOW;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var Departments = unitOfWork.DepartmentRepository.GetAll();
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
                var Count = unitOfWork.DepartmentRepository.Add(model);
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
            var department= unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }
        [HttpGet]
        public IActionResult Edit ([FromRoute]int id)
        {
            var department= unitOfWork.DepartmentRepository.GetById(id);
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
                var Count = unitOfWork.DepartmentRepository.Update(model);
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
            var department = unitOfWork.DepartmentRepository.GetById(id);
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
            var Count = unitOfWork.DepartmentRepository.Delete(model);
            if (Count > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}

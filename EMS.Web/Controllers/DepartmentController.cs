using AutoMapper;
using EMS.BLL.Interfaces;
using EMS.DAL.Models;
using EMS.Web.ViewModels;
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
            var DepartmentVM = mapper.Map<IEnumerable<DepartmentViewmodel>>(Departments);
            return View(DepartmentVM);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentViewmodel model)
        {
            var Deartment = mapper.Map<Department>(model);
            if (ModelState.IsValid)
            {
                var Count = unitOfWork.DepartmentRepository.Add(Deartment);
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
            var DepartmentVM = mapper.Map<DepartmentViewmodel>(department);
            return View(DepartmentVM);

        }
        [HttpGet]
        public IActionResult Edit ([FromRoute]int id)
        {
            var department= unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
          var  DepartmentVM= mapper.Map<DepartmentViewmodel>(department);
            return View(DepartmentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentViewmodel model)
        {
            var Department= mapper.Map<Department>(model);
            if (ModelState.IsValid)
            {
                var Count = unitOfWork.DepartmentRepository.Update(Department);
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
            var DepartmentVM= mapper.Map<DepartmentViewmodel>(department);
            return View(DepartmentVM);
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

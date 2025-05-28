using AutoMapper;
using EMS.BLL.Interfaces;
using EMS.DAL.Models;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var Departments = await unitOfWork.DepartmentRepository.GetAllAsync();
            var DepartmentVM = mapper.Map<IEnumerable<DepartmentViewmodel>>(Departments);
            return View(DepartmentVM);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewmodel model)
        {
            var Deartment = mapper.Map<Department>(model);
            if (ModelState.IsValid)
            {
                var Count =await unitOfWork.DepartmentRepository.AddAsync(Deartment);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details (int ? id)
        {
            var department= await unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            var DepartmentVM = mapper.Map<DepartmentViewmodel>(department);
            return View(DepartmentVM);

        }
        [HttpGet]
        public async Task<IActionResult> Edit ([FromRoute]int id)
        {
            var department= await unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
          var  DepartmentVM= mapper.Map<DepartmentViewmodel>(department);
            return View(DepartmentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentViewmodel model)
        {
            var Department= mapper.Map<Department>(model);
            if (ModelState.IsValid)
            {
                var Count = await unitOfWork.DepartmentRepository.Update(Department);
                if (Count >0)
                {
                    return RedirectToAction("Index");
                }
               
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            var department = await unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            var DepartmentVM= mapper.Map<DepartmentViewmodel>(department);
            return View(DepartmentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department model)
        {
            var Count = await unitOfWork.DepartmentRepository.Delete(model);
            if (Count > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}

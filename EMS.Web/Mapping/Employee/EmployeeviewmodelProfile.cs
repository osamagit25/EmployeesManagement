using AutoMapper;
using EMS.DAL.Models;
using EMS.Web.ViewModels;
using EMS.Web.ViewModels.Employee;

namespace EMS.Web.Mapping
{
    public class EmployeeviewmodelProfile:Profile
    {
        public EmployeeviewmodelProfile()
        {
            CreateMap<Employee,EmployeeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>()
    .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
    ;

        }
    }
}

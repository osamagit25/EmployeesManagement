using AutoMapper;
using EMS.DAL.Models;
using EMS.Web.ViewModels.Employee;

namespace EMS.Web.Mapping;

public class CreateEmployeeVMProfile:Profile
{
    public CreateEmployeeVMProfile()
    {
        
        CreateMap<Employee, CreateEmployeeVM>()
.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));
        CreateMap<CreateEmployeeVM, Employee>()
       .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL));


    }

}

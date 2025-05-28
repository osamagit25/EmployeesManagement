using AutoMapper;
using EMS.DAL.Models;

using EMS.Web.ViewModels;

namespace EMS.Web.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department,DepartmentViewmodel>().ReverseMap();
        }
    }
}

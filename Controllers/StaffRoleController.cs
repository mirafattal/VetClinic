using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.DoctorDTOs;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.StaffRoles;

namespace VetClinic.Controllers
{
    public class StaffRoleController : _GenericController<StaffRoleDto>
    {
        public readonly IStaffRoleService _staffRoleService;
        public StaffRoleController(IStaffRoleService service) : base(service)
        {
            _staffRoleService = service;
        }
    }
}

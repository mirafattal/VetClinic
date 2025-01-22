using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.DoctorDTOs;
using Vet_BLL.Services.Doctors;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Doctors;
using Vet_DAL.Repositories.StaffRoles;

namespace Vet_BLL.Services.StaffRoles
{
    public class StaffRoleService : GenericService<StaffRole, StaffRoleDto>, IStaffRoleService
    {
        public readonly IStaffRoleRepository _staffRoleRepository;
        public readonly IMapper _mapper;

        public StaffRoleService(IStaffRoleRepository staffRoleRepository, IMapper mapper) :
            base(staffRoleRepository, mapper)
        {
            _staffRoleRepository = staffRoleRepository;
            _mapper = mapper;
        }
    }
}

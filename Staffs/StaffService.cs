using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.DoctorDTOs;
using Vet_BLL.DTOs.StaffDTOs;
using Vet_BLL.Services.Appointments;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Appointments;
using Vet_DAL.Repositories.Doctors;
using Vet_DAL.Repositories.StaffRoles;

namespace Vet_BLL.Services.Doctors
{
    public class StaffService: GenericService<Staff, StaffDto>, IStaffService
    {
        public readonly IStaffRepository _staffRepository;
        public readonly IStaffRoleRepository _staffRoleRepository;
        public readonly IMapper _mapper;

        public StaffService(IStaffRepository staffRepository, IMapper mapper,
            IStaffRoleRepository staffRoleRepository) :
            base(staffRepository, mapper)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
            _staffRoleRepository = staffRoleRepository;
        }

        public async Task<string> GetStaffNameAsync(int staffId)
        {
            return await _staffRepository.GetStaffNameAsync(staffId);
        }

        public IEnumerable<GetStaffNamesdto> GetAllStaffNames()
        {
            var staffs = _staffRepository.GetAll();
            return _mapper.Map<IEnumerable<GetStaffNamesdto>>(staffs);
        }

        public IEnumerable<StaffWithRoleDTO> GetStaffWithRoles()
        {
            var staff = _staffRepository.GetAll(); // Synchronous method
            var roles = _staffRoleRepository.GetAll(); // Synchronous method

            // Join Staff and Role data
            var staffWithRoles = staff.Join(
                roles,
                s => s.StaffRoleId,
                r => r.StaffRoleId,
                (s, r) => new StaffWithRoleDTO
                {
                    StaffId = s.StaffId,
                    FullName = s.FullName,
                    Address = s.Address,
                    Phone = s.Phone,
                    StaffRoleId = s.StaffRoleId,
                    RoleName = r.RoleName
                });

            return staffWithRoles;
        }


        //public async Task UploadCvAsync(CvUploadDto cvUploadDto)
        //{
        //    var staff = await _staffRepository.GetStaffByIdAsync(cvUploadDto.StaffId);
        //    if (staff == null) throw new Exception("Staff not found");

        //    var filePath = Path.Combine(@"C:\Users\lenovo\Desktop\Veterinary\Backend\Vet_BLL\UploadedFiles\CVs\",
        //        cvUploadDto.CvFile.FileName); // Specify your path
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await cvUploadDto.CvFile.CopyToAsync(stream);
        //    }

        //    staff.CvPath = filePath;
        //    await _staffRepository.UpdateStaffAsync(staff);
        //}

        //public async Task<byte[]> DownloadCvAsync(int staffId)
        //{
        //    var staff = await _staffRepository.GetStaffByIdAsync(staffId);
        //    if (staff == null || string.IsNullOrEmpty(staff.CvPath)) throw new Exception("CV not found");

        //    return await File.ReadAllBytesAsync(staff.CvPath);
        //}


    }
}

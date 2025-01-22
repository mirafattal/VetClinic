using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.DoctorDTOs;
using Vet_BLL.DTOs.StaffDTOs;
using Vet_DAL.Models;

namespace Vet_BLL.Services.Doctors
{
    public interface IStaffService: IGenericService<StaffDto>
    {
        public Task<string> GetStaffNameAsync(int staffId);
        IEnumerable<GetStaffNamesdto> GetAllStaffNames();

        public IEnumerable<StaffWithRoleDTO> GetStaffWithRoles();

        //Task UploadCvAsync(CvUploadDto cvUploadDto);
        //Task<byte[]> DownloadCvAsync(int staffId);



        //public void SaveCV(int staffId, IFormFile file);
        //public Stream GetCV(int staffId);

    }
}

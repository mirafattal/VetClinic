using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Vet_BLL.DTOs.StaffDTOs
{
    public class CvUploadDto
    {
        public IFormFile CvFile { get; set; }
        public int StaffId { get; set; }
    }
}

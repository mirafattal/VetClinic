using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs.DoctorDTOs;
using Vet_BLL.DTOs.StaffDTOs;
using Vet_BLL.Services.Appointments;
using Vet_BLL.Services.Doctors;

namespace VetClinic.Controllers
{
    public class StaffController : _GenericController<StaffDto>
    {
        public readonly IStaffService _staffService;
        public StaffController(IStaffService service) : base(service)
        {
            _staffService = service;
        }

        [HttpGet("GetStaffNamebyId")]
        public async Task<IActionResult> GetStaffName(int staffId)
        {
            var staffName = await _staffService.GetStaffNameAsync(staffId);
            if (staffName == null)
            {
                return NotFound("Staff not found.");
            }

            return Ok(staffName);
        }

        [HttpGet("GetStaffNames")]
        public ActionResult<IEnumerable<GetStaffNamesdto>> GetAllStaffNames()
        {
            var staffNames = _staffService.GetAllStaffNames();
            return Ok(staffNames);
        }

        [HttpGet("Staffwithroles")]
        public ActionResult<IEnumerable<StaffWithRoleDTO>> GetStaffWithRoles()
        {
            try
            {
                var staffWithRoles = _staffService.GetStaffWithRoles();
                return Ok(staffWithRoles); // Return HTTP 200 with data
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpPost("uploadcv")]
        public async Task<IActionResult> UploadCv([FromForm] CvUploadDto cvUploadDto)
        {
            if (cvUploadDto.CvFile == null || cvUploadDto.CvFile.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                await _staffService.UploadCvAsync(cvUploadDto);
                return Ok("CV uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("downloadcv")]
        public async Task<IActionResult> DownloadCv(int staffId)
        {
            try
            {
                var fileBytes = await _staffService.DownloadCvAsync(staffId);
                var fileName = $"CV_{staffId}.pdf"; // You can customize the file name as needed
                return File(fileBytes, "application/pdf", fileName); // Adjust the content type if necessary
            }
            catch (Exception ex)
            {
                return NotFound($"CV not found: {ex.Message}");
            }
        }
    }



}


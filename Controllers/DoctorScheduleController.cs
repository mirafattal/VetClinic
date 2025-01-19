using Microsoft.AspNetCore.Mvc;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.Services.DoctorSchedules;

namespace VetClinic.Controllers
{
    public class DoctorScheduleController : _GenericController<DoctorScheduleDto>
    {
        public readonly IDoctorScheduleService _service;
        public DoctorScheduleController(IDoctorScheduleService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetschedulebyStaffId")]
        public IActionResult GetAvailableSchedules(int doctorId, DateTime appointmentDate)
        {
            var schedules = _service.GetAvailableSchedules(doctorId, appointmentDate);
            return Ok(schedules);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs.DoctorSlotsDTOs;
using Vet_BLL.Services.AppointmentStatuses;
using Vet_BLL.Services.Pets;

namespace VetClinic.Controllers
{
    public class DoctorSlotController : _GenericController<DoctorSlotDto>
    {
        public readonly IDoctorSlotService _doctorSlotService;
        public DoctorSlotController(IDoctorSlotService service) : base(service)
        {
            _doctorSlotService = service;
        }

        [HttpPost("GenerateSlots")]
        public IActionResult GenerateSlots([FromBody] SlotGenerationRequestDto request)
        {
            try
            {
                _doctorSlotService.GenerateSlots(request);
                return Ok(new { message = "Slots generated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("GetAvailableSlots")]
        [ProducesResponseType(typeof(List<DoctorSlotDto>), 200)] // Success response
        [ProducesResponseType(typeof(object), 400)] // Bad request (validation errors, etc.)
        [ProducesResponseType(typeof(object), 500)] // Internal server error (exception handling)
        public IActionResult GetAvailableSlots(int doctorId, string startDate, string endDate)
        {
            try
            {
                // Convert string dates to DateOnly or DateTime
                var startDateParsed = DateOnly.Parse(startDate);  // You can use DateTime.Parse if needed
                var endDateParsed = DateOnly.Parse(endDate);      // Similarly, use DateTime if needed

                // Get available slots from service
                var availableSlots = _doctorSlotService.GetAvailableSlots(doctorId, startDateParsed, endDateParsed);

                // Return the available slots as a response
                return Ok(availableSlots);
            }
            catch (Exception ex)
            {
                // Handle errors
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpGet("AvailableDatesWithDoctorId")]
        [ProducesResponseType(typeof(List<DateOnly>), 200)]  // 200 OK with List of DateOnly
        [ProducesResponseType(400)]  // 400 Bad Request if input is invalid
        [ProducesResponseType(404)]  // 404 Not Found if no available slots found
        public IActionResult GetAvailableSlotDates(int doctorId)
        {
            var dates = _doctorSlotService.GetAvailableSlotDates(doctorId);
            if (dates == null || !dates.Any())
            {
                return NotFound();
            }
            return Ok(dates);
        }

        [HttpGet("AvailableTimesWithDoctorAndDate")]
        [ProducesResponseType(typeof(List<string>), 200)]  // 200 OK with List of times (strings)
        [ProducesResponseType(400)]  // 400 Bad Request for invalid parameters
        [ProducesResponseType(404)]  // 404 Not Found if no times are available for the given doctor and date
        public IActionResult GetAvailableSlotTimes(int doctorId, string date)
        {
            // Try parsing the date string into a DateOnly or DateTime
            if (!DateOnly.TryParse(date, out var parsedDate)) // Or use DateTime if you need time as well
            {
                return BadRequest("Invalid date format. Expected 'yyyy-MM-dd'.");
            }

            // Retrieve available times based on doctorId and parsed date
            var times = _doctorSlotService.GetAvailableSlotTimes(doctorId, parsedDate);
            if (times == null || !times.Any())
            {
                return NotFound();
            }

            return Ok(times);
        }
    }
}

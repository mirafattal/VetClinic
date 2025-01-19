using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AppointmentDTOs;
using Vet_BLL.Services.Appointments;

namespace VetClinic.Controllers
{
    public class AppointmentController : _GenericController<AppointmentDto>
    {
        public readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService service) : base(service)
        {
            _appointmentService = service;
        }

        [HttpGet("appointmentsforthisweek")]
        public ActionResult<List<AppointmentDto>> GetAppointmentsForCurrentWeek()
        {
            try
            {
                var appointments = _appointmentService.GetAppointmentsForCurrentWeek();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("appointmentsforthismonth")]
        public ActionResult<List<AppointmentDto>> GetAppointmentsForCurrentMonth()
        {
            try
            {
                var appointments = _appointmentService.GetAppointmentsForCurrentMonth();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetappointmentbyanimalId")]
        public ActionResult<List<AppointmentDto>> GetAppointmentsByAnimalId(int animalId)
        {
            try
            {
                var appointments = _appointmentService.GetAppointmentsByAnimalId(animalId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("availableSlots")]
        [ProducesResponseType(typeof(IEnumerable<GetAvailableAppointmentsDto>), 200)] // Success - OK with list of available appointments
        [ProducesResponseType(400)] // Bad Request - Invalid input parameters
        [ProducesResponseType(500)] // Internal Server Error - General error
        public  IActionResult GetAvailableAppointmentsForMonth(int doctorId, int year, int month)
        {
            if (doctorId <= 0 || year <= 0 || month <= 0 || month > 12)
            {
                return BadRequest("Invalid input parameters.");
            }

            var availableAppointments = _appointmentService.GetAvailableAppointmentsForMonth(doctorId, year, month);
            return Ok(availableAppointments);
        }


        [HttpGet("GetManybookedAppointments")]
        [ProducesResponseType(typeof(IEnumerable<AppointmentDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetManyBookedAppointments(int doctorId, int year, int month)
        {
            if (doctorId <= 0 || year <= 0 || month <= 0 || month > 12)
            {
                return BadRequest("Invalid input parameters.");
            }

            // Calculate start and end dates for the specified month
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1); // End of the month

            // Get the booked appointments for the doctor within the specified date range
            var bookedAppointments = _appointmentService.GetManyBookedAppointments(doctorId, startDate, endDate);

            if (bookedAppointments == null || !bookedAppointments.Any())
            {
                return NoContent(); // No booked appointments found
            }


            return Ok(bookedAppointments);
        }


        [HttpPost("BookAppointment")]
        [ProducesResponseType(typeof(object), 200)] // Success response
        [ProducesResponseType(typeof(object), 400)] // Bad request (validation errors)
        [ProducesResponseType(typeof(object), 500)] // Internal server error (exception handling)
        public IActionResult BookAppointment([FromBody] BookAppointmentDto request)
        {
            try
            {
                // Book the appointment
                _appointmentService.BookAppointment(request);

                // Return success message as a structured object
                return Ok(new { message = "Appointment booked successfully." });
            }
            catch (InvalidOperationException ex)
            {
                // Handle slot already booked error
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Handle other errors
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("GetAnimalAndAppoinThisWeek")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AppoiAnimalNameDto>))] // When appointments are retrieved successfully
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // For unexpected server errors
        public async Task<IActionResult> GetAllAppointmentsAnimalThisWeek()
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentsAnimalThisWeekAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving appointments.");
            }
        }


        [HttpGet("GetAnimalAndAppoinThisMonth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AppoiAnimalNameDto>))] // When appointments are retrieved successfully
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // For unexpected server errors
        public async Task<IActionResult> GetAllAppointmentsAnimalThisMonth()
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentsAnimalThisMonthAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving appointments.");
            }
        }

        [HttpGet("GetAnimalAndAppoinNextMonth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AppoiAnimalNameDto>))] // When appointments are retrieved successfully
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // For unexpected server errors
        public async Task<IActionResult> GetAllAppointmentsAnimalNextMonth()
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentsAnimalNextMonthAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving appointments.");
            }
        }


        [HttpGet("GetAppointmentByDate")]
        [ProducesResponseType(typeof(IEnumerable<GetAppointmentByDateDto>), 200)]  // Successful response
        [ProducesResponseType(500)]  // Internal server error response
        public async Task<ActionResult<IEnumerable<GetAppointmentByDateDto>>> GetAppointmentsByDate(DateTime date)
        {
            var appointments = await _appointmentService.GetAppointmentsByDateAsync(date);
            return Ok(appointments ?? new List<GetAppointmentByDateDto>()); // Return an empty list if null
        }



        [HttpGet("countTotalAppointmentssofar")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public IActionResult CountTotalAppointmentsSoFar()
        {
            try
            {
                var totalAppointments = _appointmentService.CountTotalAppointmentsSoFar();
                return Ok(totalAppointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while counting appointments.", error = ex.Message });
            }
        }


    }
}

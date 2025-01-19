using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs.InvoiceDTOs;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.Invoices;

namespace VetClinic.Controllers
{
    public class InvoiceController : _GenericController<InvoiceDto>
    {
        public readonly IinvoiceService _invoiceService;
        public InvoiceController(IinvoiceService service) : base(service)
        {
            _invoiceService = service;
        }

        /// <summary>
        /// Gets the weekly revenue grouped by day.
        /// </summary>
        /// <returns>List of weekly revenue data.</returns>
        [HttpGet("weeklyrevenue")]
        [ProducesResponseType(typeof(IEnumerable<WeeklyRevenueDto>), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<WeeklyRevenueDto>> GetWeeklyRevenue()
        {
            try
            {
                var weeklyRevenue = _invoiceService.GetWeeklyRevenue();
                return Ok(weeklyRevenue);
            }
            catch (Exception ex)
            {
                // Log the exception if logging is set up
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        [HttpGet("monthlyrevenue")]
        [ProducesResponseType(typeof(IEnumerable<WeeklyRevenueDto>), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<WeeklyRevenueDto>> GetMonthlyRevenue()
        {
            try
            {
                var monthlyRevenue = _invoiceService.GetMonthlyRevenue();
                return Ok(monthlyRevenue);
            }
            catch (Exception ex)
            {
                // Log the exception if logging is set up
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }
        [HttpGet("yearlyrevenue")]
        [ProducesResponseType(typeof(IEnumerable<WeeklyRevenueDto>), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<WeeklyRevenueDto>> GetYearlyRevenue()
        {
            try
            {
                var yearlyRevenue = _invoiceService.GetYearlyRevenue();
                return Ok(yearlyRevenue);
            }
            catch (Exception ex)
            {
                // Log the exception if logging is set up
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        [HttpGet("weeklyTotalSumrevenue")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public IActionResult GetWeeklyTotalRevenue()
        {
            try
            {
                var totalRevenue = _invoiceService.GetWeeklyTotalRevenue();
                return Ok(new { totalRevenue });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        [HttpGet("monthlyTotalSumrevenue")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public IActionResult GetMonthlyTotalRevenue()
        {
            try
            {
                var totalRevenue = _invoiceService.GetMonthlyTotalRevenue();
                return Ok(new { totalRevenue });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        [HttpGet("yearlyTotalSumrevenue")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public IActionResult GetYearlyTotalRevenue()
        {
            try
            {
                var totalRevenue = _invoiceService.GetYearlyTotalRevenue();
                return Ok(new { totalRevenue });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        [HttpGet("GetRevenueforSpecificYear")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public IActionResult GetRevenueForaSpecificYear(int year)
        {
            try
            {
                var totalRevenue = _invoiceService.GetYearlyTotalRevenue(year);
                return Ok(new { year, totalRevenue });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        [HttpGet("yearlyrevenuecomparison")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public IActionResult GetYearlyRevenueComparison()
        {
            try
            {
                var comparison = _invoiceService.GetYearlyRevenueComparison();
                return Ok(comparison);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        [HttpGet("Revenuemonthlybyday")]
        [ProducesResponseType(typeof(List<RevenueByDayDto>), StatusCodes.Status200OK)] // Specifies the response type and status code
        public async Task<IActionResult> GetMonthlyRevenueByDay()
        {
            var revenueData = await _invoiceService.GetMonthlyRevenueByDayAsync();
            return Ok(revenueData);
        }


    }
}

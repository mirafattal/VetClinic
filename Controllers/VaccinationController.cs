using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.Vaccinations;

namespace VetClinic.Controllers
{
    public class VaccinationController : _GenericController<VaccinationDto>
    {
        public readonly IVaccinationService _vaccinationService;
        public VaccinationController(IVaccinationService service) : base(service)
        {
            _vaccinationService = service;
        }

        [HttpGet("GetvaccinationbyanimalId")]
        public ActionResult<List<VaccinationDto>> GetVaccinationsByAnimalId(int animalId)
        {
            try
            {
                var vaccination = _vaccinationService.GetVaccinationsByAnimalId(animalId);
                return Ok(vaccination);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

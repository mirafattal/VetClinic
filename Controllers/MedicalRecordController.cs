using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.MedicalRecords;

namespace VetClinic.Controllers
{
    public class MedicalRecordController : _GenericController<MedicalRecordDto>
    {
        public readonly IMedicalRecordService _medicalRecordService;
        public MedicalRecordController(IMedicalRecordService service) : base(service)
        {
            _medicalRecordService = service;
        }

        [HttpGet("GetmedicalrecordsbyanimalId")]
        public ActionResult<List<MedicalRecordDto>> GetMedicalRecordsByAnimalId(int animalId)
        {
            try
            {
                var medicalRecords = _medicalRecordService.GetMedicalRecordsByAnimalId(animalId);
                return Ok(medicalRecords);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

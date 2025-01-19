using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_BLL.Services.AdoptionStatuses;
using Vet_BLL.Services.Pets;

namespace VetClinic.Controllers
{
    public class AdoptionStatusController : _GenericController<AdoptionStatusDto>
    {
        public readonly IAdoptionStatusService _adoptionStatusService;
        public AdoptionStatusController(IAdoptionStatusService service) : base(service)
        {
            _adoptionStatusService = service;
        }
    }
}

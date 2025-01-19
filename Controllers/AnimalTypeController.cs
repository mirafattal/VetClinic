using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.Horses;

namespace VetClinic.Controllers
{
    public class AnimalTypeController  : _GenericController<AnimalTypeDto>
    {
       public readonly IAnimalTypeService _animalTypeService;
       public AnimalTypeController(IAnimalTypeService service) : base(service)
        {
            _animalTypeService = service;
        }
}
}

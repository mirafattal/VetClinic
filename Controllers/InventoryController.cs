using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.Inventories;

namespace VetClinic.Controllers
{
    public class InventoryController : _GenericController<InventoryDto>
    {
        public readonly IinventoryService _inventoryService;
        public InventoryController(IinventoryService service) : base(service)
        {
            _inventoryService = service;
        }
    }
}

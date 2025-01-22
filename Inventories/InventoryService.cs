using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.Services.Appointments;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Appointments;
using Vet_DAL.Repositories.Inventories;

namespace Vet_BLL.Services.Inventories
{
    public class InventoryService: GenericService<Inventory, InventoryDto>, IinventoryService
    {
        public readonly IinventoryRepository _inventoryRepository;
        public readonly IMapper _mapper;

        public InventoryService(IinventoryRepository inventoryRepository, IMapper mapper) :
            base(inventoryRepository, mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }
    }
}

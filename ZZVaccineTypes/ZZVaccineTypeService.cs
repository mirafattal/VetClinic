using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.ZZRatings;
using Vet_DAL.Repositories.ZZVaccineTypes;

namespace Vet_BLL.Services.ZZVaccineTypes
{
    public class ZZVaccineTypeService: GenericService<ZzvaccineType, ZZVaccineTypeDto>, IZZVaccineTypeService
    {
        public readonly IZZVaccineTypeRepository _zZVaccineTypeRepository;
        public readonly IMapper _mapper;

        public ZZVaccineTypeService(IZZVaccineTypeRepository zZVaccineTypeRepository, IMapper mapper) :
            base(zZVaccineTypeRepository, mapper)
        {
            _zZVaccineTypeRepository = zZVaccineTypeRepository;
            _mapper = mapper;
        }
    }
}

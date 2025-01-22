using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.AdoptionStatuses;
using Vet_DAL.Repositories.Pets;

namespace Vet_BLL.Services.AdoptionStatuses
{
    public class AdoptionStatusService: GenericService<AdoptionStatus, AdoptionStatusDto>,
        IAdoptionStatusService
    {
        public readonly IAdoptionStatusRepository _adoptionStatusRepository;
        public readonly IMapper _mapper;

        public AdoptionStatusService(IAdoptionStatusRepository adoptionStatusRepository, 
            IMapper mapper) :
            base(adoptionStatusRepository, mapper)
        {
            _adoptionStatusRepository = adoptionStatusRepository;
            _mapper = mapper;
        }
    }
}

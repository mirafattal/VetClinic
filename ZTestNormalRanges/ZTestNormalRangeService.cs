using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Pets;
using Vet_DAL.Repositories.ZTestNormalRanges;

namespace Vet_BLL.Services.ZTestNormalRanges
{
    public class ZTestNormalRangeService: GenericService<ZtestNormalRange, ZTestNormalRangeDto>, IZTestNormalRangeService
    {
        public readonly IZTestNormalRangeRepository _zTestNormalRangeRepository;
        public readonly IMapper _mapper;

        public ZTestNormalRangeService(IZTestNormalRangeRepository zTestNormalRangeRepository, 
            IMapper mapper) : base(zTestNormalRangeRepository, mapper)
        {
            _zTestNormalRangeRepository = zTestNormalRangeRepository;
            _mapper = mapper;
        }
    }
}
